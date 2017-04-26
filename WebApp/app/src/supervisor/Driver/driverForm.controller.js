(function(){

  'use strict';

  angular.module('app.driver')
    .controller('DriverFormCtrl', DriverFormCtrl);

  /* @ngInject */
  function DriverFormCtrl($stateParams, store, driverFactory, appModules, toast, lodash, $state){
    var vm = this;

    vm.maxDate = new Date();
    vm.currentUser = store.get('user');
    vm.module = 'Driver';
    vm.recordId = $stateParams.id ? $stateParams.id : null;
    vm.pageTitle = driverFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.currentUser.Role][vm.module];
    vm.choices = {};
    vm.data = {};
    
    vm.submit = submit;
    vm.getChoices = getChoices;
    vm.onSelect = onSelect;
    vm.redirect = redirect;
    vm.addDetails = addDetails;
    vm.checkDriver = checkDriver;

    function init() {
      fillChoices(vm.fields);
      if(vm.recordId){
        driverFactory.getSingle(vm.module, vm.recordId).then(function(result){
          vm.data = result;
          processFields();
        });
      }
    }

    init();

    function submit(){
      driverFactory.save('Supervisor/AddDriver', vm.data).then(function(){
        toast.success(vm.module + ' module record ' + vm.data.Name + ' updated successfully');
        redirect('shell.supervisor.driver', {'moduleName': vm.module});
      });
    }

    function getChoices(obj){
      return vm.choices[obj.Field];
    }

    function onSelect(field){
      if(field.OnSelect){
        vm.data[field.OnSelect] = {};
        var param = '?filter['+field.Field+'Id]=' + vm.data[field.Field].Id;
        driverFactory.getAll(field.OnSelect, param).then(function(result){
          vm.choices[field.OnSelect] = result;
        });
      }
    }

    function redirect(url, obj){
      driverFactory.redirect(url, obj);
    }

    function addDetails(){
      if(!vm.data.TravelUnit){
        vm.data.TravelUnit = [];
      }

      vm.data.TravelUnit.push({
        'Rate': 1,
        'Currency': {},
        'TravelUnit': {}
      });
    }

    function checkDriver() {
      driverFactory.checkDriver(vm.data).then(function (result) {
          if(!result){
              toast.error('Driver not found or Associated with another supervisor');
              vm.data.User.Email = '';
          }
      }, function (error) {
          vm.data.User.Email = '';
      });
    }
  }

}());
