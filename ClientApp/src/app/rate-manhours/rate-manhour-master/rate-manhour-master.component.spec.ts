import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RateManhourMasterComponent } from './rate-manhour-master.component';

describe('RateManhourMasterComponent', () => {
  let component: RateManhourMasterComponent;
  let fixture: ComponentFixture<RateManhourMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RateManhourMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RateManhourMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
