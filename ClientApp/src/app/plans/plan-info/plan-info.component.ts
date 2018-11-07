//Angular Core
import { Component, OnInit, ViewContainerRef, Output, EventEmitter} from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
//Components
import { BaseInfoComponent } from '../../shared/base-info-component';
//Services
import { PlanService } from '../shared/plan.service';
import { PlanCommuncateService } from '../shared/plan-communcate.service';
//Models
import { PlanMaster } from '../shared/plan-master.model';
import { PlanDetail } from '../shared/plan-detail.model';
import { ModelExcel } from '../shared/model-excel';
//3rdParty
import * as XLSX from 'xlsx';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { PlanDetailService } from '../shared/plan-detail.service';
import { AuthService } from '../../core/auth/auth.service';
import { PlanShipment } from '../shared/plan-shipment.model';
import { PlanShipmentService } from '../shared/plan-shipment.service';
import * as moment from "moment";


@Component({
  selector: 'app-plan-info',
  templateUrl: './plan-info.component.html',
  styleUrls: ['./plan-info.component.scss']
})
export class PlanInfoComponent extends BaseInfoComponent<PlanMaster,PlanService,PlanCommuncateService> {

  constructor(
    service: PlanService,
    serviceCommuncate: PlanCommuncateService,
    private servicePlanDetail: PlanDetailService,
    private servicePlanShip:PlanShipmentService,
    private serviceAuth:AuthService,
    private fb: FormBuilder,
    private serviceDialog: DialogsService,
    private viewContainerRef:ViewContainerRef
  ) {
    super(service, serviceCommuncate);
  }
  //Parameter
  indexItem: number;
  infoValueDetail: PlanDetail;
  planDetailFormFile: Array<PlanDetail>;
  onLoading: boolean = false;
  @Output() CancelSave: EventEmitter<boolean> = new EventEmitter<boolean>();

  // on GetData
  onGetDataByKey(infoValue?: PlanMaster): void {
    this.CancelSave.emit(false);
    if (infoValue) {
      if (infoValue.PlanMasterId) {
        this.service.getOneKeyNumber(infoValue)
          .subscribe(dbData => {
            this.InfoValue = dbData;
            if (this.InfoValue) {
              this.onLoading = true;
              this.servicePlanDetail.getByMasterId(this.InfoValue.PlanMasterId)
                .subscribe(dbPlanDetail => {
                  if (dbPlanDetail) {
                    if (!this.InfoValue.PlanDetails) {
                      this.InfoValue.PlanDetails = new Array;
                    }

                    dbPlanDetail.forEach((item, index) => {
                      this.InfoValue.PlanDetails.push(Object.assign({}, item));
                    });
                    this.InfoValue.PlanDetails = this.InfoValue.PlanDetails.slice();
                    if (this.InfoValueForm) {
                      this.InfoValueForm.patchValue({
                        PlanDetails: this.InfoValue.PlanDetails
                      });
                    }
                  }
                  this.onLoading = false;
                });

              this.servicePlanShip.getByMasterId(this.InfoValue.PlanMasterId)
                .subscribe(dbPlanShip => {
                  if (dbPlanShip) {
                    dbPlanShip.forEach(item => {
                      let temp: PlanShipment = {
                        PlanShipmentId: 0
                      };

                      for (let key in item) {
                        // console.log(key);
                        if (key.indexOf("$id") === -1) {
                          temp[key] = item[key];
                        } 
                      }
                      this.InfoValue.PlanShipments.push(temp);
                    });
                    this.InfoValue.PlanShipments = this.InfoValue.PlanShipments.slice();

                    if (this.InfoValueForm) {
                      this.InfoValueForm.patchValue({
                        PlanShipments: this.InfoValue.PlanShipments
                      });
                    }
                  }
                });
            }
          }, error => console.error(error), () => this.buildForm());
      }
    } else {
      this.InfoValue = {
        PlanMasterId: 0,
        Revised: 0,
        PlanDetails: new Array,
        PlanShipments: new Array,
      };
      this.buildForm();
    }
  }

  // build form
  buildForm(): void {
    // Form
    this.InfoValueForm = this.fb.group({
      PlanMasterId: [this.InfoValue.PlanMasterId],
      ProjectName: [this.InfoValue.ProjectName,
        [
          Validators.required,
          Validators.maxLength(100)
        ]
      ],
      Revised: [this.InfoValue.Revised],
      DeliveryDate: [this.InfoValue.DeliveryDate,
        [
          Validators.required
        ]
      ],
      PlanningStatus: [this.InfoValue.PlanningStatus],
      ProjectCodeMasterId: [this.InfoValue.ProjectCodeMasterId],
      ManagementName: [this.InfoValue.ManagementName,
        [
          Validators.required,
          Validators.maxLength(500)
        ]
      ],
      ManagementBy: [this.InfoValue.ManagementBy],
      PlanDetails: [this.InfoValue.PlanDetails],
      PlanShipments: [this.InfoValue.PlanShipments],
      //BaseModel
      CreateDate: [this.InfoValue.CreateDate],
      Creator: [this.InfoValue.Creator],
      ModifyDate: [this.InfoValue.ModifyDate],
      Modifyer: [this.InfoValue.Modifyer],
    });
    this.InfoValueForm.valueChanges.subscribe((data: any) => this.onValueChanged(data));

    if (this.InfoValueForm) {
      Object.keys(this.InfoValueForm.controls).forEach(field => {
        const control = this.InfoValueForm.get(field);
        control.markAsTouched({ onlySelf: true });
      });
    }
  }

