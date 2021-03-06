/**
 * @ngdoc overview
 * @name app.core
 * @description Configuration block for restangular
 */

(function(){

  'use strict';

  angular.module('app.core')
    .config(configuration);

  /* @ngInject */
  function configuration(RestangularProvider){

    RestangularProvider.setDefaultHeaders({
        'Content-Type': 'application/json',
        'X-Requested-With': 'XMLHttpRequest'
    });
    RestangularProvider.setDefaultHeaders({"Access-Control-Allow-Origin":"*"});
    RestangularProvider.setDefaultHeaders({"Access-Control-Allow-core":"*"});

    RestangularProvider.setBaseUrl('http://35.164.206.165:80/api');
    // RestangularProvider.setBaseUrl('http://localhost:46363/api');

  }

}());
