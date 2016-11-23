/**
 * @ngdoc controller
 * @name app.shell.controller:ShellCtrl
 * @description Shell controller
 */

(function(){

  'use strict';

  angular.module('app.shell')
    .controller('ShellCtrl', ShellCtrl);

  /* @ngInject */
  function ShellCtrl(store, $state){
    var vm = this;

    vm.logout = logout;

    function logout(){
      store.remove('token');
      store.remove('user');
      $state.go('auth');
    }

  }

}());
