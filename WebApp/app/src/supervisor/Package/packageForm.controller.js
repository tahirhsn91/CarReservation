/**
 * @ngdoc controller
 * @name app.genericCrud.controller:PackageFormCtrl
 * @description Generic Form Controller
 */

(function(){

  'use strict';

  angular.module('app.supervisor')
    .controller('PackageFormCtrl', PackageFormCtrl);

  /* @ngInject */
  function PackageFormCtrl($stateParams, store, packageFactory, appModules, toast, lodash, $state){
    var vm = this;

    vm.maxDate = new Date();
    vm.currentUser = store.get('user');
    vm.module = 'Package';
    vm.recordId = $stateParams.id ? $stateParams.id : null;
    vm.pageTitle = packageFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.currentUser.Role][vm.module];
    vm.choices = {};
    vm.data = {};
    
    vm.submit = submit;
    vm.checkString = checkString;
    vm.getFieldName = getFieldName;
    vm.getChoices = getChoices;
    vm.onSelect = onSelect;
    vm.redirect = redirect;
    vm.addDetails = addDetails;

    function init() {
      fillChoices(vm.fields);
      if(vm.recordId){
        packageFactory.getSingle(vm.module, vm.recordId).then(function(result){
          vm.data = result;
          processFields();
        });
      }
    }

    init();

    function submit(){
      packageFactory.save(vm.module, vm.data).then(function(){
        toast.success(vm.module + ' module record ' + vm.data.Name + ' updated successfully');
        redirect('genericCrud.genericCrudList', {'moduleName': vm.module});
      });
    }

    function checkString(data){
      return packageFactory.checkString(data);
    }

    function getFieldName(data){
      return packageFactory.getFieldName(data);
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
      packageFactory.fillChoices(obj, vm.choices);
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
        packageFactory.getAll(field.OnSelect, param).then(function(result){
          vm.choices[field.OnSelect] = result;
        });
      }
    }

    function redirect(url, obj){
      packageFactory.redirect(url, obj);
    }

    function addDetails(){
      if(!vm.data.TravelUnit){
        vm.data.TravelUnit = [];
      }

      vm.data.TravelUnit.push({
        'Rate': 1,
        'Currency': {},
        'TravelUnit': {}
      })
    }
    
  }

}());
