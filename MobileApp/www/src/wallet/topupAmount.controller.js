/**
 * @ngdoc controller
 * @name app.wallet.controller:TopupAmountCtrl
 * @description Topup Amount controller
 */

(function(){

  'use strict';

  angular.module('app.wallet')
    .controller('TopupAmountCtrl', TopupAmountCtrl);

  /* @ngInject */
  function TopupAmountCtrl(creditCardFactory){
    var vm = this;

    vm.topupAmount = topupAmount;

    function topupAmount(){
      // creditCardFactory.addCreditCard(vm.creditCard).then(function(result){
      //   $state.go('shell.wallet');
      // });
    }

  }

}());
