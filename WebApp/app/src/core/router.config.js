/**
 * @ngdoc overview
 * @name app.core
 * @description Configuration block for routing
 */

(function(){

  'use strict';

  angular.module('app.core')
    .config(configuration)
    .run(routingEvents);

  /* @ngInject */
  function configuration($urlRouterProvider){

    $urlRouterProvider.otherwise('/login');

  }

  /* @ngInject */
  function routingEvents($rootScope, store, $state, authFactory){
    //on routing error
    $rootScope.$on('$stateNotFound', function(event, unfoundState, fromState, fromParams){
      //do some logging and toasting
    });

    //on routing error
    $rootScope.$on('$stateChangeSuccess', function(event, toState, toParams, fromState, fromParams){
      //do some title setting
      $rootScope.pageTitle = toState.title || 'app';
    });

    $rootScope.$on('$stateChangeStart', function(event, toState, toParams, fromState, fromParams){
      var loginState = 'authShell.login';
      if(store.get('user') === null && toState.name !== loginState){
        event.preventDefault();
        authFactory.navigateToLogin();
      }
      else if(store.get('user') !== null && toState.name === loginState){
        event.preventDefault();
        authFactory.navigateToDashboard();
      }
    });
  }

}());
