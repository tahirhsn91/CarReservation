/**
 * @ngdoc controller
 * @name app.setting.controller:SettingCtrl
 * @description Setting controller
 */

(function(){

  'use strict';

  angular.module('app.setting')
    .controller('SettingCtrl', SettingCtrl);

  /* @ngInject */
  function SettingCtrl(store){
    var vm = this;
    vm.user = store.get('user');
  }

}());
