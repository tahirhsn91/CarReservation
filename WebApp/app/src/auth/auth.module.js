/**
 * @ngdoc overview
 * @name app.auth
 * @description < description placeholder >
 */

(function () {

    'use strict';

    angular
        .module('app.auth', [])
        .config(configuration);

    /* @ngInject */
    function configuration($stateProvider, appUserRole) {

        $stateProvider
            .state('authShell', {
                templateUrl: 'src/auth/login.html',
                role: appUserRole.All,
                views: {
                    '@': {
                        templateUrl: 'src/auth/authShell.html'
                    }
                }
            })
            .state('authShell.login', {
                url: '/login',
                role: appUserRole.All,
                views: {
                    'authContent@authShell': {
                        templateUrl: 'src/auth/login.html',
                        controller: 'Login as vm'
                    }
                }
            })
            .state('authShell.forgetPassword', {
                url: '/forget-password',
                role: appUserRole.All,
                views: {
                    'authContent@authShell': {
                        templateUrl: 'src/auth/forget.html',
                        controller: 'Forget as vm'
                    }
                }
            })
            .state('authShell.resetPassword', {
                url: '/reset-password?passcode?username',
                role: appUserRole.All,
                views: {
                    'authContent@authShell': {
                        templateUrl: 'src/auth/resetPassword.html',
                        controller: 'ResetPassword as vm'
                    }
                }
            });
    }
}());
