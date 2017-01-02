/**
 * @ngdoc overview
 * @name app.genericCrud
 * @description generic Crud for most modules.
 */

(function(){

  angular.module('app.genericCrud', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider, appUserRole){

    $stateProvider
      .state('shell.genericCrud', {
        url:'module',
        role: appUserRole.Admin
      })
      .state('shell.genericCrud.genericCrudList', {
        url:'/:moduleName',
        role: appUserRole.Admin,
        views: {
            'content@shell': {
                templateUrl:'src/genericCrud/list.html',
                controller: 'GenericListCtrl as vm'
            }
        }
      })
      .state('shell.genericCrud.genericCrudDetail', {
        url:'/:moduleName/detail/:id',
        role: appUserRole.Admin,
        views: {
            'content@shell': {
                templateUrl:'src/genericCrud/detail.html',
                controller: 'GenericDetailCtrl as vm'
            }
        }
      })
      .state('shell.genericCrud.genericCrudCreate', {
        url:'/:moduleName/new',
        role: appUserRole.Admin,
        views: {
            'content@shell': {
                templateUrl:'src/genericCrud/form.html',
                controller: 'GenericFormCtrl as vm'
            }
        }
      })
      .state('shell.genericCrud.genericCrudEdit', {
        url:'/:moduleName/edit/:id',
        role: appUserRole.Admin,
        views: {
            'content@shell': {
                templateUrl:'src/genericCrud/form.html',
                controller: 'GenericFormCtrl as vm'
            }
        }
      });
  }

}());
