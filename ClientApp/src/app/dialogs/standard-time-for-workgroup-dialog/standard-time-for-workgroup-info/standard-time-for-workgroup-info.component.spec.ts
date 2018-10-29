import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardTimeForWorkgroupInfoComponent } from './standard-time-for-workgroup-info.component';

describe('StandardTimeForWorkgroupInfoComponent', () => {
  let component: StandardTimeForWorkgroupInfoComponent;
  let fixture: ComponentFixture<StandardTimeForWorkgroupInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StandardTimeForWorkgroupInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StandardTimeForWorkgroupInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
