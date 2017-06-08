(function(){

  'use strict';

  angular.module('app.supervisor')
    .controller('ViewRideDetailsCtrl', ViewRideDetailsCtrl);

  /* @ngInject */
  function ViewRideDetailsCtrl($stateParams, store, assignPackageFactory, appModules, toast, lodash, $state){
    var vm = this;

    vm.maxDate = new Date();
    vm.currentUser = store.get('user');
    vm.module = 'Assign Vehicle';
    vm.recordId = $stateParams.id ? $stateParams.id : null;
    vm.pageTitle = assignPackageFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.currentUser.Role][vm.module];
    vm.choices = {};
    vm.data = {};
    
    vm.submit = submit;
    vm.getChoices = getChoices;
    vm.onSelect = onSelect;
    vm.redirect = redirect;

    function init() {
      if(vm.recordId){
        assignPackageFactory.getAll('Vehicle/GetVehicleWithPackageInfo/' + vm.recordId).then(function(result){
          vm.data = result;
        });
        assignPackageFactory.getAll('Package').then(function(result){
          vm.package = result;
        });
        assignPackageFactory.getAll('Supervisor/GetDrivers').then(function(result){
          vm.driver = result;
        });
      }
    }

    init();

    function submit(){
        assignPackageFactory.save(vm.data).then(function(){
        toast.success('Package successfully assigned');
        redirect('shell.supervisor.assignPackage');
      });
    }

    function getChoices(obj){
      return vm.choices[obj.Field];
    }

    function onSelect(field){
      if(field.OnSelect){
        vm.data[field.OnSelect] = {};
        var param = '?filter['+field.Field+'Id]=' + vm.data[field.Field].Id;
          assignPackageFactory.getAll(field.OnSelect, param).then(function(result){
          vm.choices[field.OnSelect] = result;
        });
      }
    }

    function redirect(url, obj){
      assignPackageFactory.redirect(url, obj);
    }
  }

}());
