import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkgroupTableComponent } from './workgroup-table.component';

describe('WorkgroupTableComponent', () => {
  let component: WorkgroupTableComponent;
  let fixture: ComponentFixture<WorkgroupTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkgroupTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkgroupTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
