/**
 * @ngdoc overview
 * @name app.shell
 * @description Shell module
 */

(function(){

  angular.module('app.auth', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider, appUserRole){

    $stateProvider
      .state('auth', {
        url:'/auth',
        role: appUserRole.All,
        templateUrl:'src/auth/landing.html'
      })
      .state('login', {
        url:'/login',
        role: appUserRole.All,
        templateUrl:'src/auth/login.html',
        controller: 'LoginCtrl as vm'
      })
      .state('register', {
        url:'/register',
        role: appUserRole.All,
        templateUrl:'src/auth/register.html',
        controller: 'RegisterCtrl as vm'
      })
      .state('forgotPassword', {
        url:'/forgot-password',
        role: appUserRole.All,
        templateUrl:'src/auth/forgotPassword.html',
        controller: 'ForgotPasswordCtrl as vm'
      })
      .state('shell.changePassword', {
        url:'/change-password',
        views: {
          'menuContent': {
            templateUrl:'src/auth/changePassword.html',
            controller: 'ChangePasswordCtrl as vm',
          }
        }
      });
  }

}());
