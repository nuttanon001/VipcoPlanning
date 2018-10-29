import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualReportTableComponent } from './actual-report-table.component';

describe('ActualReportTableComponent', () => {
  let component: ActualReportTableComponent;
  let fixture: ComponentFixture<ActualReportTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualReportTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualReportTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
