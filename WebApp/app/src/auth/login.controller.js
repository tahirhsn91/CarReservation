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
    function Login(auth, $rootScope, store, Dialog) {
        var vm = this;
        vm.cred = {
            'userName': '',
            'password': ''
        };
        vm.login = login;
        vm.invalid = false;
        vm.openTermsAndCondition = openTermsAndCondition;

        $rootScope.emailSuccess = false;
        $rootScope.bodyClass = 'login-bg';

        function init() {
            auth.setIsUserAuthorize(false);
            auth.setRouteRestriction(false);
            var loginUserData = store.get('userData');
            if (loginUserData) {
                auth.redirectToRouteOnLogin(loginUserData);
            }
        }
        init();


        function login(loginForm) {
            if (loginForm.$valid) {
                auth.login(vm.cred).then(function (res) {
                    auth.getToken(vm.cred).then(function (data) {
                        res.Token = {};
                        res.Token.value = data;
                        angular.forEach(res, function (obj, key) {
                            if (typeof obj === 'object' && obj !== null) {
                                store.set(key, obj);
                            }
                        });
                        auth.setIsUserAuthorize(true);
                        auth.redirectToRouteOnLogin(store.get('userData'));
                    });
                }, function(){
                    $rootScope.siteLoader = false;
                });
            }
        }

        function openTermsAndCondition() {
            Dialog.termsAndConditions();
        }
    }

}());
