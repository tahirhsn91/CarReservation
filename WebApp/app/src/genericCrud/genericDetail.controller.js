/**
 * @ngdoc controller
 * @name app.genericCrud.controller:GenericDetailCtrl
 * @description Generic Detail Controller
 */

(function(){

  'use strict';

  angular.module('app.genericCrud')
    .controller('GenericDetailCtrl', GenericDetailCtrl);

  /* @ngInject */
  function GenericDetailCtrl($stateParams, $state, store, genericCrudFactory, appModules, toast, appFormats, lodash){
    var vm = this;

    vm.currentUser = store.get('user');
    vm.module = $stateParams.moduleName;
    vm.recordId = $stateParams.id;
    vm.pageTitle = genericCrudFactory.getModuleName(vm.module);
    vm.fields = appModules[vm.currentUser.Role][vm.module];
    vm.appFormats = appFormats;

    vm.deleteRecord = deleteRecord;
  
    function init() {
      debugger;
      genericCrudFactory.getSingle(vm.module, vm.recordId).then(function(result){
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
      genericCrudFactory.remove(vm.module, vm.recordId).then(function(){
        toast.success(vm.module + 'module record ' + vm.data.Name + ' deleted successfully');
        redirect('genericCrud.genericCrudList', {'moduleName': vm.module});
      });
    }

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
