/**
 * @ngdoc controller
 * @name app.shell.controller:SideBarCtrl
 * @description Sidebar Controller
 */

(function(){
    /*jshint validthis: true */
    'use strict';

    angular
        .module('app.shell')
        .controller('SideBarCtrl', SideBarCtrl);

    /* @ngInject */
    function SideBarCtrl(appModules, store){
        var vm = this;
        
        vm.currentUser = store.get('user');
        vm.appModules = appModules[vm.currentUser.Role];
    }

}());
