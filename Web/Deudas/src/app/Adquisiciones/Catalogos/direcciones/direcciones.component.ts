import { Component, OnInit, ViewChild } from '@angular/core';
import { Constantes } from '../../Clases/Constantes';
import { UR } from '../../Clases/URs';

import { CatalogosService } from '../../Servicios/catalogos.service';
import { LoadingService } from '../../Servicios/loading.service';
import {MensajesService} from "../../../Servicios/mensajes.service";

declare var $;


@Component({
  selector: 'app-direcciones',
  templateUrl: './direcciones.component.html',
  styleUrls: ['./direcciones.component.css']
})
export class DireccionesComponent implements OnInit {

  @ViewChild('dataTable') table;
  dataTable: any;
  dtOption : any;
  private dataSource : UR[];
  private CONSTANTES : Constantes;

  constructor(
    private catalogoService: CatalogosService,
    private loadingService: LoadingService,
    private mensajes:MensajesService,
  ) { }

  ngOnInit() {
    this.CONSTANTES = new Constantes();
    this.dataTable = $(this.table.nativeElement);
    setTimeout(() => {
      this.getURs();
    });
    
  }

  private getURs(){
    this.loadingService.toggle();
    this.catalogoService.getURs().subscribe(
      respuesta  => {
        if(respuesta.estatus == true){
          this.dataSource = respuesta.data.urs;
          this.dtOption = {
            lengthChange: true,
            //"lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "Todos"]],
            //dom: '<"mb-15"B><"row"<"col-sm-6"l><"col-sm-6"f>>irtp',
            //dom: '<"mb-15"><"row"<"col-sm-6"l><"col-sm-6"i>>rtp',//Se quita el f de buscar 
            //dom: '<"mb-15"><"row"<"col-sm-6"><"col-sm-6">>rtp',//Se quita el f de buscar 
            //buttons: [ 'copy', 'excel', 'colvis'],
            "aaData": this.dataSource,
            //'info' : true,
            //"bFilter": false,//Oculra input de busqueda // Se quita por que tampoco filtra por columnas
            "deferRender": true,
            "aoColumns": [ 
              { "mDataProp": "clave_ur", "sClass": "text-center" },
              { "mDataProp": "nombre", "sClass": "text-center" },
              { "mDataProp": "coordinador_administrativo", "sClass": "text-center" },            
              { "mDataProp": "director", "sClass": "text-center" }            
            ],
            "language" : this.CONSTANTES.getConfigLenguajeDatatable()
          };
          //console.log(this.dataSource);
          this.dataTable.DataTable(this.dtOption);
          //this.loading = false;
          /*if(data.estatus)
            this.correctLogin(data.data);
          else
            this.mensajes.showWarning(data.mensaje);*/
        }else
          this.mensajes.showWarning(respuesta.mensaje);

        this.loadingService.toggle();
    }, error => {
        console.log(error);
        this.mensajes.showError(error.message);
        this.loadingService.toggle();
    });
  }
}
