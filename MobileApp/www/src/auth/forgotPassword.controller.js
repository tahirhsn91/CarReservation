/**
 * @ngdoc controller
 * @name app.auth.controller:ForgotPasswordCtrl
 * @description Forgot Password controller
 */

(function(){

  'use strict';

  angular.module('app.auth')
    .controller('ForgotPasswordCtrl', ForgotPasswordCtrl);

  /* @ngInject */
  function ForgotPasswordCtrl(authFactory){
    var vm = this;
    
    vm.requestPassword = requestPassword;

    function requestPassword() {
      authFactory.requestPassword(vm.userEmail).then(function(result){

      });
    }
  }

}());
