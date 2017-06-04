/**
 * @ngdoc controller
 * @name app.genericCrud.controller:PackageListCtrl
 * @description Generic List Controller
 */

(function(){

  'use strict';

  angular.module('app.supervisor')
    .controller('AssignPackageListCtrl', AssignPackageListCtrl);

  /* @ngInject */
  function AssignPackageListCtrl($stateParams, $state, store, assignPackageFactory, appModules, toast){
    var vm = this;

    vm.currentUser = store.get('user');
    vm.module = 'Assign Vehicle';
    vm.pageTitle = assignPackageFactory.getModuleName(vm.module);

    vm.redirect = redirect;

    function init() {
        assignPackageFactory.getAll('Vehicle/GetVehicleWithPackageInfo').then(function(result){
        vm.data = result;
      });
    }

    init();

    function redirect(url, obj){
      assignPackageFactory.redirect(url, obj);
    }

  }

}());
