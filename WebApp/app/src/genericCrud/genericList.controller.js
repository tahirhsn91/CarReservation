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
  function GenericListCtrl($stateParams, $state, store, genericCrudFactory, appModules, toast){
    var vm = this;

    vm.currentUser = store.get('user');
    vm.module = $stateParams.moduleName;
    vm.pageTitle = genericCrudFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.currentUser.Role][vm.module];
    

    vm.checkString = checkString;
    vm.getFieldName = getFieldName;
    vm.redirect = redirect;

    function init() {
      genericCrudFactory.getAll(vm.module).then(function(result){
        vm.data = result;
      });
    }

    init();

    vm.create = function(){
      redirect('genericCrud.genericCrudCreate', {'moduleName': vm.module});
    };

    vm.deleteRecord = function(record){
      genericCrudFactory.remove(vm.module, record.Id).then(function(){
        toast.success(vm.module + 'module record ' + vm.data.Name + ' deleted successfully');
        var index = vm.data.indexOf(record);
        vm.data.splice(index, 1);
      });
    };

    function checkString(data){
      return genericCrudFactory.checkString(data);
    }

    function getFieldName(data){
      return genericCrudFactory.getFieldName(data);
    }

    function redirect(url, obj){
      genericCrudFactory.redirect(url, obj);
    }
    
  }

}());
