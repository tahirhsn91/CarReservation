/**
 * @ngdoc controller
 * @name app.auth.controller:ChangePasswordCtrl
 * @description Change Password controller
 */

(function(){

  'use strict';

  angular.module('app.auth')
    .controller('ChangePasswordCtrl', ChangePasswordCtrl);

  /* @ngInject */
  function ChangePasswordCtrl(){
    var vm = this;

    vm.changePassword = changePassword;

    function changePassword() {
      authFactory.changePassword(vm.user).then(function(result){
        $state.go('shell.setting');
      });
    }
  }

}());
