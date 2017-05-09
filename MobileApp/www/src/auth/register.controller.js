/**
 * @ngdoc controller
 * @name app.auth.controller:RegisterCtrl
 * @description Register controller
 */

(function(){

  'use strict';

  angular.module('app.auth')
    .controller('RegisterCtrl', RegisterCtrl);

  /* @ngInject */
  function RegisterCtrl(store, appRegex, authFactory, $state){
    var vm = this;
    
    vm.user = {Role: 'CUSTOMER'};
    vm.register = register;
    vm.regex = appRegex;

    function register() {
      authFactory.register(vm.user).then(function(result) {
          authFactory.loginSuccess(result);
      });
    }

  }

}());
