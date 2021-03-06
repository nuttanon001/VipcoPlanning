// angular
import { Component, Inject, ViewChild, OnDestroy } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";
// models
import { Scroll } from "../../shared/scroll.model";
import { ProjectMaster } from "../../projects/shared/project-master.model";
// service
import { ProjectMasterService } from "../../projects/shared/project-master.service";
// rxjs
import { Observable } from "rxjs/Observable";
import { Subscription } from "rxjs/Subscription";
// base-component
import { BaseDialogComponent } from "../../shared/base-dialog.component";
import { ProjectSubService } from "../../projects/shared/project-sub.service";
import { ProjectSub } from "../../projects/shared/project-sub.model";
import { validateConfig } from "@angular/router/src/config";

@Component({
  selector: "app-project-dialog",
  templateUrl: "./project-dialog.component.html",
  styleUrls: ["./project-dialog.component.scss"],
  providers: [
    ProjectMasterService,
    ProjectSubService,
  ]
})
export class ProjectDialogComponent extends BaseDialogComponent<ProjectMaster, ProjectMasterService> {
  /** employee-dialog ctor */
  constructor(
    public service: ProjectMasterService,
    public serviceSub: ProjectSubService,
    public dialogRef: MatDialogRef<ProjectDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public mode: number
  ) {
    super(
      service,
      dialogRef
    );
  }
  // Parameter
  projectDetails: Array<ProjectSub>;
  // Parameter
  InfoValue: ProjectMaster;
  // on init
  onInit(): void {
    this.fastSelectd = this.mode > 1 ? false : true;
  }

  // Selected Value
  onSelectedValue(value?: ProjectMaster): void {
    if (value) {
      this.getValue = value;
      if (this.fastSelectd) {
        this.onSelectedClick();
      } else {
        if (this.mode > 1) {
          this.serviceSub.getByMasterId(value.ProjectCodeMasterId)
            .subscribe(dbDataBase => {
              this.projectDetails = new Array;
              this.projectDetails = [...dbDataBase];
            });
        }
      }
    }
  }

  onSelectedOptionValue(value?: { data: ProjectSub, option: number }): void {
    if (value) {
      this.getValue.ProjectCodeSub = value.data;
      this.onSelectedClick();
    }
  }

  // on new entity
  onNewEntity(): void {
    this.InfoValue = {
      ProjectCodeMasterId: 0
    };
  }

  // on complate or cancel entity
  onComplateOrCancelEntity(infoValue?: ProjectMaster): void {
    if (infoValue) {
      if (infoValue.ProjectCodeMasterId) {
        this.service.updateModel(infoValue)
          .subscribe(dbData => {
            if (dbData) {
              this.dialogRef.close(dbData);
            }
          });
      } else {
        this.service.addModel(infoValue)
          .subscribe(dbData => {
            if (dbData) {
              this.dialogRef.close(dbData);
            }
          });
      }
    } else {
      this.InfoValue = undefined;
    }
  }
}
