/**
 * @ngdoc controller
 * @name app.genericCrud.controller:GenericFormCtrl
 * @description Generic Form Controller
 */

(function(){

  'use strict';

  angular.module('app.genericCrud')
    .controller('GenericFormCtrl', GenericFormCtrl);

  /* @ngInject */
  function GenericFormCtrl($stateParams, genericCrudFactory, appModules, toast, $state){
    var vm = this;

    vm.module = $stateParams.moduleName;
    vm.recordId = $stateParams.id ? $stateParams.id : null;
    vm.pageTitle = genericCrudFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.module];
    
    vm.submit = submit;

    function init() {
      if(vm.recordId){
        genericCrudFactory.getSingle(vm.module, vm.recordId).then(function(result){
          vm.data = result;
        });
      }
    }

    init();

    function submit(){
      genericCrudFactory.save(vm.module, vm.data).then(function(){
        toast.success(vm.module + 'module record ' + vm.data.Name + ' updated successfully');
        $state.go('shell.genericCrud.genericCrudList', {'moduleName': vm.module});
      });
    }

  }

}());
