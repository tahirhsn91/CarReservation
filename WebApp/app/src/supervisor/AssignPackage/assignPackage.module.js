/**
 * @ngdoc overview
 * @name app.supervisor
 * @description < description placeholder >
 */

(function(){

  'use strict';

  angular
    .module('app.assignPackage', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider, appUserRole){

    $stateProvider
      .state('shell.supervisor.assignPackage', {
        url:'/assignPackage',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/AssignPackage/assignPackageList.html',
                controller: 'AssignPackageListCtrl as vm'
            }
        }
      })
      .state('shell.supervisor.assignPackage.edit', {
        url:'/edit/:id',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/AssignPackage/assignPackageForm.html',
                controller: 'AssignPackageFormCtrl as vm'
            }
        }
      });
  }

}());
