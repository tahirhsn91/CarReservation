/**
 * @ngdoc controller
 * @name app.shell.controller:TopNavBarCtrl
 * @description Top Nav Bar Controller
 */

(function () {

    'use strict';

    angular
        .module('app.shell')
        .controller('TopNavBarCtrl', TopNavBarCtrl);

    /* @ngInject */

    function TopNavBarCtrl(authFactory) {
        var vm = this;

        function logOut() {
            //authFactory.logout();
        }
    }


}());
