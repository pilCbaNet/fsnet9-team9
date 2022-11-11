import { Component, OnInit } from '@angular/core';
import { MovimientosService } from 'src/app/services/movimientos.service';

@Component({
  selector: 'app-movimientos',
  templateUrl: './movimientos.component.html',
  styleUrls: ['./movimientos.component.css']
})
export class MovimientosComponent implements OnInit {

  movimientos:any; 
  constructor(private miServicio:MovimientosService) { }

  ngOnInit(): void {
    this.miServicio.obtenerMovimientos().subscribe(data => {
      console.log(data);
      this.movimientos=data;
    })
  }

}
