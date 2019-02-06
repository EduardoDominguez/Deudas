import { Component, OnInit, ViewChild } from '@angular/core';
import {NgbModule, NgbDate, NgbCalendar, NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {Router} from "@angular/router";

import { LoadingService } from '../../../Servicios/loading.service';
import {MensajesService} from "../../../../Servicios/mensajes.service";
import {CatalogosService} from "../../../Servicios/catalogos.service";
import {StorageService} from "../../../../Servicios/storage.service";

import {Periodo} from "../../../Clases/Periodos";



@Component({
  selector: 'app-agregar-periodo',
  templateUrl: './agregar-periodo.component.html',
  styleUrls: ['./agregar-periodo.component.css']
})
export class AgregarPeriodoComponent implements OnInit {

  public tablaPeriodos:Periodo[];
  public isCollapsedAlta = true;
  public isCollapsedCaptura = true;
  public isCollapsedEntrega = true;

  public isEnabledCombo;

  public comboPeriodos: number[];
  public comboAnios: number[];
  
  public anio: number;
  public periodo: number;

  @ViewChild('fechaAltaBienes') fechaAltaBienes : any;
  @ViewChild('fechaCapturaRecepcion') fechaCapturaRecepcion : any;
  @ViewChild('fechaEntrega') fechaEntrega : any;
  
  public rangoAltaValido:boolean;
  public rangoCapturaValido:boolean;
  public rangoEntregaValido:boolean;

  nb_ruta:string;

  public fecha :any; //var ano = fecha.getFullYear();

  constructor(
    public activeModal: NgbActiveModal,
    private mensajes: MensajesService,
    private catalogoService: CatalogosService,
    private loadingService: LoadingService,
    private storageService: StorageService,
    private router: Router,
  ) { }


  ngOnInit() {
    if(this.storageService.getCurrentSession() == null)
        this.storageService.logout();

    this.periodo = 0;
    this.anio = 0;
    this.rangoAltaValido = false;
    this.rangoCapturaValido = false;
    this.rangoEntregaValido = false;
    this.fecha = new Date();

    this.tablaPeriodos= [];
    this.comboPeriodos = [1,2,3];
    this.comboAnios = [this.fecha.getFullYear(), this.fecha.getFullYear()-1, this.fecha.getFullYear()-2];
    this.nb_ruta = this.router.url;
    this.isEnabledCombo = false;
  }

  Validar () :boolean{
    if(this.periodo <= 0){
      this.mensajes.showWarning("Debe seleccionar un periodo.");
      return false;
    }

    if(this.anio <= 0){
      this.mensajes.showWarning("Debe seleccionar un año.");
      return false;
    }

    if(this.fechaAltaBienes.fromDate == null){
      this.mensajes.showWarning("Debe seleccionar un rango de fecha válido para alta de bienes.");
      return false;
    }

    if(this.fechaAltaBienes.toDate == null){
      this.mensajes.showWarning("Debe seleccionar un rango de fecha fin para alta de bienes.");
      return false;
    }

    if(this.fechaCapturaRecepcion.fromDate == null){
      this.mensajes.showWarning("Debe seleccionar un rango de fecha válido para captura y recepción.");
      return false;
    }

    if(this.fechaCapturaRecepcion.toDate == null){
      this.mensajes.showWarning("Debe seleccionar un rango de fecha fin para captura y recepción.");
      return false;
    }

    if(this.fechaEntrega.fromDate == null){
      this.mensajes.showWarning("Debe seleccionar un rango de fecha válido para entrega.");
      return false;
    }

    if(this.fechaEntrega.toDate == null){
      this.mensajes.showWarning("Debe seleccionar un rango de fecha fin para entrega.");
      return false;
    }

    return true;
  }

  Agregar()
  {
    if(this.Validar()){
      this.tablaPeriodos.push(
                {"no_periodo":this.periodo,
                "cl_anio" :this.anio,
                "fe_alta_min": `${this.fechaAltaBienes.fromDate.year}-${this.fechaAltaBienes.fromDate.month}-${this.fechaAltaBienes.fromDate.day}`,
                "fe_alta_max": `${this.fechaAltaBienes.toDate.year}-${this.fechaAltaBienes.toDate.month}-${this.fechaAltaBienes.toDate.day}`,
                "fe_cap_rec_min":`${this.fechaCapturaRecepcion.fromDate.year}-${this.fechaCapturaRecepcion.fromDate.month}-${this.fechaCapturaRecepcion.fromDate.day}`,
                "fe_cap_rec_max":`${this.fechaCapturaRecepcion.toDate.year}-${this.fechaCapturaRecepcion.toDate.month}-${this.fechaCapturaRecepcion.toDate.day}`,
                "fe_ent_min":`${this.fechaEntrega.fromDate.year}-${this.fechaEntrega.fromDate.month}-${this.fechaEntrega.fromDate.day}`,
                "fe_ent_max":`${this.fechaEntrega.toDate.year}-${this.fechaEntrega.toDate.month}-${this.fechaEntrega.toDate.day}`,
                "alta_recepcion_rango": this.fechaAltaBienes.getFormatNameRange(),
                "captura_recepcion_rango": this.fechaCapturaRecepcion.getFormatNameRange(),
                "entrega_bienes_rango": this.fechaEntrega.getFormatNameRange(),
                "cl_usuario_crea": this.storageService.getCurrentSession().user.username,
                "nb_programa_crea": this.nb_ruta,
                "fg_activo" : true
              }
      );
      //console.log(this.tablaPeriodos);
      this.eliminaPeriodoCombo(this.periodo);
      this.LimpiaCampos();
      if(this.tablaPeriodos.length > 0)
        this.isEnabledCombo = true;
    }
  }

  LimpiaCampos():void{
      this.fechaAltaBienes.clearDate();
      this.fechaCapturaRecepcion.clearDate();
      this.fechaEntrega.clearDate()
      this.periodo = 0;
      //this.anio = 0;
      this.rangoAltaValido = this.rangoCapturaValido = this.rangoEntregaValido = false;
      //this.tablaPeriodos= new Array();
  }

  eliminaPeriodoCombo(pPeriodo){
    for (let i= 0; i<this.comboPeriodos.length; i++){
      if(pPeriodo == this.comboPeriodos[i]){
        this.comboPeriodos.splice(i, 1);
      }
    }
  }

  eliminaPeriodo(periodo):void{
    for (let i= 0; i<this.tablaPeriodos.length; i++){
      if(periodo == this.tablaPeriodos[i]){
        this.tablaPeriodos.splice(i, 1);
        this.comboPeriodos.push(periodo.no_periodo);
        this.comboPeriodos.sort();
        if(this.tablaPeriodos.length == 0)
          this.isEnabledCombo = false;
      }
    }
  }

  guardarPeriodos(){
    if(this.tablaPeriodos.length<3){
      this.mensajes.showWarning("Se deben agregar los tres periodos antes de poder guardar.");
    }else{
      if(confirm("¿Quieres guardar estos periodos?")) {
        this.loadingService.toggle();
        this.catalogoService.insertaPeriodos(this.tablaPeriodos).subscribe(
          respuesta  => {
            //console.log(respuesta);
            if(respuesta.estatus == true){
              this.mensajes.showSuccess(respuesta.mensaje);
              this.LimpiaCampos();
              this.tablaPeriodos = [];
              this.activeModal.close('new');
            }else{
              this.mensajes.showWarning(respuesta.mensaje);
            }
            this.loadingService.toggle();
        }, error => {
            //console.log(error);
            this.loadingService.toggle(false);
            this.mensajes.showError(error.name);
        });
      }
    }
  }
}
