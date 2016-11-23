/**
 * @ngdoc overview
 * @name app.customerDashboard
 * @description Customer Dashboard module
 */

(function(){

  angular.module('app.customerDashboard', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider){

    $stateProvider
      .state('shell.customerDashboard', {
        url:'/customer-dashboard',
        views: {
          'menuContent': {
            templateUrl:'src/dashboard/customer/customerDashboard.html',
            controller: 'CustomerDashboardCtrl as vm',
          }
        }
      });
  }

}());
