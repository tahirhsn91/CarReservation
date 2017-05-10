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
  function ShellCtrl(store, $state, $ionicPopup, authFactory){
    var vm = this;

    vm.logout = logout;
    vm.isCustomer = true;

    function initialize() {
      var user = authFactory.getUser();
      vm.isCustomer = (user.Role === 'Customer');
    }
    initialize();

    function logout(){
      $ionicPopup.confirm({
        title: 'Logout',
        template: 'Are you sure you want to logout from the application?'
      }).then(function(res) {
        if(res) {
          // store.remove('token');
          // store.remove('user');
          // $state.go('auth');
          authFactory.logout();
        } else {
        }
      });
    }

  }

}());
