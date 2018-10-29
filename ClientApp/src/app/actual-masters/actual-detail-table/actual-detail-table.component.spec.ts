import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualDetailTableComponent } from './actual-detail-table.component';

describe('ActualDetailTableComponent', () => {
  let component: ActualDetailTableComponent;
  let fixture: ComponentFixture<ActualDetailTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActualDetailTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualDetailTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
