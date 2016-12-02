/**
 * @ngdoc factory
 * @name app.wallet.factory:creditCardFactory
 * @description Credit Card Factory
 */

(function(){

  'use strict';

  angular.module('app.wallet')
    .factory('creditCardFactory', creditCardFactory);

  /* @ngInject */
  function creditCardFactory(Restangular){
    
    return {
      addCreditCard: addCreditCard,
      getAllCreditCards: getAllCreditCards
    }

    function getAllCreditCards(data){
      return Restangular.one('CreditCard').get(data);
    }

    function addCreditCard(data){
      return Restangular.all('CreditCard').post(data);
    }

  }

}());