  // open Dialog
  openDialog(mode: string = ""): void {
    if (mode) {
      if (mode.indexOf("Project") !== -1) {
        this.serviceDialog.dialogSelectProject(this.viewContainerRef)
          .subscribe(project => {
            if (this.InfoValueForm && project) {
              this.InfoValueForm.patchValue({
                ProjectCodeMasterId: project.ProjectCodeMasterId,
                ProjectName: `${project.ProjectCode} ${project.ProjectName}`
              });
            }
          })
      } else if (mode.indexOf("Employee") !== -1) {
        this.serviceDialog.dialogSelectEmployees(this.viewContainerRef)
          .subscribe(emp => {
            if (this.InfoValueForm && emp) {
              let nameThai: string = "";
              emp.forEach(item => {
                nameThai += (nameThai ? "," : "") + item.NameThai
              });
            
              this.InfoValueForm.patchValue({
                ManagementBy: emp[0].EmpCode,
                ManagementName: nameThai
              });
            }
          });
      } else {
        this.serviceDialog.error("Waining Message", "Can't found command !!!", this.viewContainerRef);
      }
    }
  }

  ////////////
  // Tested //
  ////////////

  onFileChange(evt: any) {
    /* wire up file reader */
    const target: DataTransfer = <DataTransfer>(evt.target);
    if (target.files.length !== 1) throw new Error('Cannot use multiple files');

    this.planDetailFormFile = new Array;
    const reader: FileReader = new FileReader();
    reader.onload = (e: any) => {
      this.onLoading = true;
      /* read workbook */
      const bstr: string = e.target.result;
      const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary' });

      /* grab first sheet */
      const wsname: string = wb.SheetNames[0];
      const ws: XLSX.WorkSheet = wb.Sheets[wsname];
      let temp1 = <ModelExcel[]>XLSX.utils.sheet_to_json(ws, { dateNF: "dd/MM/yy" });

      temp1.forEach((value, index) => {
        let newPlan: PlanDetail = {
          AssignmentToGroup: value.AssignmentToGroup,
          Code: value.Code,
          BomLevel2: value.BomLevel2,
          ContentWeigth: value.ContentWeigth,
          CustomerDrawingDate: value.CustomerDrawingDate !== undefined ? new Date(value.CustomerDrawingDate) : undefined,
          CuttingPlanDate: value.CuttingPlanDate !== undefined ? new Date(value.CuttingPlanDate) : undefined,
          Description: value.Description,
          FabPlanEDate: value.FabPlanEDate !== undefined ? new Date(value.FabPlanEDate) : undefined,
          FabPlanSDate: value.FabPlanSDate !== undefined ? new Date(value.FabPlanSDate) : undefined,
          InsuPlanEDate: value.InsuPlanEDate !== undefined ? new Date(value.InsuPlanEDate) : undefined,
          InsuPlanSDate: value.InsuPlanSDate !== undefined ? new Date(value.InsuPlanSDate) : undefined,
          MachineAndPartDate: value.MachineAndPartDate !== undefined ? new Date(value.MachineAndPartDate) : undefined,
          MaterialDate: value.MaterialDate !== undefined ? new Date(value.MaterialDate) : undefined,
          PackPlanEDate: value.PackPlanEDate !== undefined ? new Date(value.PackPlanEDate) : undefined,
          PackPlanSDate: value.PackPlanSDate !== undefined ? new Date(value.PackPlanSDate) : undefined,
          PaintPlanEDate: value.PaintPlanEDate !== undefined ? new Date(value.PaintPlanEDate) : undefined,
          PaintPlanSDate: value.PaintPlanSDate !== undefined ? new Date(value.PaintPlanSDate) : undefined,
          PreAssPlanEDate: value.PreAssPlanEDate !== undefined ? new Date(value.PreAssPlanEDate) : undefined,
          PreAssPlanSDate: value.PreAssPlanSDate !== undefined ? new Date(value.PreAssPlanSDate) : undefined,
          ResponsibilityBy: value.ResponsibilityBy,
          ShopDrawingDate: value.ShopDrawingDate !== undefined ? new Date(value.ShopDrawingDate) : undefined,
          Remark: value.Remark,
          CheckCuttingPlanStd: value.CheckCuttingPlanStd,
          CheckPackingFrameStd: value.CheckPackingFrameStd,
          CheckShopDrawingStd: value.CheckShopDrawingStd,
          CuttingPlanStd: value.CuttingPlanStd,
          FabStd: value.FabStd,
          PackingFrameStd: value.PackingFrameStd,
          PackStd: value.PackStd,
          PreStd: value.PreStd,
          ShopDrawingStd: value.ShopDrawingStd,
          WeldStd: value.WeldStd
        };

        this.planDetailFormFile.push(newPlan);
      });
      this.planDetailFormFile = this.planDetailFormFile.slice();
      this.InfoValueForm.patchValue({
        PlanDetails: this.planDetailFormFile
      });
      this.onLoading = false;
    };
    reader.readAsBinaryString(target.files[0]);
  }
  // Dialog Action
  OnPlanDetailSelect(Item: { data?: PlanDetail, option: number }) :void{
    if (Item) {
      if (Item.option === 1) {
        this.CancelSave.emit(true);
        this.servicePlanDetail.getOneKeyNumber(Item.data)
          .subscribe(dbData => {
            if (!dbData.EngineerManHour) {
              dbData.EngineerManHour = {};
            }
            if (!dbData.FabricationManHour) {
              dbData.FabricationManHour = {};
            }
            if (!dbData.PackingManHour) {
              dbData.PackingManHour = {};
            }
            if (!dbData.WeldManHour) {
              dbData.WeldManHour = {};
            }
            this.infoValueDetail = dbData;
          });
        // Send to dialog BomLowLevel
      }
      else if (Item.option === 0) // Remove
      {
        // TODO Remove from database
        this.serviceDialog.confirm("Question Message", "Do you want remove this item.", this.viewContainerRef)
          .subscribe(result => {
            if (result) {
              this.onLoading = true;
              this.servicePlanDetail.deleteKeyNumber(Item.data)
                .subscribe(() => this.OnReloadPlanDetail());
            }
          });
      }
    }
  }

