import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualTableComponent } from './actual-table.component';

describe('ActualTableComponent', () => {
  let component: ActualTableComponent;
  let fixture: ComponentFixture<ActualTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
