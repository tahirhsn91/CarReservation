/**
 * @ngdoc controller
 * @name app.setting.controller:SettingCtrl
 * @description Setting controller
 */

(function(){

  'use strict';

  angular.module('app.errorPages')
    .controller('DriverAssociationCtrl', DriverAssociationCtrl);

  /* @ngInject */
  function DriverAssociationCtrl(store){
    var vm = this;
    vm.user = store.get('user');
  }

}());
