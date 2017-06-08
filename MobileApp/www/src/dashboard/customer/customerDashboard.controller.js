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
    vm.letsGo = letsGo;
    vm.cancelRide = cancelRide;
    vm.endRide = endRide
    vm.rideSource = null;
    vm.MainSourceAddress = "";
    vm.MainDestinationAddress = "";

    function initialize() {
      var mapOptions = {
        zoom: 14,
        center: new google.maps.LatLng(52.5498783, 13.425209099999961),
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        disableDefaultUI: true
      };
      vm.geocoder = new google.maps.Geocoder;
      customerDashboardFactory.customerMap.map = new google.maps.Map(document.getElementById('map_canvas'), mapOptions);
      vm.activeRide = customerDashboardFactory.activeRide;
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
      var posOptions = {timeout: 10000, enableHighAccuracy: false};
      $cordovaGeolocation.getCurrentPosition(posOptions).then(function (position) {
          // var lat  = position.coords.latitude;
          // var long = position.coords.longitude;
          var pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
          };
          geocodeLatLng(pos);
          customerDashboardFactory.customerMap.map.setCenter(pos);
      }, function(err) {
          // error
      });
    }

    function rideNow(){
        vm.rideSource = {
            Latitude: customerDashboardFactory.customerMap.map.getCenter().lat(),
            Longitude: customerDashboardFactory.customerMap.map.getCenter().lng()
        };
    }
    
    function cancelRide() {
        navigator.geolocation.getCurrentPosition(function (position) {
            var ride = {
                Destination: {
                    Latitude: position.coords.latitude,
                    Longitude: position.coords.longitude
                }
            };
            customerDashboardFactory.cancelRide(ride).then(function (result) {
                customerDashboardFactory.processRide(result, position);
                vm.MainSourceAddress = "";
                vm.MainDestinationAddress = "";
                vm.rideSource = null;
            });
        });
    }
    
    function endRide() {
        navigator.geolocation.getCurrentPosition(function (position) {
            var ride = {
                Destination: {
                    Latitude: position.coords.latitude,
                    Longitude: position.coords.longitude
                }
            };
            customerDashboardFactory.endRide(ride).then(function (result) {
                customerDashboardFactory.processRide(result, position);
                vm.MainSourceAddress = "";
                vm.MainDestinationAddress = "";
                vm.rideSource = null;
            });
        });
    }

    function letsGo() {
        navigator.geolocation.getCurrentPosition(function (position) {
            var ride = {
                Source: vm.rideSource,
                Destination: {
                    Latitude: customerDashboardFactory.customerMap.map.getCenter().lat(),
                    Longitude: customerDashboardFactory.customerMap.map.getCenter().lng()
                }
            };
            customerDashboardFactory.rideNow(ride).then(function (result) {
                customerDashboardFactory.processRide(result, position);
                vm.MainSourceAddress = "";
                vm.MainDestinationAddress = "";
                vm.rideSource = null;
            });
        });
    }

    function geocodeLatLng(latlng) {
      vm.geocoder.geocode({'location': latlng}, function(results, status) {
        if (status === 'OK') {
          if (results[1]) {
              if (!vm.activeRide.ride && !vm.rideSource) {
                  vm.MainSourceAddress = results[1].formatted_address
              }
              else if (!vm.activeRide.ride && vm.rideSource) {
                  vm.MainDestinationAddress = results[1].formatted_address
              }
          }
        } else {
          // alert('Geocoder failed due to: ' + status);
        }
      });
    }

    //google.maps.event.addDomListener(window, 'load', initialize);
    initialize();

    google.maps.event.addListener(customerDashboardFactory.customerMap.map, 'dragend', function () {
      var latlng = {lat: customerDashboardFactory.customerMap.map.getCenter().lat(), lng: customerDashboardFactory.customerMap.map.getCenter().lng()};
      geocodeLatLng(latlng);
    });

    google.maps.event.addListener(customerDashboardFactory.customerMap.map, 'zoom_changed', function () {
      var latlng = {lat: customerDashboardFactory.customerMap.map.getCenter().lat(), lng: customerDashboardFactory.customerMap.map.getCenter().lng()};
      geocodeLatLng(latlng);
    });
    
  }

}());
