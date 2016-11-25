/**
 * @ngdoc controller
 * @name app.auth.controller:ResetPassword
 * @description < description placeholder >
 */

(function(){

  'use strict';

	angular
		.module('app.auth')
		.controller('ResetPassword', ResetPassword);

  /* @ngInject */
	function ResetPassword($stateParams, auth, $state, httpStatus, toast,toastMessages, $rootScope, Dialog){
		var vm = this;

		vm.changePass = changePass;
        vm.credential = {
            PassCode : $stateParams.passcode,
            userName: $stateParams.username,
            Password:'',
            ReTypePassword : ''
        };
        vm.isExpire = false;
        vm.linkExpiry = false;
        vm.invalidPass = false;
        vm.isUnmanagedUser=false;
        vm.changePass = changePass;
        vm.openTermsAndCondition = openTermsAndCondition;

        $rootScope.emailSuccess = false;
        $rootScope.bodyClass = 'login-bg';

        auth.validate(vm.credential).then(function(res){
                vm.isUnmanagedUser=res.isUnmanagedUser;
            },
            function(err){
            if(err.status === httpStatus.NOT_FOUND){
                vm.isExpire = true;
            }
        });

        function changePass(resetForm){
            if(resetForm.$valid){
                if (vm.credential.Password === vm.credential.ReTypePassword) {
                    auth.resetPassword(vm.credential).then(function (res) {
                      toast.success(toastMessages.auth.passwordReset);
                      $state.go('authShell.login');
                     },function(err){
                        if(err.status === httpStatus.NOT_FOUND){
                            vm.isExpire = true;
                        }
                    });
                }
                else {
                    vm.invalidPass = false;
                 }
             }
        }

        function openTermsAndCondition() {
            Dialog.termsAndConditions();
        }
    }

}());
