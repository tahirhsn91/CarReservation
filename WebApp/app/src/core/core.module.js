/**
 * @ngdoc overview
 * @name app.core
 * @description Core is where the Magma is
 */

(function(){

  'use strict';

  angular.module('app.core', [
    'ui.router',
    'ui.bootstrap',
    'ngSanitize',
    'restangular',
    'ngMessages',
    'angular-storage',
    'ngToast',
    'ui.select'
  ]);

  angular.module('app.core').value('lodash', _);

}());
