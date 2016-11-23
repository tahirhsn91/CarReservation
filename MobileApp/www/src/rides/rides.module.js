/**
 * @ngdoc overview
 * @name app.rides
 * @description Rides module
 */

(function(){

  angular.module('app.rides', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider){

    $stateProvider
      .state('shell.rides', {
        url:'/rides',
        views: {
          'menuContent': {
            templateUrl:'src/rides/rides.html',
            controller: 'RidesCtrl as vm',
          }
        }
      });
  }

}());
