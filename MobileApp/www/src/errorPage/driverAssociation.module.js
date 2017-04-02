/**
 * @ngdoc overview
 * @name app.setting
 * @description Setting module
 */

(function(){

  angular.module('app.errorPages', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider){

    $stateProvider
      .state('shell.driverAssociation', {
        url:'/driverAssociationError',
        views: {
          'menuContent': {
            templateUrl:'src/errorPages/driverAssociation.html',
            controller: 'DriverAssociationCtrl as vm',
          }
        }
      });
  }

}());
