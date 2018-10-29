import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardTimeTableDialogComponent } from './standard-time-table-dialog.component';

describe('StandardTimeTableDialogComponent', () => {
  let component: StandardTimeTableDialogComponent;
  let fixture: ComponentFixture<StandardTimeTableDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StandardTimeTableDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StandardTimeTableDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
