import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { Storage } from '@ionic/storage';

/*
  Inicio de sesion

*/
@Injectable()
export class Auth {

  data: any;
  private USER_DATA: string = 'USER_DATA';
  private LOGISTIC: string = 'LOGISTICA';

  url: string = 'http://200.21.7.94/simposio/api/'

  constructor(
    public http: Http,
    public storage: Storage) {

    console.log('Hello Auth Provider');
    //this.signout();
  }

  login(email: string, password: string) {
    var body = {
      "username": email,
      "contraseña": password
    }

    return new Promise((resolve, reject) => {
      this.http.post(this.url + 'usuario/select_usuario', body)
        .map(res => res.json())
        .subscribe(values => {
          this.data = values;

          if (values.result) {
            //alert('Data: '+ JSON.stringify(values.data[0]));
            this.storage.set(this.USER_DATA, values.data[0]);
            this.storage.set(this.LOGISTIC, values.logistica);

            if (values.logistica) {
              //alert("it's true")
              this.storage.set("LOGIST", "SI");
            } else {
              //alert("it's false")
              this.storage.set("LOGIST", "NO");
            }

            resolve(this.data);
          } else {
            alert("Datos incorrectos")
            reject('Error de peticion.');
          }
        });
    });
  }

  getData() {
    return this.storage.get(this.USER_DATA);
  }

  /*getLogistica() {
    return this.storage.get(this.LOGISTIC);
  }*/

  getLogistica() {
    return this.storage.get("LOGIST");
  }


  signout() {
    this.storage.set(this.USER_DATA, undefined);
  }

  qr() {
    return new Promise((resolve, reject) => {
      this.http.post(this.url + 'usuario/select_usuario', {})
        .map(res => res.json())
        .subscribe(values => {
          this.data = values;

          if (values.result) {
            this.storage.set(this.USER_DATA, values.data);

            resolve(this.data);
          } else {
            reject('Error de peticion.');
          }
        });
    });
  }
}
