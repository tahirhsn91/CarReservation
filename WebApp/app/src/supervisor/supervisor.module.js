/**
 * @ngdoc overview
 * @name app.supervisor
 * @description < description placeholder >
 */

(function(){

  'use strict';

  angular
    .module('app.supervisor', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider, appUserRole){

    $stateProvider
     .state('shell.supervisor', {
      url:'supervisor',
      role: appUserRole.Supervisor,
      views: {
          '@': {
              templateUrl: 'src/shell/shell.html',
              controller: 'ShellCtrl as vm'
          },
          'topNavBar@shell.supervisor': {
              templateUrl:'src/shell/topNavBar.html',
              controller: 'TopNavBarCtrl as vm'
          },
          'sideBar@shell.supervisor': {
              templateUrl:'src/supervisor/shell/sideBar.html',
              controller: 'SupSideBarCtrl as vm'
          }
      }
     })
     .state('shell.supervisor.genericCrud', {
        url:'/module',
        role: appUserRole.Supervisor
      })
     .state('shell.supervisor.genericCrud.genericCrudList', {
        url:'/:moduleName',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/genericCrud/list.html',
                controller: 'GenericListCtrl as vm'
            }
        }
     })
     .state('shell.supervisor.genericCrud.genericCrudDetail', {
        url:'/:moduleName/detail/:id',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/genericCrud/detail.html',
                controller: 'GenericDetailCtrl as vm'
            }
        }
     })
     .state('shell.supervisor.genericCrud.genericCrudCreate', {
        url:'/:moduleName/new',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/genericCrud/form.html',
                controller: 'GenericFormCtrl as vm'
            }
        }
     })
     .state('shell.supervisor.genericCrud.genericCrudEdit', {
        url:'/:moduleName/edit/:id',
        role: appUserRole.Supervisor,
        views: {
            'content@shell.supervisor': {
                templateUrl:'src/genericCrud/form.html',
                controller: 'GenericFormCtrl as vm'
            }
        }
     })
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
     .state('shell.supervisor.package.viewdetail', {
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
