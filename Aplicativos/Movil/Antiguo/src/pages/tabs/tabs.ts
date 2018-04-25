import { Component } from '@angular/core';

import { NavParams } from 'ionic-angular';

import { AboutPage } from '../about/about';
import { SchedulePage } from '../schedule/schedule';
import { SpeakerListPage } from '../speaker-list/speaker-list';
import { Miqr } from '../miqr/miqr';

import { LoginPage } from '../login/login';
import { Auth } from '../../providers/auth';


@Component({
  templateUrl: 'tabs.html'
})
export class TabsPage {
  // set the root pages for each tab
  tab1Root: any = SchedulePage;
  tab2Root: any = Miqr;
  tab4Root: any = AboutPage;
  mySelectedIndex: number;

  constructor(navParams: NavParams, private auth: Auth) {
    this.mySelectedIndex = navParams.data.tabIndex || 0;

    

  }
}
