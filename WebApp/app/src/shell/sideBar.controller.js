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
    function SideBarCtrl(appModules){
        var vm = this;
        
        vm.appModules = appModules;
    }

}());
