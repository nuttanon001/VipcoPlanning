import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualCenterComponent } from './actual-center.component';

describe('ActualCenterComponent', () => {
  let component: ActualCenterComponent;
  let fixture: ComponentFixture<ActualCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
