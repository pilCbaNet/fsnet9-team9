import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Register } from 'src/app/models/registro/registro';
import { RegistrarService } from 'src/app/services/registrar.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  formR! : FormGroup;
  
  constructor(private formBuilder:FormBuilder, private myService:RegistrarService, private router:Router) {
    this.formR = formBuilder.group({
      nombre:['',[Validators.required]],
      apellido:['',[Validators.required]],
      dni:['',[Validators.required]],
      telefono:['',[Validators.required]],
      fechaNacimiento:['',[Validators.required]],
      email:['',[Validators.required,Validators.email]],
      password:['',[Validators.required]]
   })
  }

  get nombre(){
    return this.formR.get("nombre");
  }
  get apellido(){
    return this.formR.get("apellido");
  }
  get dni(){
    return this.formR.get("dni");
  }
  get telefono(){
    return this.formR.get("telefono");
  }
  get fechaNacimiento(){
    return this.formR.get("fechaNacimiento");
  }
  get email(){
    return this.formR.get("email");
  }
  get password(){
    return this.formR.get("password");
  }

  ngOnInit() {
  }

  register() {
    if (this.formR.valid)
    {
      let nombre:string = this.formR.get('nombre')?.value;
      let apellido:string = this.formR.get('apellido')?.value;
      let dni:number = this.formR.get('dni')?.value;
      let telefono: number = this.formR.get('telefono')?.value;
      let fechaNacimiento : Date = this.formR.get('fechaNacimiento')?.value;
      let email:string = this.formR.get('email')?.value;
      let password:string = this.formR.get('password')?.value;


      let register:Register = new Register(nombre,apellido,dni,telefono,fechaNacimiento,email,password);
      console.log("servicio corriendo");
      this.myService.crearRegistro(register).subscribe({
        next:(data) =>{
          console.log(data);
          if (data!= null)
          {
            console.log(data);
            this.router.navigate(['movimientos']);
          }
          else
          {
            alert("Ups.verifique su identidad")
          }
        },
        error:(e) =>{alert("ups, error inesperado")}
      })
      //this.formR.reset
    }
    else{
      //this.formR.markAllAsTouched();
    }
  }
}
