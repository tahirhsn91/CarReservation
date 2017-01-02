(function () {
  function capDatePicker(appFormats, errorMessages) {

    return {
      link: link,
      restrict: 'E',
      templateUrl: 'src/common/capDatePicker/capDatePicker.html',
      scope: {
        dateModel:'=',
        minDate: '=',
        maxDate:'=',
        required: '=',
        valName:'@',
        formName:'=',
        conDisabled:'=',
        conDisabledChk:'@',
        dateName:'@'
      }
    };

    function link(scope){
      scope.errorMessages = errorMessages;
      scope.disable=false;

      if(scope.conDisabledChk){
        scope.$watch('conDisabled',function(newVal, oldVal){
                if((oldVal && (newVal === undefined))){
                    scope.dateModel = undefined;
                }
                if(newVal > scope.dateModel){
                    scope.dateModel = undefined;
                }
                if(!newVal){
                    scope.disable=true;
                }
                else{
                    scope.disable=false;
                }
        });
      }

      scope.clearDate = function(){
        scope.dateModel = undefined;
      };
      scope.datepicker = {};
      scope.datepicker.opened = false;
      scope.datepicker.open = function ($event) {
        if(!scope.disable){
          scope.datepicker.opened = true;
        }
      };
      scope.to = {
        datepickerOptions :{
          initDate: new Date(),
          format: appFormats.Date
        }
      };
    }
  }

  angular
    .module('app.common')
    .directive('capDatePicker', capDatePicker);
})();
