/**
 * @ngdoc controller
 * @name app.genericCrud.controller:GenericDetailCtrl
 * @description Generic Detail Controller
 */

(function(){

  'use strict';

  angular.module('app.genericCrud')
    .controller('GenericDetailCtrl', GenericDetailCtrl);

  /* @ngInject */
  function GenericDetailCtrl($stateParams, genericCrudFactory, appModules, toast){
    var vm = this;

    vm.module = $stateParams.moduleName;
    vm.recordId = $stateParams.id;
    vm.pageTitle = genericCrudFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.module];

    vm.deleteRecord = deleteRecord;
  
    function init() {
      genericCrudFactory.getSingle(vm.module, vm.recordId).then(function(result){
        vm.data = result;
      });
    }
    
    vm.checkString = checkString;
    vm.getFieldName = getFieldName;

    init();

    function deleteRecord(){
      genericCrudFactory.remove(vm.module, vm.recordId).then(function(){
        toast.success(vm.module + 'module record ' + vm.data.Name + ' deleted successfully');
        $state.go('shell.genericCrud.genericCrudList', {'moduleName': vm.module});
      });
    }

    function checkString(data){
      return genericCrudFactory.checkString(data);
    }

    function getFieldName(data){
      return genericCrudFactory.getFieldName(data);
    }

  }

}());
