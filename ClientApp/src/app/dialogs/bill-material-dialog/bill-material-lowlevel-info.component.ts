import { Component, OnInit } from '@angular/core';
import { BaseInfoDialogComponent } from '../../shared/base-info-dialog-component';
import { BillMaterial } from '../../bill-materials/shared/bill-material.model';
import { FormBuilder, Validators } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-bill-material-lowlevel-info',
  templateUrl: './bill-material-lowlevel-info.component.html',
  styleUrls: ['./bill-material-lowlevel-info.component.scss']
})
export class BillMaterialLowlevelInfoComponent extends BaseInfoDialogComponent<BillMaterial> {

  constructor(
    private fb:FormBuilder
  ) { super() }

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
      BomParentId: [this.InfoValue.BomParentId],
      //BaseMode
      CreateDate: [this.InfoValue.CreateDate],
      Creator: [this.InfoValue.Creator],
      ModifyDate: [this.InfoValue.ModifyDate],
      Modifyer: [this.InfoValue.Modifyer],
      //ViewModel
      BomLowLevel: [this.InfoValue.BomLowLevel],
      BomParentString: [this.InfoValue.BomParentString],
    });

    this.InfoValueForm.valueChanges.pipe(debounceTime(250), distinctUntilChanged()).subscribe(data => {
      if (!this.InfoValueForm) { return; }
      if (this.InfoValueForm.valid) {
        this.InfoValue = this.InfoValueForm.value;
        this.SubmitOrCancel.emit(this.InfoValue);
      }
    });
  }
}
