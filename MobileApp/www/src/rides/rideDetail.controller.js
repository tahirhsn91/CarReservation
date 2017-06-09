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

      vm.rateIt = rateIt;

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

          if (!ride.Source.Address) {
              vm.geocoder.geocode({'location': sourceLatLng}, function (results, status) {
                  if (status === 'OK') {
                      if (results[1]) {
                          ride.Source.Address = results[1].formatted_address;
                      }
                  }
              });
          }

          if (!ride.Destination.Address) {
              vm.geocoder.geocode({'location': destinationLatLng}, function (results, status) {
                  if (status === 'OK') {
                      if (results[1]) {
                          ride.Destination.Address = results[1].formatted_address;
                      }
                  }
              });
          }
      }

      function rateIt() {
          Restangular.all('Ride/Rating/' + $stateParams.id + '/' + vm.ride.Rating).post({}).then(function (result) {
              alert('Thank You for your Feedback')
          });
      }
  }

}());
