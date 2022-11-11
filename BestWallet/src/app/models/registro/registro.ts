export class Register{
  nombre: string;
  apellido: string;
  email: string;
  password1: string;
  password2: string;

  constructor(nombre: string,apellido: string,email: string,password1: string, password2: string){
    this.nombre = nombre;
    this.apellido = apellido;
    this.email = email;
    this.password1 = password1;
    this.password2 = password2;
  }
}