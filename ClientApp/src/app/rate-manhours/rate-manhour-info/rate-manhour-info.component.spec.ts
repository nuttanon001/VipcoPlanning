import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RateManhourInfoComponent } from './rate-manhour-info.component';

describe('RateManhourInfoComponent', () => {
  let component: RateManhourInfoComponent;
  let fixture: ComponentFixture<RateManhourInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RateManhourInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RateManhourInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
