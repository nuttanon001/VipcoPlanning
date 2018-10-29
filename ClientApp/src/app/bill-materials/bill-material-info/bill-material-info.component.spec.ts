import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BillMaterialInfoComponent } from './bill-material-info.component';

describe('BillMaterialInfoComponent', () => {
  let component: BillMaterialInfoComponent;
  let fixture: ComponentFixture<BillMaterialInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BillMaterialInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BillMaterialInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
