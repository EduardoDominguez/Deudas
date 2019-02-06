import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import {NgbDate, NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-datepciker-range',
  templateUrl: './datepciker-range.component.html',
  styleUrls: ['./datepciker-range.component.css']
})
export class DatepcikerRangeComponent implements OnInit {

  hoveredDate: NgbDate;

  public fromDate: NgbDate;
  public toDate: NgbDate;

  @Output() rangoValido = new EventEmitter<boolean>();
  @Input() fechaInicial;
  @Input() fechaFinal;

  constructor(calendar: NgbCalendar) { 
    /*this.fromDate = calendar.getToday();
    this.toDate = calendar.getNext(calendar.getToday(), 'd', 10);*/
  }

  ngOnInit() {
    this.fromDate = null; 
    this.toDate = null;
  }

  onDateSelection(date: NgbDate) {
    if (!this.fromDate && !this.toDate) {
      this.fromDate = date;
    } else if (this.fromDate && !this.toDate && date.after(this.fromDate)) {
      this.toDate = date;
    } else {
      this.toDate = null;
      this.fromDate = date;
    }

    this.rangoValido.emit(this.toDate != null && this.fromDate != null);
    /*console.log(this.toDate);
    console.log(this.fromDate);*/
  }

  isHovered(date: NgbDate) {
    return this.fromDate && !this.toDate && this.hoveredDate && date.after(this.fromDate) && date.before(this.hoveredDate);
  }

  isInside(date: NgbDate) {
    return date.after(this.fromDate) && date.before(this.toDate);
  }

  isRange(date: NgbDate) {
    return date.equals(this.fromDate) || date.equals(this.toDate) || this.isInside(date) || this.isHovered(date);
  }
  
  public clearDate(){
    this.toDate = null;
    this.fromDate = null;
  }

  public getFormatNameRange():string{
    let Formato:string;
    if(this.toDate != null){
      Formato = `Del ${this.fromDate.day}-${this.getMonthName(this.fromDate.month)}-${this.fromDate.year} `;
    }
    if(this.fromDate != null)
    {
      Formato += ` hasta ${this.toDate.day}-${this.getMonthName(this.toDate.month)}-${this.toDate.year}`
    }

    return Formato;
  }

  getMonthName(pMonth:number):string{

    switch(pMonth){
      case 1:
        return "Enero";
      case 2:
        return "Febrero";
      case 3:
        return "Marzo";
      case 4:
        return "Abril";
      case 5:
        return "Mayo";
      case 6:
        return "Junio";
      case 7:
        return "Julio";
      case 8:
        return "Agosto";
      case 9:
        return "Septiembre";
      case 10:
        return "Octubre";
      case 11:
        return "Noviembre";
      case 12:
        return "Diciembre";
      default:
        return "";
    }
    return "";
  }
  

}
