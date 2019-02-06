import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarProgramacionComponent } from './agregar-programacion.component';

describe('AgregarProgramacionComponent', () => {
  let component: AgregarProgramacionComponent;
  let fixture: ComponentFixture<AgregarProgramacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgregarProgramacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarProgramacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
