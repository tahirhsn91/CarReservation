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
    function ShellCtrl(authFactory) {
        var vm = this;
        authFactory.navigateToDashboard();
    }

}());
