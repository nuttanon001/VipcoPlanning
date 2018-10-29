import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardTimeForWorkgroupDialogComponent } from './standard-time-for-workgroup-dialog.component';

describe('StandardTimeForWorkgroupDialogComponent', () => {
  let component: StandardTimeForWorkgroupDialogComponent;
  let fixture: ComponentFixture<StandardTimeForWorkgroupDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StandardTimeForWorkgroupDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StandardTimeForWorkgroupDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
