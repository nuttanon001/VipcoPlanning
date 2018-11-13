import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualDailyComponent } from './actual-daily.component';

describe('ActualDailyComponent', () => {
  let component: ActualDailyComponent;
  let fixture: ComponentFixture<ActualDailyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualDailyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualDailyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
