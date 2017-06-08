(function(){

  'use strict';

  angular.module('app.supervisor')
    .controller('ViewRideDetailsCtrl', ViewRideDetailsCtrl);

  /* @ngInject */
  function ViewRideDetailsCtrl($stateParams, store, assignPackageFactory, appModules, toast, lodash, $state){
    var vm = this;

    vm.maxDate = new Date();
    vm.currentUser = store.get('user');
    vm.module = 'Ride Details';
    vm.recordId = $stateParams.id ? $stateParams.id : null;
    vm.pageTitle = assignPackageFactory.getModuleName(vm.module);
    vm.choices = {};
    vm.data = {};

    vm.redirect = redirect;

    function init() {
      if(vm.recordId){
        assignPackageFactory.getAll('Ride/' + vm.recordId).then(function(result){
          vm.data = result;
        });
      }
    }

    init();

    function redirect(url, obj){
      assignPackageFactory.redirect(url, obj);
    }
  }

}());
