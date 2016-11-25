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

    RestangularProvider.setBaseUrl('/api');
    var defaultHeaders = {'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*'};
    RestangularProvider.setDefaultHeaders(defaultHeaders);

  }

}());
