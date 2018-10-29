import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BillMaterialCenterComponent } from './bill-material-center.component';

describe('BillMaterialCenterComponent', () => {
  let component: BillMaterialCenterComponent;
  let fixture: ComponentFixture<BillMaterialCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BillMaterialCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BillMaterialCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
