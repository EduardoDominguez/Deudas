import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { CatalogosService } from '../../Servicios/catalogos.service';

import { Periodo } from '../../Clases/Periodos';
import { Constantes } from '../../Clases/Constantes';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { AgregarPeriodoComponent } from '../modales/agregar-periodo/agregar-periodo.component';

import { LoadingService } from '../../Servicios/loading.service';
import {MensajesService} from "../../../Servicios/mensajes.service";

declare var $;

@Component({
  selector: 'app-periodos',
  templateUrl: './periodos.component.html',
  styleUrls: ['./periodos.component.css']
})
export class PeriodosComponent implements OnInit {
 
  //@ViewChild('dataTable') table;
  dataTable: any;
  dtOption : any;
  
  dataSource :Periodo[];
  private CONSTANTES : Constantes;

  constructor(
    private modalService: NgbModal,
    private catalogoService: CatalogosService,
    private loadingService: LoadingService,
    private mensajes:MensajesService,
  ) { }

  ngOnInit() {
    this.CONSTANTES = new Constantes();
    //this.dataTable = $(this.table.nativeElement);
    setTimeout(() => {
      this.getPeriodos();
    });
  }
  
  closeResult: string;

  open() {
    this.modalService.open(AgregarPeriodoComponent, {ariaLabelledBy: 'modal-basic-title',  size: 'lg'}).result.then((result) => {
      //this.closeResult = `Closed with: ${result}`;
      //if(result === 'new')
          //this.dataTable.DataTable().reload();
      console.log(result);
      if(result == 'new'){
        setTimeout(() => {
          this.getPeriodos();
        });
      }
    }, (reason) => {
      console.log(reason);
      if(reason == 'new'){
        setTimeout(() => {
          this.getPeriodos();
        });
      }
        //this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  /*open(content) {
    this.modalService.open(AgregarPeriodoComponent, {ariaLabelledBy: 'modal-basic-title',  size: 'lg'});
  }*/

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }


  private getPeriodos(){
    this.loadingService.toggle();
    this.catalogoService.getPeriodos().subscribe(
      respuesta  => {
        if(respuesta.estatus == true){
          this.dataSource = respuesta.data.periodos;
        }else{
          this.mensajes.showWarning(respuesta.mensaje);
        }
        this.loadingService.toggle();
    }, error => {
        this.mensajes.showError(error.message);
        this.loadingService.toggle();
    });
  }

}
