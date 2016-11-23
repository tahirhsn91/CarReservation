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

    $urlRouterProvider.otherwise('/app/customer-dashboard');

  }

  /* @ngInject */
  function routingEvents($rootScope, store, $state, appUserRole){
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
        if((store.get('user') === null && toState.role !== appUserRole.All)){
            event.preventDefault();
            $state.go('auth');
        }
    });
  }

}());
