import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-loguearse',
  templateUrl: './loguearse.component.html',
  styleUrls: ['./loguearse.component.css']
})
export class LoguearseComponent implements OnInit {
  form!:FormGroup;

  constructor(private formBuilder:FormBuilder,private myService:LoginService, private router:Router) {  
    this.form = formBuilder.group({
      email:['',[Validators.required, Validators.email]],
      password:['',[Validators.required]]
   })

  }
  get email(){
    return this.form.get("email");
  }
  get password(){
    return this.form.get("password");
  }

  ngOnInit(): void {
  }

  login(){
    if(this.form.valid){
      let email:string = this.form.get('email')?.value;
      let password:string = this.form.get('password')?.value;

      let login:Login = new Login(email, password);
      console.log("servicio corriendo");
      this.myService.iniciarSesion(login).subscribe({
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
  }
}

}