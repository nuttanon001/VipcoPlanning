import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupStandardTimeTableComponent } from './group-standard-time-table.component';

describe('GroupStandardTimeTableComponent', () => {
  let component: GroupStandardTimeTableComponent;
  let fixture: ComponentFixture<GroupStandardTimeTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupStandardTimeTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupStandardTimeTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
