import { Component, OnInit, Inject } from '@angular/core';
import { BaseDialogComponent } from '../../shared/base-dialog.component';
import { BillMaterial } from '../../bill-materials/shared/bill-material.model';
import { BillMaterialService } from '../../bill-materials/shared/bill-material.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-bill-material-dialog',
  templateUrl: './bill-material-dialog.component.html',
  styleUrls: ['./bill-material-dialog.component.scss'],
  providers: [BillMaterialService]
})
export class BillMaterialDialogComponent extends BaseDialogComponent<BillMaterial,BillMaterialService> {

  constructor(
    public service: BillMaterialService,
    public dialogRef: MatDialogRef<BillMaterialDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public InfoValue?: BillMaterial
  ) {
    super(service, dialogRef);
  }

  // on init
  onInit(): void {
    this.fastSelectd = this.InfoValue.BillofMaterialId === -99;
  }

  // on complate or cancel entity
  onComplateOrCancelEntity(infoValue?: BillMaterial): void {
    if (infoValue) {
      this.getValue = infoValue;
    }
  }
}
