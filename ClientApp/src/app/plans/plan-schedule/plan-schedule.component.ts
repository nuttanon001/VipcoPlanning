import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SummanyReport } from '../shared/summany-report';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { SummanyPlanActual } from '../shared/summany-plan-actual';
import { SelectionModel } from '@angular/cdk/collections';
// Rxjs
import { map } from "rxjs/operators/map";
import { Observable } from "rxjs/Observable";
import { merge } from "rxjs/observable/merge";
import { startWith } from "rxjs/operators/startWith";
import { switchMap } from "rxjs/operators/switchMap";
import { catchError } from "rxjs/operators/catchError";
import { of as observableOf } from "rxjs/observable/of";
import { PlanService } from '../shared/plan.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';

@Component({
  selector: 'app-plan-schedule',
  templateUrl: './plan-schedule.component.html',
  styleUrls: ['./plan-schedule.component.scss']
})
export class PlanScheduleComponent implements OnInit {

  constructor(
    private service: PlanService,
    private serviceDialog: DialogsService,
    private fb: FormBuilder,
    private viewContainerRef:ViewContainerRef
  ) { }
  // Parameter
  reportForm: FormGroup;
  schedule: SummanyReport;
  // onLoading
  onLoading: boolean;
  resultsLength: number = 0;
  // Parameter MatTable
  displayedColumns: Array<string>;
  dataSource = new MatTableDataSource<SummanyPlanActual>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  selection: SelectionModel<SummanyPlanActual>;
  selectedRow: SummanyPlanActual;

  // On init
  ngOnInit() {
    this.displayedColumns = ["WorkShopName", "WorkGroup", "Weight", "ManHour","FabKiloPerHour","Item"];
    this.buildForm();

    // If the user changes the sort order, reset back to the first page.
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    // Merge
    //, this.searchBox.search, this.searchBox.onlyCreate
    merge(this.sort.sortChange, this.reportForm.valueChanges)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.onLoading = true;
          let summanyReport: SummanyReport;

          if (this.reportForm) {
            summanyReport = this.reportForm.value;
          } else {
            summanyReport = {};
          }

          //summanyReport.Skip = this.paginator.pageIndex * this.paginator.pageSize,
          //summanyReport.Take = this.paginator.pageSize || 10;
          summanyReport.SortField = this.sort.active;
          summanyReport.SortOrder = this.sort.direction === "desc" ? 1 : -1;

          //debug here
          console.log(JSON.stringify(summanyReport));

          return this.service.summanyPlanMaster(summanyReport);
        }),
        map(data => {
          // Flip flag to show that loading has finished.
          this.onLoading = false;
          this.resultsLength = data.TotalRow;
          return data.SummanyDatas;
        }),
        catchError(() => {
          this.onLoading = false;
          // Catch if the GitHub API has reached its rate limit. Return empty data.
          return observableOf([]);
        })
      ).subscribe(data => this.dataSource.data = data);
    // Selection
    this.selection = new SelectionModel<SummanyPlanActual>(false, [], true)
    this.selection.onChange.subscribe(selected => {
      if (selected.source.selected[0]) {
        this.selectedRow = selected.source.selected[0];
      }
    });
  }
  // build form
  buildForm(schedule?: SummanyReport): void {
    if (!schedule) {
      schedule = { };
    }
    this.schedule = schedule;

    this.reportForm = this.fb.group({
      PlanMasterId: [this.schedule.PlanMasterId],
      PlanMasterName: [""],
      JobNumber: [this.schedule.JobNumber],
      WorkGroup: [this.schedule.WorkGroup],
      Where: [this.schedule.Where],
      BomLevel: [this.schedule.BomLevel],
      Skip: [this.schedule.Skip],
      Take: [this.schedule.Take],
    });
  }

  // openDialog
  openDialog(mode?:string): void {
    if (mode) {
      if (mode.indexOf("PlanMaster") !== -1) {
        this.serviceDialog.dialogSelectPlanMaster(this.viewContainerRef)
          .subscribe(planMaster => {
            if (planMaster) {
              this.reportForm.patchValue({
                PlanMasterId: planMaster.PlanMasterId,
                PlanMasterName: planMaster.ProjectName,
              });
            }
          })
      }
    }
  }
}
