import { Component, ViewChild } from '@angular/core';
import { Nav, Events, MenuController, Platform } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';

import { HomePage } from '../pages/home/home';
import { ListPage } from '../pages/list/list';

import { AccountPage } from '../pages/account/account';
import { LoginPage } from '../pages/login/login';
import { TabsPage } from '../pages/tabs/tabs';
import { Lector } from '../pages/lector/lector';
import { Miqr } from '../pages/miqr/miqr';

import { ConferenceData } from '../providers/conference-data';
import { UserData } from '../providers/user-data';

import { Storage } from '@ionic/storage';

import { Auth } from '../providers/auth';

export interface PageObj {
  title: string;
  component: any;
  icon: string;
  logsOut?: boolean;
  index?: number;
}

@Component({
  templateUrl: 'app.html'
})
export class MyApp {
  @ViewChild(Nav) nav: Nav;

  appPages: PageObj[] = [
    { title: 'Horario', component: TabsPage, icon: 'calendar' },

    //{ title: 'Ponentes', component: TabsPage, index: 1, icon: 'contacts' },
    { title: 'Mi Qr', component: Miqr, index: 1, icon: 'barcode' },
    { title: 'Acerca de', component: TabsPage, index: 2, icon: 'map' },
    //{ title: 'Acerca de', component: TabsPage, index: 3, icon: 'information-circle' },
  ];
  loggedInPages: PageObj[] = [
    { title: 'Account', component: AccountPage, icon: 'person' },
    { title: 'Logout', component: TabsPage, icon: 'log-out', logsOut: true }
  ];
  loggedOutPages: PageObj[] = [
    { title: 'Cerrar sesión', component: LoginPage, icon: 'log-in' }
  ];

  logisticaPages: PageObj[] = [
    { title: 'Lector', component: Lector, icon: 'qr-scanner' }
  ];

  rootPage: any = Miqr;

  logis: string;

  isLogistica: boolean = false;

  constructor(public platform: Platform,
    public statusBar: StatusBar,
    public splashScreen: SplashScreen,
    public events: Events,
    public userData: UserData,
    public menu: MenuController,
    private storage: Storage,
    private auth: Auth,
    confData: ConferenceData) {
    this.initializeApp();


  }

  initializeApp() {
    this.platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      this.statusBar.styleDefault();
      this.splashScreen.hide();

      this.auth.getLogistica().then(isLogistica => {
        if (isLogistica == "SI") {
          //alert("log si")
          this.isLogistica = true;
        } else {
          //alert("Log no")
          this.isLogistica = false;
        }
      });

      

    });
  }

  cerrarSesion() {
    this.storage.set("USER_DATA", undefined);
    this.nav.setRoot(LoginPage);
    //this.storage.get(this.LOGISTIC);
  }

  openPage(page: PageObj) {
    // the nav component was found using @ViewChild(Nav)
    // reset the nav to remove previous pages and only have this page
    // we wouldn't want the back button to show in this scenario
    if (page.index) {
      this.nav.setRoot(page.component, { tabIndex: page.index });

    } else {
      this.nav.setRoot(page.component);
    }

    if (page.logsOut === true) {
      // Give the menu time to close before changing to logged out
      setTimeout(() => {
        this.userData.logout();
      }, 1000);
    }
  }

  listenToLoginEvents() {
    this.events.subscribe('user:login', () => {
      this.enableMenu(true);
    });

    this.events.subscribe('user:signup', () => {
      this.enableMenu(true);
    });

    this.events.subscribe('user:logout', () => {
      this.enableMenu(false);
    });
  }

  enableMenu(loggedIn) {
    this.menu.enable(loggedIn, 'loggedInMenu');
    this.menu.enable(!loggedIn, 'loggedOutMenu');
  }
}
