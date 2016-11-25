/**
 * @ngdoc controller
 * @name app.auth.controller:LoginCtrl
 * @description Login controller
 */

(function(){

  'use strict';

  angular.module('app.auth')
    .controller('LoginCtrl', LoginCtrl);

  /* @ngInject */
  function LoginCtrl(store, $state, authFactory, appRegex){
    var vm = this;

    vm.regex = appRegex;
    
    vm.login = login;

    function login() {
      store.set('token', 'result');
      store.set('user', 'Umair');
      $state.go('shell.customerDashboard');
      // authFactory.login(vm.user).then(function(result){
      //   store.set('token', result);
      //   store.set('user', 'Umair');
      //   var user = 'Umair';
      //   if(user === 'Umair'){
      //     $state.go('shell.customerDashboard');
      //   } else {
      //     $state.go('shell.driverDashboard');
      //   }
      // });
    }
  }

}());
