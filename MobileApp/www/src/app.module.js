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
    'app.shell',
    'app.auth',
    'app.customerDashboard',
    'app.driverDashboard',
    'app.rides',
    'app.wallet',
    'app.setting',
    'app.staticPages',
    'app.errorPages'
  ]);

}());