  OnPlanShipment(Item: { data?: PlanShipment, option: number }): void {
    if (Item) {
      if (!Item.data) {
        this.indexItem = -1;
      } else {
        this.indexItem = this.InfoValue.PlanShipments.indexOf(Item.data);
      }

      if (Item.option === 2) {
        let planShip: PlanShipment;
        // IF Edit data
        if (Item.data) {
          planShip = Object.assign({}, Item.data);
        } else { // Else New data
          planShip = {
            PlanShipmentId: 0,
          };
        }

        this.serviceDialog.dialogInfoPlanShipment(this.viewContainerRef, planShip)
          .subscribe(result => {
            if (result) {
              if (this.indexItem > -1) {
                // remove item
                this.InfoValue.PlanShipments.splice(this.indexItem, 1);
              }

              this.InfoValue.PlanShipments.push(Object.assign({}, result));
              this.InfoValue.PlanShipments = this.InfoValue.PlanShipments.sort((item1, item2) => {
                let result = moment(item1.DateShipment).isBefore(moment(item2.DateShipment));
                return result ? -1 : 1;
              }).slice();
              // Update to form
              this.InfoValueForm.patchValue({
                PlanShipments: this.InfoValue.PlanShipments
              });
            }
          });
      }
      else if (Item.option === 0) // Remove
      {
        this.InfoValue.PlanShipments.splice(this.indexItem, 1);
        this.InfoValue.PlanShipments = this.InfoValue.PlanShipments.slice();
        // Update to form
        this.InfoValueForm.patchValue({
          PlanShipments: this.InfoValue.PlanShipments
        });
      }
    }
  }

  OnSubmiteOrCancel(InfoValueDetail?: PlanDetail): void {
    this.CancelSave.emit(false);
    if (InfoValueDetail) {

      if (this.serviceAuth.getAuth) {
        InfoValueDetail.Modifyer = this.serviceAuth.getAuth.UserName || "";
      }

      this.servicePlanDetail.updateModelWithKey(InfoValueDetail)
        .subscribe((data: any) => {
          this.infoValueDetail = undefined;
          this.OnReloadPlanDetail();
        });
    } else {
      this.infoValueDetail = undefined;
    }
  }

  OnReloadPlanDetail(): void {
    this.onLoading = true;
    this.servicePlanDetail.getByMasterId(this.InfoValue.PlanMasterId)
      .subscribe(dbPlanDetail => {
        if (dbPlanDetail) {
          if (!this.InfoValue.PlanDetails) {
            this.InfoValue.PlanDetails = new Array;
          }
          this.InfoValue.PlanDetails = dbPlanDetail.slice();
          if (this.InfoValueForm) {
            this.InfoValueForm.patchValue({
              PlanDetails: this.InfoValue.PlanDetails
            });
          }
        }
        this.onLoading = false;
      });
  }

  // on down load csvfile
  onOpenDownLoadFormatFile(link: string): void {
    if (link) {
      window.open(link, "_blank");
    }
  }
}
