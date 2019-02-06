import { Component, OnInit, ViewChild } from '@angular/core';
import { Constantes } from '../../Clases/Constantes';
import { Usuario } from '../../Clases/Usuario';

import { CatalogosService } from '../../Servicios/catalogos.service';
import { LoadingService } from '../../Servicios/loading.service';
import {MensajesService} from "../../../Servicios/mensajes.service";


declare var $;


@Component({
  selector: 'app-usuarios-roles',
  templateUrl: './usuarios-roles.component.html',
  styleUrls: ['./usuarios-roles.component.css']
})
export class UsuariosRolesComponent implements OnInit {

  @ViewChild('dataTable') table;
  dataTable: any;
  dtOption : any;
  private dataSource :Usuario[];
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
      this.getUsuarios();
    });
  }

  private getUsuarios(){
    this.loadingService.toggle();
    //console.log(this.CONSTANTES.getConfigLenguajeDatatable());
    this.catalogoService.getUsuarios().subscribe(
      respuesta  => {
        if(respuesta.estatus == true){
          this.dataSource = respuesta.data.usuarios_roles;
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
            { "mDataProp": "cl_usuario", "sClass": "text-center" },
            { "mDataProp": "nombre_completo", "sClass": "text-center" },
            { "mDataProp": "correo", "sClass": "text-center" },
            { "mDataProp": "rol", "sClass": "text-center" },
          ],
          "order": [[ 1, "asc" ]],
          "language" : this.CONSTANTES.getConfigLenguajeDatatable()
        };
        //console.log(this.dataSource);
        this.dataTable.DataTable(this.dtOption);
       
        }else
          this.mensajes.showWarning(respuesta.mensaje);

        
        this.loadingService.toggle();
        
    }, error => {
        this.mensajes.showError(error.message);
        this.loadingService.toggle();
    });
  }

}
