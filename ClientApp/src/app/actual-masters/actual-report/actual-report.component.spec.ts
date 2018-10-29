import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualReportComponent } from './actual-report.component';

describe('ActualReportComponent', () => {
  let component: ActualReportComponent;
  let fixture: ComponentFixture<ActualReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
