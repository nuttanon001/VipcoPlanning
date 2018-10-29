import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BillMaterialLowlevelTableComponent } from './bill-material-lowlevel-table.component';

describe('BillMaterialLowlevelTableComponent', () => {
  let component: BillMaterialLowlevelTableComponent;
  let fixture: ComponentFixture<BillMaterialLowlevelTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BillMaterialLowlevelTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BillMaterialLowlevelTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
