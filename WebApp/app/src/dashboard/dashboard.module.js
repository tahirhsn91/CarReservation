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
              role: appUserRole.Admin,
              views: {
                  'content@shell': {
                      templateUrl:'src/dashboard/dashboard.html',
                      controller: 'DashboardCtrl as vm'
                  }
              }
             })
            .state('shell.supervisor.dashboard', {
                url:'/dashboard',
                role: appUserRole.Supervisor,
                views: {
                    'content@shell.supervisor': {
                        templateUrl:'src/dashboard/dashboard.html',
                        controller: 'SupervisorDashboardCtrl as vm'
                    }
                }
            });
  }

}());
