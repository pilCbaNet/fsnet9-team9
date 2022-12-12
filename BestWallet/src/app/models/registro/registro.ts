export class Register{
  Nombre: string;
  Apellido: string;
  Dni: number;
  Teléfono : number;
  FechaNac: Date;
  Email: string;
  Password: string;

  constructor(Nombre: string,Apellido: string,Dni: number,Teléfono : number, FechaNac: Date,Email: string,Password: string){
    this.Nombre = Nombre;
    this.Apellido = Apellido;
    this.Email = Email;
    this.Dni = Dni;
    this.Teléfono = Teléfono;
    this.FechaNac = FechaNac;
    this.Password = Password;
  }
}