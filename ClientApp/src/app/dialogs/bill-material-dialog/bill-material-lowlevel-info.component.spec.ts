import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BillMaterialLowlevelInfoComponent } from './bill-material-lowlevel-info.component';

describe('BillMaterialLowlevelInfoComponent', () => {
  let component: BillMaterialLowlevelInfoComponent;
  let fixture: ComponentFixture<BillMaterialLowlevelInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BillMaterialLowlevelInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BillMaterialLowlevelInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
