/**
 * @ngdoc factory
 * @name app.auth.factory:authFactory
 * @description Auth Factory
 */

(function(){

  'use strict';

  angular.module('app.auth')
    .factory('authFactory', authFactory);

  /* @ngInject */
  function authFactory(Restangular, store, $state, $location) {

        return {
            login: login,
            forgetPass: forgetPass,
            resetPassword: resetPassword,
            logout: logout,
            register: register,
            setToken: setToken,
            navigateToLogin: navigateToLogin,
            navigateToDashboard: navigateToDashboard
        };

        function forgetPass(data) {
            return Restangular.all('User/Forget').post(data);
        }

        function resetPassword(data) {
            return Restangular.all('User/Reset').post(data);
        }

        function login(data) {
            return Restangular.all('User/Login').post(data);
        }

        function register(data) {
            return Restangular.all('User/Register').post(data);
        }

        function logout() {
            store.remove('token');
            store.remove('user');
            $state.reload();
        }

        function setToken(){
            var defaultHeaders = {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            };
            var token = store.get('token');
            if (token) {
                defaultHeaders.Authorization = token.token_type + ' ' + token.access_token;
            }
            Restangular.setDefaultHeaders(defaultHeaders);
        }

        function navigateToLogin(){
            $state.go('authShell.login');
        }

        function navigateToDashboard(){
            $state.go('shell.customerDashboard');
        }
    }

}());