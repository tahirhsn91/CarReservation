/**
 * @ngdoc overview
 * @name app.dashboard
 * @description < description placeholder >
 */

(function(){

  'use strict';

  angular
    .module('app.dashboard', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider, appUserRole){

    $stateProvider
     .state('shell.dashboard', {
      url:'dashboard',
      role: appUserRole.All,
      views: {
          'content@shell': {
              templateUrl:'src/dashboard/dashboard.html',
              controller: 'DashboardCtrl as vm'
          }
      }
     });
  }

}());
