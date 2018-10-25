import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo() {
    return browser.get('/');
  }

  getNavbarMainElementText() {
    return element(by.id('navbar-main-elelement')).getText();
  }
}
