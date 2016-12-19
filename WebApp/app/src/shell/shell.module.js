/**
 * @ngdoc overview
 * @name app.shell
 * @description Shell Module
 */

(function () {

    'use strict';

    angular
        .module('app.shell', [])
        .config(configuration);

    /* @ngInject */
    function configuration($stateProvider, appUserRole) {
        $stateProvider
            .state('shell', {
                url: '/',
                pageTitle: 'Caride',
                role: appUserRole.All,
                views: {
                    '@': {
                        templateUrl: 'src/shell/shell.html',
                        controller: 'ShellCtrl as vm'
                    },
                    'topNavBar@shell': {
                        templateUrl: 'src/shell/topNavBar.html',
                        controller: 'TopNavBarCtrl as vm'
                    },
                    'sideBar@shell': {
                        templateUrl: 'src/shell/sideBar.html',
                        controller: 'SideBarCtrl as vm'
                    }
                }
            });
    }

}());
