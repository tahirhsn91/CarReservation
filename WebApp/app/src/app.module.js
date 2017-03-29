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
    'app.auth',
    'app.shell',
    'app.genericCrud',
    'app.dashboard',
    'app.supervisor',
    'app.package'
  ]);

}());
