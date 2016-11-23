/**
 * @ngdoc overview
 * @name app.shell
 * @description Shell module
 */

(function(){

  angular.module('app.shell', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider){

    $stateProvider
      .state('shell', {
        url:'/app',
        abstract: true,
        templateUrl:'src/shell/shell.html',
        controller: 'ShellCtrl as vm'
      });
  }

}());
