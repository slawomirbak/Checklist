import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OneChecklistComponent } from './one-checklist.component';

describe('OneChecklistComponent', () => {
  let component: OneChecklistComponent;
  let fixture: ComponentFixture<OneChecklistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OneChecklistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OneChecklistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
