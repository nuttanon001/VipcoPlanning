import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RateManhourCenterComponent } from './rate-manhour-center.component';

describe('RateManhourCenterComponent', () => {
  let component: RateManhourCenterComponent;
  let fixture: ComponentFixture<RateManhourCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RateManhourCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RateManhourCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
