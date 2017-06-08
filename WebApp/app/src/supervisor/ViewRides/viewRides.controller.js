/**
 * @ngdoc controller
 * @name app.genericCrud.controller:PackageListCtrl
 * @description Generic List Controller
 */

(function(){

  'use strict';

  angular.module('app.supervisor')
    .controller('ViewRidesCtrl', ViewRidesCtrl);

  /* @ngInject */
  function ViewRidesCtrl($stateParams, $state, store, assignPackageFactory, appModules, toast){
    var vm = this;

    vm.currentUser = store.get('user');
    vm.module = 'View Rides';
    vm.pageTitle = assignPackageFactory.getModuleName(vm.module);

    vm.redirect = redirect;

    function init() {
        vm.geocoder = new google.maps.Geocoder;
        assignPackageFactory.getAll('Ride/GetRideBySupervisorUserId').then(function(result){
        vm.data = result;
        // addLocationInfos(vm.data);
      });
    }

    init();

    function redirect(url, obj){
      assignPackageFactory.redirect(url, obj);
    }

      function addLocationInfos(rides) {
          for (var i = 0; i < rides.length; i++) {
              addLocationInfo(rides[i]);
          }
      }

      function addLocationInfo(ride) {
          var sourceLatLng = {lat: ride.Source.Latitude, lng: ride.Source.Longitude};
          var destinationLatLng = {lat: ride.Destination.Latitude, lng: ride.Destination.Longitude};

          vm.geocoder.geocode({'location': sourceLatLng}, function(results, status) {
              if (status === 'OK') {
                  if (results[1]) {
                      ride.SourceAddress = results[1].formatted_address;
                  }
              }
          });

          vm.geocoder.geocode({'location': destinationLatLng}, function(results, status) {
              if (status === 'OK') {
                  if (results[1]) {
                      ride.DestinationAddress = results[1].formatted_address;
                  }
              }
          });
      }

  }

}());
