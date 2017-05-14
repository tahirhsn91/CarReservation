/**
 * @ngdoc controller
 * @name app.customerDashboard.controller:CustomerDashboardCtrl
 * @description Customer Dashboard controller
 */

(function(){

  'use strict';

  angular.module('app.customerDashboard')
    .controller('CustomerDashboardCtrl', CustomerDashboardCtrl);

  /* @ngInject */
  function CustomerDashboardCtrl($cordovaGeolocation, customerDashboardFactory){
    var vm = this;

    vm.getCurrectLoction = getCurrectLoction;
    vm.rideNow = rideNow;
    vm.activeRide = {};

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

      vm.activeRide = customerDashboardFactory.activeRide;
    }

    function handleLocationError(browserHasGeolocation, infoWindow, pos) {
      infoWindow.setPosition(pos);
      infoWindow.setContent(browserHasGeolocation ?
                            'Error: The Geolocation service failed.' :
                            'Error: Your browser doesn\'t support geolocation.'
                            );
    }

    function getCurrectLoction() {
      var posOptions = {timeout: 10000, enableHighAccuracy: false};
      $cordovaGeolocation.getCurrentPosition(posOptions).then(function (position) {
          // var lat  = position.coords.latitude;
          // var long = position.coords.longitude;
          var pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
          };
          vm.map.setCenter(pos);
      }, function(err) {
          // error
      });


      // // Try HTML5 geolocation.
      // if (navigator.geolocation) {
      //   navigator.geolocation.getCurrentPosition(function(position) {
      //     var pos = {
      //       lat: position.coords.latitude,
      //       lng: position.coords.longitude
      //     };
      //     vm.map.setCenter(pos);
      //   }, function() {
      //     // handleLocationError(true, infoWindow, vm.map.getCenter());
      //   });
      // } else {
      //   // Browser doesn't support Geolocation
      //   // handleLocationError(false, infoWindow, vm.map.getCenter());
      // }
    }

    function rideNow(){
      // var latlng = {lat: vm.map.getCenter().lat(), lng: vm.map.getCenter().lng()};
      // geocodeLatLng(latlng);
        var posOptions = {timeout: 10000, enableHighAccuracy: false};
        $cordovaGeolocation.getCurrentPosition(posOptions).then(function (position) {
            var ride = {
                Source: {
                    Latitude: position.coords.latitude,
                    Longitude: position.coords.longitude
                },
                Destination: {
                    Latitude: vm.map.getCenter().lat(),
                    Longitude: vm.map.getCenter().lng()
                }
            };
            customerDashboardFactory.rideNow(ride);
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
