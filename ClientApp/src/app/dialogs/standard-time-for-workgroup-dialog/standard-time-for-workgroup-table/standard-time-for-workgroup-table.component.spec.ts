import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardTimeForWorkgroupTableComponent } from './standard-time-for-workgroup-table.component';

describe('StandardTimeForWorkgroupTableComponent', () => {
  let component: StandardTimeForWorkgroupTableComponent;
  let fixture: ComponentFixture<StandardTimeForWorkgroupTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StandardTimeForWorkgroupTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StandardTimeForWorkgroupTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
