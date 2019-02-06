import { Component, OnInit, HostListener, Input } from '@angular/core';
import { CurrencyPipe } from '@angular/common';

import { CatalogosService } from '../../Servicios/catalogos.service';
import { LoadingService } from '../../Servicios/loading.service';
import {MensajesService} from "../../../Servicios/mensajes.service";


import { UR } from '../../Clases/URs';
import { Cog } from '../../Clases/Cog';

@Component({
  selector: 'app-agregar-programacion',
  templateUrl: './agregar-programacion.component.html',
  styleUrls: ['./agregar-programacion.component.css']
})
export class AgregarProgramacionComponent implements OnInit {

  arrRegistrosProgramacion:any[];
  cantidad_primer_periodo:number;
  cantidad_segundo_periodo:number;
  cantidad_tercer_periodo:number;
  cantidad_total_presupuesto:number;
  observaciones:String;
  
  cmbUr : UR;
  cmbCuentaEspecifica : Cog;

  cmbOrigenRecuerso:string;
  cmbAplicacionPresupuesto:string;

  comboUR : UR[];
  comboPartidas : Cog[];

  constructor(private currencyPipe:CurrencyPipe,
    private catalogoService: CatalogosService,
    private loadingService: LoadingService,
    private mensajes:MensajesService,) { }

  ngOnInit() {
    this.cantidad_primer_periodo = 0;
    this.cantidad_segundo_periodo=0;
    this.cantidad_tercer_periodo = 0;
    this.arrRegistrosProgramacion = new Array();
    setTimeout(() => {
      this.getURs();
      this.getPartidas();
    });
  }

  agregarRegistroProgramacion(){
    console.log(this.cantidad_primer_periodo);
    console.log(this.cantidad_segundo_periodo);
    console.log(this.cantidad_tercer_periodo);
    
      this.arrRegistrosProgramacion.push({
          ur:this.cmbUr,
          partida: this.cmbCuentaEspecifica,
          origen: this.cmbOrigenRecuerso,
          aplicacion: this.cmbAplicacionPresupuesto,
          cantidad_primer_periodo: this.quitaFormatoMoneda(this.cantidad_primer_periodo),
          cantidad_segundo_periodo: this.quitaFormatoMoneda(this.cantidad_segundo_periodo),
          cantidad_tercer_periodo: this.quitaFormatoMoneda(this.cantidad_tercer_periodo),
          observaciones: this.observaciones,
          accion:''
      });
      this.limpiaCamposFormulario();
      console.log(this.arrRegistrosProgramacion);
  }

  currencyInputFormat(value) {
    return this.currencyPipe.transform(this.quitaFormatoMoneda(value.target.value), 'MXN')
  }

  private getURs(){
    this.loadingService.toggle();
    this.catalogoService.getURs().subscribe(
      respuesta  => {
        if(respuesta.estatus == true)
          this.comboUR = respuesta.data.urs;
        else
          this.mensajes.showWarning(respuesta.mensaje);

        this.loadingService.toggle();
    }, error => {
        this.mensajes.showError(error.message);
        this.loadingService.toggle();
    });
  }

  private getPartidas(){
    this.loadingService.toggle();
    this.catalogoService.getCOG().subscribe(
      respuesta  => {
        if(respuesta.estatus == true)
          this.comboPartidas = respuesta.data.cogs;
        else
          this.mensajes.showWarning(respuesta.mensaje);

        this.loadingService.toggle();
    }, error => {
        this.mensajes.showError(error.message);
        this.loadingService.toggle();
    });
  }

  quitaFormatoMoneda(pNumero):number {
      let cantidad = pNumero.replace(/[$,]/g,'');
      return parseFloat(cantidad);//+ para convertir a número
  }

  limpiaCamposFormulario():void {
    this.observaciones = "";
    this.cmbOrigenRecuerso = "";
    this.cmbAplicacionPresupuesto = "";
    this.cantidad_primer_periodo = 0;
    this.cantidad_segundo_periodo = 0;
    this.cantidad_tercer_periodo = 0;
    this.cantidad_total_presupuesto = 0;
  }

  editarRegistroTabla(pRegistro):void{
      this.observaciones = pRegistro.observaciones;
      this.cmbOrigenRecuerso = pRegistro.origen;
      this.cmbAplicacionPresupuesto = pRegistro.aplicacion;
      this.cantidad_primer_periodo = pRegistro.cantidad_primer_periodo;
      this.cantidad_segundo_periodo = pRegistro.cantidad_segundo_periodo;
      this.cantidad_tercer_periodo = pRegistro.cantidad_tercer_periodo;
      this.cmbUr = pRegistro.ur;
      this.cmbCuentaEspecifica = pRegistro.partida;
  }

}
