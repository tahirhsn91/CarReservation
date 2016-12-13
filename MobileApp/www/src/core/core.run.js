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
  function runFunciton($ionicPlatform, Restangular, $ionicLoading, httpStatus, store, $cordovaToast, authFactory) {
    $ionicPlatform.ready(function() {
        // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
        // for form inputs)
        if (window.cordova && window.cordova.plugins.Keyboard) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
        }
        if (window.StatusBar) {
        // org.apache.cordova.statusbar required
            StatusBar.styleDefault();
        }
    });
    Restangular.addFullRequestInterceptor(function (element, operation, route, url, headers, params, httpConfig){
            $ionicLoading.show({
              template: '<ion-spinner class="spinner-light" icon="android"></ion-spinner>'
            })
            return {
                element: element,
                operation : operation,
                route : route,
                url : url,
                headers: headers, //_.extend(headers, {'X-XSRF-Token': authFactory.setToken()}),
                params: params,
                httpConfig: httpConfig
            };
        });
        //Restangular.setFullResponse(true);
        Restangular.addResponseInterceptor(function (data, operation, what, url) {
            $ionicLoading.hide();
            return data;
        });
        Restangular.setErrorInterceptor(function (response, deferred, responseHandler) {
            $ionicLoading.hide();
            if (response.status === httpStatus.UNAUTHORIZED) {
                store.remove('token');
                store.remove('user');
                $state.go('login');
            } else {
                alert(response.data.Error);
            }
            return deferred.reject(response);
        });
  }
}());
