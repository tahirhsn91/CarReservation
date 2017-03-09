/**
 * @ngdoc controller
 * @name app.genericCrud.controller:GenericDetailCtrl
 * @description Generic Detail Controller
 */

(function(){

  'use strict';

  angular.module('app.supervisor')
    .controller('PackageDetailCtrl', PackageDetailCtrl);

  /* @ngInject */
  function PackageDetailCtrl($stateParams, $state, store, packageFactory, appModules, toast, appFormats, lodash){
    var vm = this;

    vm.currentUser = store.get('user');
    vm.module = 'Package';
    vm.recordId = $stateParams.id;
    vm.pageTitle = packageFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.currentUser.Role][vm.module];
    vm.appFormats = appFormats;

    vm.deleteRecord = deleteRecord;
  
    function init() {
      packageFactory.getSingle(vm.module, vm.recordId).then(function(result){
        vm.data = result;
        processFields();
      });
    }
    
    vm.checkString = checkString;
    vm.getFieldName = getFieldName;
    vm.redirect = redirect;

    init();

    function processFields(){
      lodash.forEach(vm.fields, function(value){
        if(!checkString(value)){
          if(value.Type ==='Date'){
            vm.data[value.Field] = new Date(vm.data[value.Field]);
          }
          else if(value.Type ==='MultiDropDown'){
            vm.data[value.Field] = lodash.pluck(vm.data[value.Field],'Name').join(', ');
          }
        }
      });
    }

    function deleteRecord(){
      packageFactory.remove(vm.module, vm.recordId).then(function(){
        toast.success(vm.module + 'module record ' + vm.data.Name + ' deleted successfully');
        redirect('genericCrud.genericCrudList', {'moduleName': vm.module});
      });
    }

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
