import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatepcikerRangeComponent } from './datepciker-range.component';

describe('DatepcikerRangeComponent', () => {
  let component: DatepcikerRangeComponent;
  let fixture: ComponentFixture<DatepcikerRangeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatepcikerRangeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatepcikerRangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
