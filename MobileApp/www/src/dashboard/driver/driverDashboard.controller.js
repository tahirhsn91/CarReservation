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
  function DriverDashboardCtrl(){
    var vm = this;

      vm.getCurrectLoction = getCurrectLoction;

      function initialize() {
          var mapOptions = {
              zoom: 14,
              center: new google.maps.LatLng(52.5498783, 13.425209099999961),
              mapTypeId: google.maps.MapTypeId.ROADMAP,
              disableDefaultUI: true
          };
          vm.geocoder = new google.maps.Geocoder;
          vm.map = new google.maps.Map(document.getElementById('map_canvas'), mapOptions);
          getCurrectLoction();
      }

      function handleLocationError(browserHasGeolocation, infoWindow, pos) {
          infoWindow.setPosition(pos);
          infoWindow.setContent(browserHasGeolocation ?
              'Error: The Geolocation service failed.' :
              'Error: Your browser doesn\'t support geolocation.'
          );
      }

      function getCurrectLoction() {
          // Try HTML5 geolocation.
          if (navigator.geolocation) {
              navigator.geolocation.getCurrentPosition(function(position) {
                  var pos = {
                      lat: position.coords.latitude,
                      lng: position.coords.longitude
                  };
                  vm.map.setCenter(pos);
              }, function() {
                  handleLocationError(true, infoWindow, vm.map.getCenter());
              });
          } else {
              // Browser doesn't support Geolocation
              handleLocationError(false, infoWindow, vm.map.getCenter());
          }
      }

      function geocodeLatLng(latlng) {
          vm.geocoder.geocode({'location': latlng}, function(results, status) {
              if (status === 'OK') {
                  if (results[1]) {
                      alert(results[1].formatted_address);
                  } else {
                      alert('No results found');
                  }
              } else {
                  alert('Geocoder failed due to: ' + status);
              }
          });
      }

      //google.maps.event.addDomListener(window, 'load', initialize);
      initialize();

      google.maps.event.addListener(vm.map, 'dragend', function () {
          var latlng = {lat: vm.map.getCenter().lat(), lng: vm.map.getCenter().lng()};
          geocodeLatLng(latlng);
      });

      google.maps.event.addListener(vm.map, 'zoom_changed', function () {
          var latlng = {lat: vm.map.getCenter().lat(), lng: vm.map.getCenter().lng()};
          geocodeLatLng(latlng);
      });

  }

}());
