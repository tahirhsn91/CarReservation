/**
 * @ngdoc overview
 * @name app
 * @description Glue to where all the greatness begins
 */

(function(){

  'use strict';

  angular.module('app', [
    'app.core',
    'app.common',
  /**
    * Application modules
  **/
    'app.shell',
    'app.auth',
    'app.customerDashboard',
    'app.driverDashboard',
    'app.rides',
    'app.wallet',
    'app.setting',
    'app.staticPages'
  ]);

}());