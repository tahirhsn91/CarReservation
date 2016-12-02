/**
 * @ngdoc overview
 * @name app.wallet
 * @description Wallet module
 */

(function(){

  angular.module('app.wallet', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider){

    $stateProvider
      .state('shell.wallet', {
        url:'/wallet',
        views: {
          'menuContent': {
            templateUrl:'src/wallet/wallet.html',
            controller: 'WalletCtrl as vm',
          }
        }
      })
      .state('shell.addCreditCard', {
        url:'/add-credit-card',
        views: {
          'menuContent': {
            templateUrl:'src/wallet/addCreditCard.html',
            controller: 'AddCreditCardCtrl as vm',
          }
        }
      })
      .state('shell.creditCardsList', {
        url:'/credit-cards-list',
        views: {
          'menuContent': {
            templateUrl:'src/wallet/creditCardsList.html',
            controller: 'CreditCardListCtrl as vm',
          }
        }
      })
      .state('shell.topupAmount', {
        url:'/topup-amount',
        views: {
          'menuContent': {
            templateUrl:'src/wallet/topupAmount.html',
            controller: 'TopupAmountCtrl as vm',
          }
        }
      });
  }

}());
