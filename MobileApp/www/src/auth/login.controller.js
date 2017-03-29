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
      authFactory.login(vm.user).then(function (result) {
            store.set('token', {
                access_token: result.access_token,
                token_type: result.token_type,
                expires_in: result.expires_in
            });
            var user = JSON.parse(result.user);
            user.FullName = user.FirstName + ' '+ user.LastName;
            store.set('user', user);

            authFactory.navigateToDashboard(user);
        });
    }
  }

}());
