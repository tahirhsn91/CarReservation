/**
 * @ngdoc overview
 * @name app.driverDashboard
 * @description Driver Dashboard module
 */

(function(){

  angular.module('app.driverDashboard', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider){

    $stateProvider
      .state('shell.driverDashboard', {
        url:'/driver-dashboard',
        views: {
          'menuContent': {
            templateUrl:'src/dashboard/driver/driverDashboard.html',
            controller: 'DriverDashboardCtrl as vm',
          }
        }
      });
  }

}());
