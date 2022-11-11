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
      email:['',[Validators.required,Validators.email]],
      password1:['',[Validators.required]],
      password2:['',[Validators.required]],
   })
  }

  get nombre(){
    return this.form.get("nombre");
  }
  get apellido(){
    return this.form.get("apellido");
  }
  get email(){
    return this.form.get("email");
  }
  get password1(){
    return this.form.get("password");
  }
  get password2(){
    return this.form.get("password");
  }



  ngOnInit() {
  }

  register() {
    if (this.form.valid)
    {
      let nombre:string = this.form.get('nombre')?.value;
      let apellido:string = this.form.get('apellido')?.value;
      let email:string = this.form.get('email')?.value;
      let password1:string = this.form.get('password1')?.value;
      let password2:string = this.form.get('password2')?.value;

      let register:Register = new Register(nombre,apellido,email,password1,password2);
      
      this.myService.crearRegistro(register).subscribe(data=>{
        this.router.navigate(['movimientos']);
      })
      this.form.reset
    }
    else{
      this.form.markAllAsTouched();
    }
  }
}
