/**
 * @ngdoc controller
 * @name app.genericCrud.controller:GenericDetailCtrl
 * @description Generic Detail Controller
 */

(function(){

  'use strict';

  angular.module('app.supervisor')
    .controller('DriverDetailCtrl', DriverDetailCtrl);

  /* @ngInject */
  function DriverDetailCtrl($stateParams, $state, store, driverFactory, appModules, toast, appFormats, lodash){
    var vm = this;

    vm.currentUser = store.get('user');
    vm.module = 'Driver';
    vm.recordId = $stateParams.id;
    vm.pageTitle = driverFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.currentUser.Role][vm.module];
    vm.appFormats = appFormats;

    vm.deleteRecord = deleteRecord;
  
    function init() {
      driverFactory.getSingle(vm.module, vm.recordId).then(function(result){
        vm.data = result;
      });
    }

    vm.redirect = redirect;

    init();

    function deleteRecord(){
      driverFactory.remove(vm.module, vm.recordId).then(function(){
        toast.success(vm.module + 'module record ' + vm.data.Name + ' deleted successfully');
        redirect('genericCrud.genericCrudList', {'moduleName': vm.module});
      });
    }

    function redirect(url, obj){
      driverFactory.redirect(url, obj);
    }

  }

}());
