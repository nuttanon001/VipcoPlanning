import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupStandardTimeInfoComponent } from './group-standard-time-info.component';

describe('GroupStandardTimeInfoComponent', () => {
  let component: GroupStandardTimeInfoComponent;
  let fixture: ComponentFixture<GroupStandardTimeInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupStandardTimeInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupStandardTimeInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
