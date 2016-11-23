/**
 * @ngdoc factory
 * @name app.auth.factory:authFactory
 * @description Auth Factory
 */

(function(){

  'use strict';

  angular.module('app.auth')
    .factory('authFactory', authFactory);

  /* @ngInject */
  function authFactory(Restangular){
    
    return {
      login: login,
      register: register
    }

    function login(data){
      return Restangular.all('User/Login').post(data);
    }

    function register(data){
      return Restangular.all('User/Register').post(data);
    }

  }

}());
