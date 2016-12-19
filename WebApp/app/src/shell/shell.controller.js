/**
 * @ngdoc controller
 * @name app.shell.controller:ShellCtrl
 * @description Shell Controller
 */

(function () {

    'use strict';

    angular
        .module('app.shell')
        .controller('ShellCtrl', ShellCtrl);

    /* @ngInject */
    function ShellCtrl(authFactory, $rootScope) {
        var vm = this;
        $rootScope.pageTitle = 'Caride';
        authFactory.navigateToDashboard();
    }

}());
