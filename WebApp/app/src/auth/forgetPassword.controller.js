/**
 * @ngdoc controller
 * @name app.auth.controller:Forget
 * @description < description placeholder >
 */

(function(){

  'use strict';

	angular
		.module('app.auth')
		.controller('Forget', Forget);

  /* @ngInject */
	function Forget(auth, $rootScope){
		var vm = this;
        vm.email = '';
        vm.sendEmail = sendEmail;
        vm.isEmailSent = false;
        vm.Invalid = false;

        $rootScope.emailSuccess = false;
        $rootScope.bodyClass = 'login-bg';

        function sendEmail(forgetForm){
            if(forgetForm.$valid){
                auth.forgetPass(vm.email).then(function(res){
                    if(res){
                        $rootScope.emailSuccess = true;
                    }
                },function(err){
                    if(err.status === 408){
                        vm.isEmailSent = true;
                    }
                    $rootScope.siteLoader = false;
                });
            }
          }
	}

}());
