import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActutalBomTableComponent } from './actutal-bom-table.component';

describe('ActutalBomTableComponent', () => {
  let component: ActutalBomTableComponent;
  let fixture: ComponentFixture<ActutalBomTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActutalBomTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActutalBomTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
