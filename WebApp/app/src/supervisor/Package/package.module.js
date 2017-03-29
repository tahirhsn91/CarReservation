/**
 * @ngdoc overview
 * @name app.supervisor
 * @description < description placeholder >
 */

(function(){

  'use strict';

  angular
    .module('app.package', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider, appUserRole){

    $stateProvider
      .state('shell.supervisor.package', {
        url:'/package',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/Package/packageList.html',
                controller: 'PackageListCtrl as vm'
            }
        }
      })
      .state('shell.supervisor.package.detail', {
        url:'/detail/:id',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/Package/packageDetail.html',
                controller: 'PackageDetailCtrl as vm'
            }
        }
      })
      .state('shell.supervisor.package.create', {
        url:'/new',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/Package/packageForm.html',
                controller: 'PackageFormCtrl as vm'
            }
        }
      })
      .state('shell.supervisor.package.edit', {
        url:'/edit/:id',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/supervisor/Package/packageForm.html',
                controller: 'PackageFormCtrl as vm'
            }
        }
      });
  }

}());
