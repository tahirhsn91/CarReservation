/**
 * @ngdoc controller
 * @name app.dashboard.controller:Dashboard
 * @description < description placeholder >
 */

(function(){

  'use strict';

	angular
		.module('app.dashboard')
		.controller('DashboardCtrl', Dashboard);

  /* @ngInject */
	function Dashboard(Restangular){
		var vm = this;

		vm.data = {};
		vm.isInt = isInt;

		function init(){
			Restangular.one('Common/Dashboard').get().then(function(result){
				console.log(result);
				vm.data = result;
			});
		}

		function isInt(value) {
			return !isNaN(value) && 
						parseInt(Number(value)) == value && 
						!isNaN(parseInt(value, 10));
		}

		init();
	}

}());
