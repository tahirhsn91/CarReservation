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
    function Register(authFactory, store, appRegex) {
        var vm = this;
        
        vm.regex = appRegex;
        vm.register = register;
        
        function register() {
            authFactory.register(vm.cred).then(function (res) {
                
            });
        }

    }

}());
