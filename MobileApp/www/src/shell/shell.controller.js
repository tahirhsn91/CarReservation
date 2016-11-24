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
  function ShellCtrl(store, $state, $ionicPopup){
    var vm = this;

    vm.logout = logout;

    function logout(){
      $ionicPopup.confirm({
        title: 'Logout',
        template: 'Are you sure you want to logout from the application?'
      }).then(function(res) {
        if(res) {
          store.remove('token');
          store.remove('user');
          $state.go('auth');
        } else {
          console.log('You Canceled');
        }
      });
    }

  }

}());
