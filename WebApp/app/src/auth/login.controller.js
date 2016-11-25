/**
 * @ngdoc controller
 * @name app.auth.controller:Login
 * @description < description placeholder >
 */

(function () {

    'use strict';

    angular
        .module('app.auth')
        .controller('Login', Login);

    /* @ngInject */
    function Login(authFactory, store, appRegex, $state) {
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
                store.set('user', JSON.parse(result.user));
                $state.go('shell');
            });
        }

    }

}());
