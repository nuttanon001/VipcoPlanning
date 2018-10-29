import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualInfoComponent } from './actual-info.component';

describe('ActualInfoComponent', () => {
  let component: ActualInfoComponent;
  let fixture: ComponentFixture<ActualInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
