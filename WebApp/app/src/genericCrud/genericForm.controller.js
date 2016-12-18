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
  function GenericFormCtrl($stateParams, genericCrudFactory, appModules, toast, lodash, $state){
    var vm = this;

    vm.module = $stateParams.moduleName;
    vm.recordId = $stateParams.id ? $stateParams.id : null;
    vm.pageTitle = genericCrudFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.module];
    vm.choices = {};
    vm.data = {};
    
    vm.submit = submit;
    vm.checkString = checkString;
    vm.getFieldName = getFieldName;
    vm.getChoices = getChoices;

    function init() {
      fillChoices(vm.fields);
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

    function checkString(data){
      return genericCrudFactory.checkString(data);
    }

    function getFieldName(data){
      return genericCrudFactory.getFieldName(data);
    }

    function fillChoices(obj) {
      lodash.forEach(vm.fields, function(value){
        if(!checkString(value)){
          vm.data[value.Field] = {};
          vm.choices[value.Field] = [];
        }
      });
      genericCrudFactory.fillChoices(obj, vm.choices);
    }

    function getChoices(obj){
      return vm.choices[obj.Field];
    }
  }

}());
