using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using VipcoPlanning.Models.Planning;
using VipcoPlanning.Services;
using VipcoPlanning.ViewModels;

using AutoMapper;
using VipcoPlanning.Helper;

namespace VipcoPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillofMaterialController : GenericPlanningController<BillofMaterial>
    {
        public BillofMaterialController(IRepositoryPlanning<BillofMaterial> repo,
          IMapper mapper) :
          base(repo, mapper)
        { }
        // GET: api/BillofMaterial/GetByMaster/5
        [HttpGet("GetByMaster")]
        public async Task<IActionResult> GetByMaster(int key)
        {
            if (key > 0)
            {
                var HasBoms = await this.repository.GetToListAsync(x => x,x => x.BomParentId == key);
                if (HasBoms.Any())
                {
                    var MapDatas = new List<BillofMaterialViewModel>();
                    var Parent = await this.repository.GetAsync(key);

                    foreach(var item in HasBoms)
                    {
                        var MapData = this.mapper.Map<BillofMaterial, BillofMaterialViewModel>(item);
                        MapData.BomParentString = Parent != null ? Parent.Name : "-";
                        MapDatas.Add(MapData);
                    }

                    return new JsonResult(MapDatas, this.DefaultJsonSettings);
                }
            }
            return BadRequest(new { Error = "Key not been found." });
        }
        // POST: api/BillofMaterial/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<BillofMaterial>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.Name.ToLower().Contains(keyword) ||
                                              x.Description.ToLower().Contains(keyword) ||
                                              x.Code.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            // Order by
            Func<IQueryable<BillofMaterial>, IOrderedQueryable<BillofMaterial>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "Code":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Code);
                    else
                        order = o => o.OrderBy(x => x.Code);
                    break;
                case "LevelofBom":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.LevelofBom);
                    else
                        order = o => o.OrderBy(x => x.LevelofBom);
                    break;
                case "Name":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Name);
                    else
                        order = o => o.OrderBy(x => x.Name);
                    break;
                case "Description":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Description);
                    else
                        order = o => o.OrderBy(x => x.Description);
                    break;
                default:
                    order = o => o.OrderBy(x => x.Name);
                    break;
            }

            var QueryData = await this.repository.GetToListAsync(
                                    selector: selected => selected,  // Selected
                                    predicate: predicate, // Where
                                    orderBy: order, // Order
                                    include: null, // Include
                                    skip: Scroll.Skip ?? 0, // Skip
                                    take: Scroll.Take ?? 10); // Take

            // Get TotalRow
            Scroll.TotalRow = await this.repository.GetLengthWithAsync(predicate: predicate);

            var mapDatas = new List<BillofMaterialViewModel>();
            foreach (var item in QueryData)
            {
                var MapItem = this.mapper.Map<BillofMaterial, BillofMaterialViewModel>(item);
                mapDatas.Add(MapItem);
            }
            return new JsonResult(new ScrollDataViewModel<BillofMaterialViewModel>(Scroll, mapDatas), this.DefaultJsonSettings);
        }

        [HttpPost("GetBomFromSageX3")]
        public async Task<IActionResult> GetBomFormSageX3([FromBody] List<BillofMaterial> records)
        {
            var Message = "Not been found data.";
            try
            {
                if (records != null && records.Any())
                {
                    var newCode = records.Select(x => x.Code.ToLower().Trim()).ToList();
                    var notInsert = (await this.repository.GetToListAsync(x => x.Code.ToLower().Trim(), x => newCode.Contains(x.Code.ToLower().Trim()))).ToList();

                    foreach (var item in records.Where(z => !notInsert.Contains(z.Code.ToLower().Trim())))
                    {
                        var newBom = new BillofMaterial()
                        {
                            Code = item.Code,
                            Description = item.Description,
                            CreateDate = DateTime.Now,
                            Creator = item.Creator,
                            Name = item.Name,
                            Remark = "From SageX3",
                            LevelofBom = 2,
                        };

                        await this.repository.AddAsync(newBom);
                    }

                    return new JsonResult(new { Result = true }, this.DefaultJsonSettings);
                }
            }
            catch(Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = Message });
        }
       
        // POST: api/BillofMaterial/CreateV2
        [HttpPost("CreateV2")]
        public async Task<IActionResult> CreateV2([FromBody] BillofMaterialViewModel recordViewModel)
        {
            if (recordViewModel == null)
                return BadRequest(new { Error = "Data not been found." });

            var record = this.mapper.Map<BillofMaterialViewModel, BillofMaterial>(recordViewModel);
            // +7 Hour
            record = this.helper.AddHourMethod(record);
            record.CreateDate = DateTime.Now;

            if (await this.repository.AddAsync(record) == null)
                return BadRequest();

            if (recordViewModel.BomLowLevel != null)
            {
                foreach (var item in recordViewModel.BomLowLevel)
                {
                    if (item == null)
                        continue;

                    item.BomParentId = record.BillofMaterialId;
                    item.CreateDate = record.CreateDate;
                    item.Creator = record.Creator;

                    await this.repository.AddAsync(item);
                }
            }

            return new JsonResult(record, this.DefaultJsonSettings);
        }
        // PUT: api/BillofMaterial/UpdateV2
        [HttpPut("UpdateV2")]
        public async Task<IActionResult> UpdateV2(int key, [FromBody] BillofMaterialViewModel recordViewModel)
        {
            if (recordViewModel == null)
                return BadRequest(new { Error = "Data not been found." });

            var record = this.mapper.Map<BillofMaterialViewModel, BillofMaterial>(recordViewModel);
            // +7 Hour
            record = this.helper.AddHourMethod(record);
            // Set date for CrateDate Entity
            if (record.GetType().GetProperty("ModifyDate") != null)
                record.GetType().GetProperty("ModifyDate").SetValue(record, DateTime.Now);

            if (await this.repository.UpdateAsync(record, key) == null)
                return BadRequest();

            var dbBomLowLevel = await this.repository.GetToListAsync(x => x,b => b.BomParentId == key);
            if (recordViewModel.BomLowLevel != null)
            {
                // Remove bom low level if remove
                foreach (var item in dbBomLowLevel)
                {
                    if (!recordViewModel.BomLowLevel.Any(x => x.BillofMaterialId == item.BillofMaterialId))
                        await this.repository.DeleteAsync(item.BillofMaterialId);
                }

                foreach (var item in recordViewModel.BomLowLevel)
                {
                    if (item.BillofMaterialId > 0)
                    {
                        item.ModifyDate = record.ModifyDate;
                        item.Modifyer = record.Modifyer;
                        item.BomParentId = record.BillofMaterialId;

                        await this.repository.UpdateAsync(item,item.BillofMaterialId);
                    }
                    else
                    {
                        item.CreateDate = record.ModifyDate;
                        item.Creator = record.Modifyer;
                        item.BomParentId = record.BillofMaterialId;

                        await this.repository.AddAsync(item);
                    }
                }
            }
            else //Check if update and remove all bow low level
            {
                if (dbBomLowLevel.Any())
                {
                    foreach (var item in dbBomLowLevel)
                        await this.repository.DeleteAsync(item.BillofMaterialId);
                }
            }

            return new JsonResult(record, this.DefaultJsonSettings);
        }
    }
}