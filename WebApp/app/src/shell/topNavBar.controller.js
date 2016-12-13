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

    function TopNavBarCtrl(authFactory, store) {
        var vm = this;
        vm.currentUser = store.get('user');
        
        vm.logOut = function () {
            authFactory.logout();
        }
    }


}());
