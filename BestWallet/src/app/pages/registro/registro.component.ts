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
  form! : FormGroup;
  
  constructor(private formBuilder:FormBuilder, private myService:RegistrarService, private router:Router) {
    this.form = this.formBuilder.group({
      nombre:['',[Validators.required]],
      apellido:['',[Validators.required]],
      dni:['',[Validators.required]],
      telefono:['',[Validators.required]],
      fechaNacimiento:['',[Validators.required]],
      email:['',[Validators.required,Validators.email]],
      password:['',[Validators.required]]
   })
  }

  get Nombre(){
    return this.form.get("nombre");
  }
  get Apellido(){
    return this.form.get("apellido");
  }
  get DNI(){
    return this.form.get("dni");
  }
  get Telefono(){
    return this.form.get("telefono");
  }
  get FechaNacimiento(){
    return this.form.get("fechaNacimiento");
  }
  get Email(){
    return this.form.get("email");
  }
  get Password(){
    return this.form.get("password");
  }

  ngOnInit() {
  }

  register() {
    if (this.form.valid)
    {
      let Nombre:string = this.form.get('nombre')?.value;
      let Apellido:string = this.form.get('apellido')?.value;
      let Dni:string = this.form.get('dni')?.value;
      let Teléfono: string = this.form.get('telefono')?.value;
      let FechaNac : Date = this.form.get('fechaNacimiento')?.value;
      let Email:string = this.form.get('email')?.value;
      let Password:string = this.form.get('password1')?.value;

      let register:Register = new Register(Nombre,Apellido,Dni,Teléfono,FechaNac,Email,Password);
      
      this.myService.crearRegistro(register).subscribe({
        next:(data) =>{
          console.log(data);
          if (data!= null)
          {
            this.router.navigate(['movimientos']);
          }
          else
          {
            alert("Ups.verifique su identidad")
          }
        },
        error:(e) =>{alert("ups, error inesperado")}
      })
      this.form.reset
    }
    else{
      this.form.markAllAsTouched();
    }
  }
}
