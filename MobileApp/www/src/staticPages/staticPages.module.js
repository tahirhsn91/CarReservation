/**
 * @ngdoc overview
 * @name app.staticPages
 * @description Static Pages module
 */

(function(){

  angular.module('app.staticPages', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider){

    $stateProvider
      .state('shell.contactusPage', {
        url:'/contact-us',
        views: {
          'menuContent': {
            templateUrl:'src/staticPages/contactus.html'
          }
        }
      })
      .state('shell.helpPage', {
        url:'/help',
        views: {
          'menuContent': {
            templateUrl:'src/staticPages/help.html'
          }
        }
      })
      .state('shell.ratesPage', {
        url:'/rates',
        views: {
          'menuContent': {
            templateUrl:'src/staticPages/rates.html'
          }
        }
      });
  }

}());
