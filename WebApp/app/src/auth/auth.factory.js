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
    function authFactory(Restangular, store, appUserRole, $state, $location) {

        return {
            login: login,
            forgetPass: forgetPass,
            resetPassword: resetPassword,
            logout: logout,
            register: register,
            setToken: setToken,
            navigateToLogin: navigateToLogin,
            navigateToDashboard: navigateToDashboard,
            loginSuccess: loginSuccess
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

        function navigateToDashboard(user){
            if(user.Role === appUserRole.Admin){
                $state.go('shell.dashboard');
            }
            else if(user.Role === appUserRole.Supervisor){
                $state.go('shell.supervisor.dashboard');
            }
        }

        function loginSuccess(data){
            store.set('token', {
                access_token: data.access_token,
                token_type: data.token_type,
                expires_in: data.expires_in
            });
            var user = JSON.parse(data.user);
            user.FullName = user.FirstName.toCapitalizeCase() + ' '+ user.LastName.toCapitalizeCase();
            store.set('user', user);

            navigateToDashboard(user);
        }
    }

}());
