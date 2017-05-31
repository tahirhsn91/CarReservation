/**
 * @ngdoc controller
 * @name app.driverDashboard.controller:DriverDashboard
 * @description Driver Dashboard controller
 */

(function(){

  'use strict';

  angular.module('app.driverDashboard')
    .controller('DriverDashboardCtrl', DriverDashboardCtrl);

  /* @ngInject */
  function DriverDashboardCtrl(locationFactory, Restangular, $cordovaGeolocation){
      var vm = this;

      vm.locationFactory = locationFactory;
      vm.currentDriver = {};
      vm.getCurrectLoction = getCurrectLoction;
      vm.toggleAvailable = toggleAvailable;

      function initialize() {
          var mapOptions = {
              zoom: 14,
              center: new google.maps.LatLng(52.5498783, 13.425209099999961),
              mapTypeId: google.maps.MapTypeId.ROADMAP,
              disableDefaultUI: true
          };
          vm.geocoder = new google.maps.Geocoder;
          locationFactory.driverMap.map = new google.maps.Map(document.getElementById('map_canvas'), mapOptions);
          getCurrectLoction();
          getCurrentDriverObj();
      }

      function handleLocationError(browserHasGeolocation, infoWindow, pos) {
          infoWindow.setPosition(pos);
          infoWindow.setContent(browserHasGeolocation ?
              'Error: The Geolocation service failed.' :
              'Error: Your browser doesn\'t support geolocation.'
          );
      }

      function getCurrectLoction() {
          var posOptions = {timeout: 10000, enableHighAccuracy: true};
          $cordovaGeolocation.getCurrentPosition(posOptions).then(function (position) {
              // var lat  = position.coords.latitude;
              // var long = position.coords.longitude;
              var pos = {
                  lat: position.coords.latitude,
                  lng: position.coords.longitude
              };
              locationFactory.driverMap.map.setCenter(pos);
          }, function(err) {
              // error
          });
      }

      function toggleAvailable() {
          Restangular.all('DriverStatus/ToggleAvailable').post({}).then(function (result) {
              alert('Your Available is Toggle');
              vm.currentDriver = result;
          });
      }

      function geocodeLatLng(latlng) {
          vm.geocoder.geocode({'location': latlng}, function(results, status) {
              if (status === 'OK') {
                  if (results[1]) {
                      // alert(results[1].formatted_address);
                  } else {
                      // alert('No results found');
                  }
              } else {
                  // alert('Geocoder failed due to: ' + status);
              }
          });
      }

      function getCurrentDriverObj() {
          Restangular.one('Driver/GetCurrentDriver').get().then(function (result) {
              vm.currentDriver = result;
          })
      }

      //google.maps.event.addDomListener(window, 'load', initialize);
      initialize();

      google.maps.event.addListener(locationFactory.driverMap.map, 'dragend', function () {
          var latlng = {lat: vm.map.getCenter().lat(), lng: vm.map.getCenter().lng()};
          geocodeLatLng(latlng);
      });

      google.maps.event.addListener(locationFactory.driverMap.map, 'zoom_changed', function () {
          var latlng = {lat: locationFactory.driverMap.map.getCenter().lat(), lng: vm.map.getCenter().lng()};
          geocodeLatLng(latlng);
      });
  }

}());
