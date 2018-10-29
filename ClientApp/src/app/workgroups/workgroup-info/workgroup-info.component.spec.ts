import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkgroupInfoComponent } from './workgroup-info.component';

describe('WorkgroupInfoComponent', () => {
  let component: WorkgroupInfoComponent;
  let fixture: ComponentFixture<WorkgroupInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkgroupInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkgroupInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
