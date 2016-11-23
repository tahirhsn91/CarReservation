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
      });
  }

}());
