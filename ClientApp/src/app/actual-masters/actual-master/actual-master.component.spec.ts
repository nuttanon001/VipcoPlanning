import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualMasterComponent } from './actual-master.component';

describe('ActualMasterComponent', () => {
  let component: ActualMasterComponent;
  let fixture: ComponentFixture<ActualMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
