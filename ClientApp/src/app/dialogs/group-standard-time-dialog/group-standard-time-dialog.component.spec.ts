import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupStandardTimeDialogComponent } from './group-standard-time-dialog.component';

describe('GroupStandardTimeDialogComponent', () => {
  let component: GroupStandardTimeDialogComponent;
  let fixture: ComponentFixture<GroupStandardTimeDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupStandardTimeDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupStandardTimeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
