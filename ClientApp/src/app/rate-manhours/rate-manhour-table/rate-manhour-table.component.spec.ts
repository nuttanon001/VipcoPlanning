import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RateManhourTableComponent } from './rate-manhour-table.component';

describe('RateManhourTableComponent', () => {
  let component: RateManhourTableComponent;
  let fixture: ComponentFixture<RateManhourTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RateManhourTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RateManhourTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
