import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BillMaterialTableComponent } from './bill-material-table.component';

describe('BillMaterialTableComponent', () => {
  let component: BillMaterialTableComponent;
  let fixture: ComponentFixture<BillMaterialTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BillMaterialTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BillMaterialTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
