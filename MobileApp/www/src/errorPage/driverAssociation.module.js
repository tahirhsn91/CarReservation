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
      .state('driverAssociation', {
        url:'/driverAssociationError',
        templateUrl:'src/errorPage/driverAssociation.html',
        controller: 'DriverAssociationCtrl as vm'
      });
  }

}());
