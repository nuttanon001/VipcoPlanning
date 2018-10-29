import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseInfoComponent } from '../../shared/base-info-component';
import { BillMaterial } from '../shared/bill-material.model';
import { BillMaterialService } from '../shared/bill-material.service';
import { BillMaterialCommuncateService } from '../shared/bill-material-communcate.service';
import { FormBuilder, Validators } from '@angular/forms';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';


@Component({
  selector: 'app-bill-material-info',
  templateUrl: './bill-material-info.component.html',
  styleUrls: ['./bill-material-info.component.scss']
})
export class BillMaterialInfoComponent extends BaseInfoComponent<BillMaterial,BillMaterialService,BillMaterialCommuncateService> {

  constructor(
    service: BillMaterialService,
    serviceCommuncate: BillMaterialCommuncateService,
    private fb: FormBuilder,
    private serviceDialogs: DialogsService,
    private viewContainerRef:ViewContainerRef
  ) {
    super(service, serviceCommuncate);
  }
  indexItem?: number;

  // on get data from api
  onGetDataByKey(infoValue?:BillMaterial): void {
    if (infoValue) {
      if (infoValue.BillofMaterialId) {
        this.service.getOneKeyNumber(infoValue)
          .subscribe(dbInfoValue => {
            if (dbInfoValue) {
              this.InfoValue = Object.assign({}, dbInfoValue);
              // GetBomLevel2
              this.service.getByMasterId(this.InfoValue.BillofMaterialId)
                .subscribe(dbLevel2 => {
                  if (dbLevel2) {
                    this.InfoValue.BomLowLevel = new Array;
                    dbLevel2.forEach(item => {
                      this.InfoValue.BomLowLevel.push({
                        BillofMaterialId: item.BillofMaterialId,
                        BomParentId: item.BomParentId,
                        BomParentString: item.BomParentString,
                        Code: item.Code,
                        CreateDate: item.CreateDate,
                        Creator: item.Creator,
                        Description: item.Description,
                        LevelofBom: item.LevelofBom,
                        ModifyDate: item.ModifyDate,
                        Modifyer: item.Modifyer,
                        Name: item.Name,
                        Remark: item.Remark
                      });
                    });
                    if (this.InfoValueForm) {
                      this.InfoValueForm.patchValue({
                        BomLowLevel: this.InfoValue.BomLowLevel
                      });
                    }
                  }
                })
            }
          }, error => { } , () => this.buildForm());
      }
    }
    else {
      this.InfoValue = {
        BillofMaterialId : 0,
        LevelofBom : 1,
        BomLowLevel : new Array
      };

      this.buildForm();
    }
  }

  // on build form
  buildForm(): void {
    this.InfoValueForm = this.fb.group({
      BillofMaterialId: [this.InfoValue.BillofMaterialId],
      Code: [this.InfoValue.Code,
        [
          Validators.required,
          Validators.maxLength(50)
        ]
      ],
      Name: [this.InfoValue.Name, [Validators.required, Validators.maxLength(200)]],
      LevelofBom: [this.InfoValue.LevelofBom],
      Description: [this.InfoValue.Description, [Validators.maxLength(200)]],
      Remark: [this.InfoValue.Remark, [Validators.maxLength(200)]],
      BomParentId:[this.InfoValue.BomParentId],
      //BaseMode
      CreateDate: [this.InfoValue.CreateDate],
      Creator: [this.InfoValue.Creator],
      ModifyDate: [this.InfoValue.ModifyDate],
      Modifyer: [this.InfoValue.Modifyer],
      //ViewModel
      BomLowLevel: [this.InfoValue.BomLowLevel],
      BomParentString: [this.InfoValue.BomParentString],
    });

    this.InfoValueForm.valueChanges
      .pipe(debounceTime(250), distinctUntilChanged())
      .subscribe(data => this.onValueChanged(data));

    if (this.InfoValueForm) {
      Object.keys(this.InfoValueForm.controls).forEach(field => {
        const control = this.InfoValueForm.get(field);
        control.markAsTouched({ onlySelf: true });
      });
    }
  }

  // On BoMLowLevelSelect
  OnBoMLowLevelSelect(Item: { data?: BillMaterial, option: number }) {
    if (Item) {

      if (!Item.data) {
        this.indexItem = -1;
      } else {
        this.indexItem = this.InfoValue.BomLowLevel.indexOf(Item.data);
      }

      if (Item.option === 1) {
        let editValue: BillMaterial;
        // IF Edit data
        if (Item.data) {
          editValue = Object.assign({}, Item.data);
          editValue.BomParentString = this.InfoValue.Name;
        } else { // Else New data
          editValue = {
            BillofMaterialId: 0,
            LevelofBom: this.InfoValue.LevelofBom + 1,
            BomParentString: this.InfoValue.Name
          };
        }
        // Send to dialog BomLowLevel
        this.serviceDialogs.dialogInfoBomLowLevel(this.viewContainerRef, editValue)
          .subscribe(complateData => {
            if (complateData) {
              if (this.indexItem > -1) {
                // remove item
                this.InfoValue.BomLowLevel.splice(this.indexItem, 1);
              }

              // cloning an object
              this.InfoValue.BomLowLevel.push(Object.assign({}, complateData));
              this.InfoValue.BomLowLevel = this.InfoValue.BomLowLevel.slice();
              // Update to form
              this.InfoValueForm.patchValue({
                BomLowLevel: this.InfoValue.BomLowLevel
              });
            }
          })
      }
      else if (Item.option === 0) // Remove
      {
        this.InfoValue.BomLowLevel.splice(this.indexItem, 1);
        this.InfoValue.BomLowLevel = this.InfoValue.BomLowLevel.slice();
        // Update to form
        this.InfoValueForm.patchValue({
          BomLowLevel: this.InfoValue.BomLowLevel
        });
      }
    }
  }
}
