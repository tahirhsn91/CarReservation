/**
 * @ngdoc overview
 * @name app.core
 * @description Run funciton for core module
 */

(function(){

  'use strict';

  angular.module('app.core')
    .run(runFunciton);

  /* @ngInject */
  function runFunciton(Restangular, httpStatus, store, authFactory) {

    Restangular.addFullRequestInterceptor(function (element, operation, route, url, headers, params, httpConfig){
            //Loader show here
            return {
                element: element,
                operation : operation,
                route : route,
                url : url,
                headers: _.extend(headers, {'X-XSRF-Token': authFactory.setToken()}),
                params: params,
                httpConfig: httpConfig
            };
        });
        //Restangular.setFullResponse(true);
        Restangular.addResponseInterceptor(function (data, operation, what, url) {
            //Loader hide here
            return data;
        });
        Restangular.setErrorInterceptor(function (response, deferred, responseHandler) {
            //Loader hide here
            if (response.status === httpStatus.UNAUTHORIZED) {
                console.log(response);
            } else {
                console.log(response);
            }
            return deferred.reject(response);
        });
  }
}());
