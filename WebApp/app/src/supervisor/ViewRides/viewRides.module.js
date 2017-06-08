/**
 * @ngdoc overview
 * @name app.supervisor
 * @description < description placeholder >
 */

(function(){

  'use strict';

  angular
    .module('app.viewRides', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider, appUserRole){

    $stateProvider
      .state('shell.supervisor.viewRides', {
        url:'/viewRides',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/ViewRides/viewRides.html',
                controller: 'ViewRidesCtrl as vm'
            }
        }
      })
      .state('shell.supervisor.viewRides.details', {
        url:'/:id',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/AssignPackage/viewRidesDetails.html',
                controller: 'ViewRideDetailsCtrl as vm'
            }
        }
      });
  }

}());
