/**
 * @ngdoc controller
 * @name app.rides.controller:RidesCtrl
 * @description Rides controller
 */

(function(){

  'use strict';

  angular.module('app.rides')
    .controller('RidesCtrl', RidesCtrl);

  /* @ngInject */
  function RidesCtrl(Restangular){
      var vm = this;

      function initialize() {
          vm.geocoder = new google.maps.Geocoder;
          vm.rides = [];
          Restangular.one('Ride').get().then(function (result) {
              vm.rides = result;
              addLocationInfos();
          });
      }
      initialize();

      function addLocationInfos() {
          for (var i = 0; i < vm.rides.length; i++) {
              addLocationInfo(vm.rides[i]);
          }
      }

      function addLocationInfo(ride) {
          var sourceLatLng = {lat: ride.Source.Latitude, lng: ride.Source.Longitude};
          var destinationLatLng = {lat: ride.Destination.Latitude, lng: ride.Destination.Longitude};

          if(ride.Source.Address) {
              vm.geocoder.geocode({'location': sourceLatLng}, function (results, status) {
                  if (status === 'OK') {
                      if (results[1]) {
                          ride.Source.Address = results[1].formatted_address;
                      }
                  }
              });
          }

          if(!ride.Destination.Address) {
              vm.geocoder.geocode({'location': destinationLatLng}, function (results, status) {
                  if (status === 'OK') {
                      if (results[1]) {
                          ride.Destination.Address = results[1].formatted_address;
                      }
                  }
              });
          }
      }
  }

}());
