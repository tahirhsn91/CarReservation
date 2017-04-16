/**
 * @ngdoc controller
 * @name app.genericCrud.controller:PackageListCtrl
 * @description Generic List Controller
 */

(function(){

  'use strict';

  angular.module('app.supervisor')
    .controller('driverListCtrl', DriverListCtrl);

  /* @ngInject */
  function DriverListCtrl($stateParams, $state, store, driverFactory, appModules, toast){
    var vm = this;

    vm.currentUser = store.get('user');
    vm.module = 'Driver';
    vm.pageTitle = driverFactory.getModuleName(vm.module);

    vm.checkString = checkString;
    vm.getFieldName = getFieldName;
    vm.redirect = redirect;

    function init() {
      driverFactory.getAll('Supervisor/GetDrivers').then(function(result){
        vm.data = result;
      });
    }

    init();

    vm.create = function(){
      redirect('shell.supervisor.driver.create', {'moduleName': vm.module});
    };

    vm.deleteRecord = function(record){
      driverFactory.remove(vm.module, record.Id).then(function(){
        toast.success(vm.module + 'module record ' + vm.data.Name + ' deleted successfully');
        var index = vm.data.indexOf(record);
        vm.data.splice(index, 1);
      });
    };

    function checkString(data){
      return driverFactory.checkString(data);
    }

    function getFieldName(data){
      return driverFactory.getFieldName(data);
    }

    function redirect(url, obj){
      driverFactory.redirect(url, obj);
    }
    
  }

}());
