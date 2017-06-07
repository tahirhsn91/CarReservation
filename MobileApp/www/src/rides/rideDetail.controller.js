/**
 * @ngdoc controller
 * @name app.rides.controller:RideDetailCtrl
 * @description Ride Details controller
 */

(function(){

  'use strict';

  angular.module('app.rides')
    .controller('RideDetailCtrl', RideDetailCtrl);

  /* @ngInject */
  function RideDetailCtrl(Restangular, $stateParams){
      var vm = this;

      function initialize() {
          vm.geocoder = new google.maps.Geocoder;
          vm.ride = [];
          Restangular.one('Ride/'+$stateParams.id).get().then(function (result) {
              vm.ride = result;
              addLocationInfo(vm.ride);
          });
      }
      initialize();

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
