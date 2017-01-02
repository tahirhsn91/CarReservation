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
    function Login(authFactory, store, appRegex, $state, $location) {
        var vm = this;
        
        vm.regex = appRegex;
        vm.login = login;
        
        function login() {
            authFactory.login(vm.user).then(function (result) {
                authFactory.loginSuccess(result);
            });
        }

    }

}());
