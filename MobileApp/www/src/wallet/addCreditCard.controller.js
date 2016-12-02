/**
 * @ngdoc controller
 * @name app.wallet.controller:AddCreditCardCtrl
 * @description Add Credit Card controller
 */

(function(){

  'use strict';

  angular.module('app.wallet')
    .controller('AddCreditCardCtrl', AddCreditCardCtrl);

  /* @ngInject */
  function AddCreditCardCtrl(creditCardFactory){
    var vm = this;

    vm.addCreditCard = addCreditCard;

    function addCreditCard(){
      creditCardFactory.addCreditCard(vm.creditCard).then(function(result){
        $state.go('shell.wallet');
      });
    }

  }

}());
