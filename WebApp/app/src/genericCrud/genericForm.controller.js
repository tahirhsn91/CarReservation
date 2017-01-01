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
  function GenericFormCtrl($stateParams, store, genericCrudFactory, appModules, toast, lodash, $state){
    var vm = this;

    vm.maxDate = new Date();
    vm.currentUser = store.get('user');
    vm.module = $stateParams.moduleName;
    vm.recordId = $stateParams.id ? $stateParams.id : null;
    vm.pageTitle = genericCrudFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.currentUser.Role][vm.module];
    vm.choices = {};
    vm.data = {};
    
    vm.submit = submit;
    vm.checkString = checkString;
    vm.getFieldName = getFieldName;
    vm.getChoices = getChoices;
    vm.onSelect = onSelect;
    vm.redirect = redirect;

    function init() {
      fillChoices(vm.fields);
      if(vm.recordId){
        genericCrudFactory.getSingle(vm.module, vm.recordId).then(function(result){
          vm.data = result;
          processFields();
        });
      }
    }

    init();

    function submit(){
      genericCrudFactory.save(vm.module, vm.data).then(function(){
        toast.success(vm.module + ' module record ' + vm.data.Name + ' updated successfully');
        redirect('genericCrud.genericCrudList', {'moduleName': vm.module});
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
          if(value.Type ==='Date'){
            vm.data[value.Field] = vm.maxDate;
          }
          else if(value.Type ==='DropDown'){
            vm.data[value.Field] = {};
            vm.choices[value.Field] = [];
          }
          else if (value.Type ==='Number'){
            vm.data[value.Field] = 1;
          }
        }
      });
      genericCrudFactory.fillChoices(obj, vm.choices);
    }

    function processFields(){
      lodash.forEach(vm.fields, function(value){
        if(!checkString(value)){
          if(value.Type ==='Date'){
            vm.data[value.Field] = new Date(vm.data[value.Field]);
          }
        }
      });
    }

    function getChoices(obj){
      return vm.choices[obj.Field];
    }

    function onSelect(field){
      if(field.OnSelect){
        vm.data[field.OnSelect] = {};
        var param = '?filter['+field.Field+'Id]=' + vm.data[field.Field].Id;
        genericCrudFactory.getAll(field.OnSelect, param).then(function(result){
          vm.choices[field.OnSelect] = result;
        });
      }
    }

    function redirect(url, obj){
      genericCrudFactory.redirect(url, obj);
    }
    
  }

}());
