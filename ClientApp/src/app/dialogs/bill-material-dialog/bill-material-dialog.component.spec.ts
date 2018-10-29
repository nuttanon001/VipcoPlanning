import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BillMaterialDialogComponent } from './bill-material-dialog.component';

describe('BillMaterialDialogComponent', () => {
  let component: BillMaterialDialogComponent;
  let fixture: ComponentFixture<BillMaterialDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BillMaterialDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BillMaterialDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
