import { Component, OnInit, ViewChild,Output, EventEmitter } from '@angular/core';
import { Constantes } from '../../Clases/Constantes';
import { Cog } from '../../Clases/Cog';
import { CatalogosService } from '../../Servicios/catalogos.service';

import { LoadingService } from '../../Servicios/loading.service';
import {MensajesService} from "../../../Servicios/mensajes.service";
declare var $;

@Component({
  selector: 'app-cog',
  templateUrl: './cog.component.html',
  styleUrls: ['./cog.component.css']
})
export class CogComponent implements OnInit {

  // Usamos el decorador Output
  @Output() MuestraLoading = new EventEmitter();

  @ViewChild('dataTable') table;
  dataTable: any;
  dtOption : any;
  private dataSource :Cog[];
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
        this.getCog();
    });
    
  }

  private getCog(){
    //this.loading = true;
    //console.log(this.CONSTANTES.getConfigLenguajeDatatable());
    //this.MuestraLoading.emit({show: true});
    this.loadingService.toggle();
    this.catalogoService.getCOG().subscribe(
      respuesta  => {
        //console.log(respuesta);
        if(respuesta.estatus == true){
          this.dataSource = respuesta.data.cogs;
          this.dtOption = {
            lengthChange: true,
            //"lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "Todos"]],
            //dom: '<"mb-15"B><"row"<"col-sm-6"l><"col-sm-6"f>>irtp',
            //dom: '<"mb-15"><"row"<"col-sm-6"l><"col-sm-6"i>>rtp',//Se quita el f de buscar 
            //dom: '<"mb-15"><"row"<"col-sm-6"><"col-sm-6">>rtp',//Se quita el f de buscar 
            //buttons: [ 'copy', 'excel', 'colvis'],
            "aaData": this.dataSource,
            "autoWidth": false,
            //'info' : true,
            //"bFilter": false,//Oculra input de busqueda // Se quita por que tampoco filtra por columnas
            "deferRender": true,
            "aoColumns": [ 
              { "mDataProp": "partida", "sClass": "text-center" },
              { "mDataProp": "nombre", "sClass": "text-center" }
            ],
            "columns": [
              { "width": "100%" },
              null,
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
        }else{
          this.mensajes.showWarning(respuesta.mensaje);
          //this.mensajes.showError(error.name);
        }
        //this.MuestraLoading.emit({show: false});
        
        this.loadingService.toggle();
    }, error => {
        //console.log(error);
        this.loadingService.toggle();
        this.mensajes.showError(error.message);
        //this.MuestraLoading.emit({show: false});
    });
  }
}
