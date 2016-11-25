/**
 * @ngdoc object
 * @name app.common.constant:errorMessages
 * @description < description placeholder >
 * @example
 <pre>
 angular.module("someModule", [])
 .config(configuration);

 function configuration(errorMessages, someProvider){
    //use the injected constant
    };
 </pre>
 */

(function(){

  'use strict';

  var errorMessages = {
    default:{
      required: ' is required',
      email: ' is invalid',
      pattern: ' is invalid',
      number: ' must be a number',
      maxlength : 'must be less characters',
      minlength : 'must be more characters',
      validator : 'fields can not be same',
      max : 'must be less than current value',
      min : 'must be greater than current value',
      notUploaded: 'File was not uploaded due to some error'
    }
    //Example for custom errors
    // email: {
    //   pattern : ' is invalid'
    // }
  };

  angular
      .module('app.common')
      .constant('errorMessages', errorMessages);

}());
