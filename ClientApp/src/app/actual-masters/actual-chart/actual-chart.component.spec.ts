import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualChartComponent } from './actual-chart.component';

describe('ActualChartComponent', () => {
  let component: ActualChartComponent;
  let fixture: ComponentFixture<ActualChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
