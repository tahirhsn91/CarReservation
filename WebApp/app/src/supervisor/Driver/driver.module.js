/**
 * @ngdoc overview
 * @name app.supervisor
 * @description < description placeholder >
 */

(function(){

  'use strict';

  angular
    .module('app.driver', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider, appUserRole){

    $stateProvider
      .state('shell.supervisor.driver', {
        url:'/driver',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/Driver/driverList.html',
                controller: 'driverListCtrl as vm'
            }
        }
      })
      .state('shell.supervisor.driver.detail', {
        url:'/detail/:id',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/Driver/driverDetail.html',
                controller: 'DriverDetailCtrl as vm'
            }
        }
      })
      .state('shell.supervisor.driver.create', {
        url:'/new',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/Driver/driverForm.html',
                controller: 'DriverFormCtrl as vm'
            }
        }
      })
      .state('shell.supervisor.driver.edit', {
        url:'/edit/:id',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/Driver/driverForm.html',
                controller: 'DriverFormCtrl as vm'
            }
        }
      });
  }

}());
