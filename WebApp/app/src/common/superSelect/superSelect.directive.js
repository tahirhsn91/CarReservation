/**
 * @ngdoc directive
 * @name app.common.directive:superSelect
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
    .directive('superSelect', superSelect);

  /* @ngInject */
  function superSelect($timeout){

    return {
      link: link,
      restrict: 'E',
      templateUrl:'src/common/superSelect/superSelect.directive.html',
      scope: {
        name: '@',
        model : '=',
        choices : '=',
        bind : '@',
        val:'@',
        onChange : '&',
        allowClear : '@',
        disabled : '=',
        index : '=',
        onSelect : '=',
        isRequired : '@',
        placeHolder: '@'
      }
    };

    /////////////////////

    function link(scope, elem, attrs){
      if(scope.onChange) {
        scope.$watch('model', function (newVal, oldVal) {
          scope.onChange({newVal: newVal, index: scope.index, oldVal: oldVal});
        });
      }
      scope.valChange = function(item){
        if(item && typeof item !== 'string'){
          item = item[scope.val];
        }
        if(scope.onSelect){
          scope.onSelect(item, scope.index, null);
        }
      };

      if(scope.model && scope.onSelect)
      {
        scope.valChange(scope.model);
      }
    }
  }

}());
