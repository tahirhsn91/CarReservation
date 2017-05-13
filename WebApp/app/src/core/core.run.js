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
  function runFunciton(Restangular, httpStatus, store, authFactory, toast, $rootScope) {

    Restangular.addFullRequestInterceptor(function (element, operation, route, url, headers, params, httpConfig){
        $rootScope.siteLoader = true;
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
            toggleLoader('');
            return data;
        });
        Restangular.setErrorInterceptor(function (response, deferred, responseHandler) {
            //Loader hide here
            if(response.status === httpStatus.UNAUTHORIZED){
                toast.error(response.data.Message);
                authFactory.logout();
            }
            else {
                if (response.data && response.data.Error) {
                    toast.error(response.data.Error);
                }
                else if (response.data && response.data.Message) {
                    toast.error(response.data.Message);
                }
                else {
                    toast.error(response);
                }
            }
            toggleLoader('');
            return deferred.reject(response);
        });

        function toggleLoader(route){
            $rootScope.siteLoader = false;
        }
  }
}());
