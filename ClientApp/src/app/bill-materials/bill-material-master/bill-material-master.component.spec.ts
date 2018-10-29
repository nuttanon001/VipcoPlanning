import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BillMaterialMasterComponent } from './bill-material-master.component';

describe('BillMaterialMasterComponent', () => {
  let component: BillMaterialMasterComponent;
  let fixture: ComponentFixture<BillMaterialMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BillMaterialMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BillMaterialMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
