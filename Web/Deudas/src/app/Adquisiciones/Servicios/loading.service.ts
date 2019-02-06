import { Injectable, Output, EventEmitter } from '@angular/core';

@Injectable()
export class LoadingService {

  constructor() { }

  show = false;

  @Output() change: EventEmitter<boolean> = new EventEmitter();
  
  toggle( pShow?:boolean ) {
    if(pShow != undefined && pShow != null)
      this.show = pShow;
    else      
      this.show = !this.show;
      
    this.change.emit(this.show);
  }
}
