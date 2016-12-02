/**
 * @ngdoc controller
 * @name app.wallet.controller:CreditCardListCtrl
 * @description Credit Card List controller
 */

(function(){

  'use strict';

  angular.module('app.wallet')
    .controller('CreditCardListCtrl', CreditCardListCtrl);

  /* @ngInject */
  function CreditCardListCtrl(creditCardFactory){
    var vm = this;

    function init() {
      // creditCardFactory.getAllCreditCards().then(function(result){
      //   vm.creditCards = result;
      // });
    }

    init();

  }

}());
