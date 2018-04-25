import { Component } from '@angular/core';

import { PopoverController } from 'ionic-angular';

@Component({
  selector: 'page-about',
  templateUrl: 'about.html'
})
export class AboutPage {
  conferenceDate = '2017-11-01';

  constructor(public popoverCtrl: PopoverController) { }
}
