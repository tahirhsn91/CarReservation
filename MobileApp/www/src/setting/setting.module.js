/**
 * @ngdoc overview
 * @name app.setting
 * @description Setting module
 */

(function(){

  angular.module('app.setting', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider){

    $stateProvider
      .state('shell.setting', {
        url:'/setting',
        views: {
          'menuContent': {
            templateUrl:'src/setting/setting.html',
            controller: 'SettingCtrl as vm',
          }
        }
      });
  }

}());
