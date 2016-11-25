/**
 * @ngdoc service
 * @name app.auth.auth
 * @description < description placeholder >
 */

(function () {

    'use strict';

    angular
        .module('app.auth')
        .factory('authFactory', authFactory);

    /* @ngInject */
    function authFactory(Restangular) {

        return {
            login: login,
            forgetPass: forgetPass,
            resetPassword: resetPassword,
            logout: logout
        };

        function forgetPass(data) {
            return Restangular.all('Users/Forget').post(data);
        }

        function resetPassword(data) {
            return Restangular.all('Users/Reset').post(data);
        }

        function login(data) {
            return Restangular.all('Users/Login').post(data);
        }

        function logout() {
            return Restangular.all('Users/Logout').post();
        }
    }

}());
