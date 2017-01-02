/**
 * @ngdoc controller
 * @name app.auth.controller:Register
 * @description < description placeholder >
 */

(function () {

    'use strict';

    angular
        .module('app.auth')
        .controller('Register', Register);

    /* @ngInject */
    function Register(authFactory, store, appRegex, appUserRole) {
        var vm = this;
        
        vm.regex = appRegex;
        vm.register = register;
        
        function register() {
            vm.user.Role = appUserRole.Supervisor;
            authFactory.register(vm.user).then(function (result) {
                authFactory.loginSuccess(result);
            });
        }

    }

}());
