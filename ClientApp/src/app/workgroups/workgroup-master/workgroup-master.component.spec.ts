import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkgroupMasterComponent } from './workgroup-master.component';

describe('WorkgroupMasterComponent', () => {
  let component: WorkgroupMasterComponent;
  let fixture: ComponentFixture<WorkgroupMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkgroupMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkgroupMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
