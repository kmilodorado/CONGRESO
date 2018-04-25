import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

import { Auth } from '../../providers/auth';
import { Storage } from '@ionic/storage';

import { LoginPage } from '../login/login';
/*
  Generated class for the Miqr page.
*/
@Component({
  selector: 'page-miqr',
  templateUrl: 'miqr.html'
})
export class Miqr {

  public url_src: string = '';
  public title: string;
  public name: string;
  rol: string;

  logeado: boolean = false;

  constructor(
    public navCtrl: NavController,
    public auth: Auth,
    private storage: Storage
  ) {



  }

  ionViewDidLoad() {

    this.auth.getData().then(value => {
      //alert(JSON.stringify(value))
      if (value == null || value.idPersona == null) {
        this.logeado = false;
        //alert("Debe autenticarse nuevamente")
        this.navCtrl.push(LoginPage);

      } else {
        console.log('Hello Miqr Page');
        this.logeado = true;
        this.auth.getData().then(value => {
          let url = 'http://200.21.7.94/simposio/Qr/' + (value.idPersona || value.FK_idPersona) + '.png';

          this.url_src = url;
          this.title = value.Correo;
          this.name = value.Nombres + ' ' + value.Apellidos;
          this.rol = "Asistente"
        }).catch(err => {

        })
      }
    }).catch(err => {

    })


  }

}
