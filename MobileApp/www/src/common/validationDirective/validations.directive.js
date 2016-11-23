/**
 * @ngdoc directive
 * @name app.common.directive:validations
 * @scope true
 * @param {object} test test object
 * @restrict E
 *
 * @description < description placeholder >
 *
 */

(function(){

  'use strict';

  angular
    .module('app.common')
    .directive('validations', validations);

  /* @ngInject */
  function validations(errorMessages) {

      return {
          link: link,
          restrict: 'E',
          replace:true,
          templateUrl: 'src/common/validationDirective/validations.html',
          scope: {
              formName:'=',
              fieldName:'@',
              label: '@',
              index : '@',
              dirty : '='
          }
      };

      function link(scope, element, attrs){
          scope.errorMessages = errorMessages;
      }
  }

}());
