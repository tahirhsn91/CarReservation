/**
 * @ngdoc controller
 * @name app.dashboard.controller:Dashboard
 * @description < description placeholder >
 */

(function(){

  'use strict';

	angular
		.module('app.dashboard')
		.controller('SupervisorDashboardCtrl', SupervisorDashboardCtrl);

  /* @ngInject */
	function SupervisorDashboardCtrl(Restangular){
		var vm = this;

		vm.data = {};
		vm.isInt = isInt;

		function init(){
			Restangular.one('Common/SupervisorDashboard').get().then(function(result){
				vm.data = result;
			});
		}

		function isInt(value) {
			return !isNaN(value) && 
						parseInt(Number(value)) === value && 
						!isNaN(parseInt(value, 10));
		}

		init();
	}

}());
