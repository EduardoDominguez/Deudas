import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarPeriodoComponent } from './agregar-periodo.component';

describe('AgregarPeriodoComponent', () => {
  let component: AgregarPeriodoComponent;
  let fixture: ComponentFixture<AgregarPeriodoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgregarPeriodoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarPeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
