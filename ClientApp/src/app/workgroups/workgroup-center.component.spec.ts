import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkgroupCenterComponent } from './workgroup-center.component';

describe('WorkgroupCenterComponent', () => {
  let component: WorkgroupCenterComponent;
  let fixture: ComponentFixture<WorkgroupCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkgroupCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkgroupCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
