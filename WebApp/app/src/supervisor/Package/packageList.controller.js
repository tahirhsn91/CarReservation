/**
 * @ngdoc controller
 * @name app.genericCrud.controller:PackageListCtrl
 * @description Generic List Controller
 */

(function(){

  'use strict';

  angular.module('app.supervisor')
    .controller('PackageListCtrl', PackageListCtrl);

  /* @ngInject */
  function PackageListCtrl($stateParams, $state, store, packageFactory, appModules, toast){
    var vm = this;

    vm.currentUser = store.get('user');
    vm.module = 'Package';
    vm.pageTitle = packageFactory.getModuleName(vm.module);
    // vm.fields = appModules[vm.currentUser.Role][vm.module];
    

    vm.checkString = checkString;
    vm.getFieldName = getFieldName;
    vm.redirect = redirect;

    function init() {
      packageFactory.getAll(vm.module).then(function(result){
        vm.data = result;
      });
    }

    init();

    vm.create = function(){
      redirect('shell.supervisor.package.create', {'moduleName': vm.module});
    };

    vm.deleteRecord = function(record){
      packageFactory.remove(vm.module, record.Id).then(function(){
        toast.success(vm.module + 'module record ' + vm.data.Name + ' deleted successfully');
        var index = vm.data.indexOf(record);
        vm.data.splice(index, 1);
      });
    };

    function checkString(data){
      return packageFactory.checkString(data);
    }

    function getFieldName(data){
      return packageFactory.getFieldName(data);
    }

    function redirect(url, obj){
      packageFactory.redirect(url, obj);
    }
    
  }

}());
