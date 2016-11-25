/**
 * @ngdoc controller
 * @name app.genericCrud.controller:GenericListCtrl
 * @description Generic List Controller
 */

(function(){

  'use strict';

  angular.module('app.genericCrud')
    .controller('GenericListCtrl', GenericListCtrl);

  /* @ngInject */
  function GenericListCtrl($stateParams, genericCrudFactory, appModules){
    var vm = this;

    vm.module = $stateParams.moduleName;
    vm.pageTitle = genericCrudFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.module];

    vm.deleteRecord = deleteRecord;

    function init() {
      genericCrudFactory.getAll(vm.module).then(function(result){
        vm.data = result;
      });
    }

    init();

    function deleteRecord(record){
      genericCrudFactory.remove(vm.module, record.Id).then(function(){
        toast.success(vm.module + 'module record ' + vm.data.Name + ' deleted successfully');
        var index = vm.data.indexOf(record);
        vm.data.splice(index, 1);
      });
    }
    
  }

}());
