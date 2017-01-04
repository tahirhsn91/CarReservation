/**
 * @ngdoc controller
 * @name app.shell.controller:SideBarCtrl
 * @description Sidebar Controller
 */

(function(){
    /*jshint validthis: true */
    'use strict';

    angular
        .module('app.supervisor')
        .controller('SupSideBarCtrl', SideBarCtrl);

    /* @ngInject */
    function SideBarCtrl(appModules, store){
        var vm = this;
        
        vm.currentUser = store.get('user');
        vm.appModules = angular.copy(appModules[vm.currentUser.Role]);

        delete vm.appModules['Package']
    }

}());
