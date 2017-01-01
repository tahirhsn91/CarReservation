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

    // var defaultHeaders = {'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*'};
    // RestangularProvider.setDefaultHeaders(defaultHeaders);
    // RestangularProvider.setDefaultHeaders({
    //     'Content-Type': 'application/json',
    //     'X-Requested-With': 'XMLHttpRequest'
    // });
    // RestangularProvider.setDefaultHeaders({'Access-Control-Allow-Origin':'*'});
    // RestangularProvider.setDefaultHeaders({'Access-Control-Allow-core':'*'});


    RestangularProvider.setDefaultHeaders({
      'Content-Type': 'application/json',
      'X-Requested-With': 'XMLHttpRequest',
      'Access-Control-Allow-Origin':'*',
      'Access-Control-Allow-core':'*',
      'Access-Control-Allow-Headers':'Accept, X-Requested-With',
      'Access-Control-Allow-Credentials':'true'
    });

    RestangularProvider.setBaseUrl('/api');
  }

}());
