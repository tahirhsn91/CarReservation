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

    RestangularProvider.setBaseUrl('http://172.16.2.122:1401/api');

  }

}());
