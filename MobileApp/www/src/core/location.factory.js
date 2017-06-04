/**
 * @ngdoc factory
 * @name app.wallet.factory:creditCardFactory
 * @description Credit Card Factory
 */

(function(){

  'use strict';

  angular.module('app.core')
    .factory('locationFactory', locationFactory);

  /* @ngInject */
  function locationFactory(Restangular, $timeout, $cordovaGeolocation, authFactory) {

    var directionsService = new google.maps.DirectionsService();
    var customerMarkers = [];
    var currentRide = {};
    var driverMap = {};
    logCurrentLocation();

    return {
        postDriverLocation: postDriverLocation,
        saveCurrentLocation: saveCurrentLocation,
        logCurrentLocation: logCurrentLocation,
        currentRide: currentRide,
        driverMap: driverMap
    };

    function postDriverLocation(data){
      return Restangular.all('DriverLocation/HeartBeat').post(data);
    }

    function logCurrentLocation() {
        $timeout(function () {
            if (authFactory.getUser() && authFactory.getUser().Role === 'Driver') {
                saveCurrentLocation();
            }
            else {
                logCurrentLocation();
            }
        }, 2000)
    }

    function saveCurrentLocation() {
        var posOptions = {timeout: 10000, enableHighAccuracy: true};
        $cordovaGeolocation.getCurrentPosition(posOptions).then(function (position) {
            var pos = {
                Location: {
                    Latitude: position.coords.latitude,
                    Longitude: position.coords.longitude
                }
            };
            postDriverLocation(pos).then(function (result) {
                if (result) {
                    currentRide.data = result;

                    var myLatLng = {lat: result.Source.Latitude, lng: result.Source.Longitude};
                    var currentLatLng = {lat: position.coords.latitude, lng: position.coords.longitude};
                    removeCustomerMarkers();
                    customerMarkers = [];
                    var marker = new google.maps.Marker({
                        position: myLatLng,
                        map: driverMap.map,
                        title: 'Customer Location'
                    });
                    customerMarkers.push(marker);

                    createRoute(myLatLng, currentLatLng);
                }

                logCurrentLocation();
            }, function (error) {
                logCurrentLocation();
            });
        }, function(err) {
            logCurrentLocation();
        });
    }

    function removeCustomerMarkers() {
        if(customerMarkers && customerMarkers.length > 0) {
            for (var i = 0; i < customerMarkers.length; i++) {
                customerMarkers[i].setMap(null);
            }
        }
    }

    function createRoute(myLatLng, currentLatLng) {
        var directionsDisplay = new google.maps.DirectionsRenderer();
        directionsDisplay.setMap(driverMap.map);
        var request = {
            origin: currentLatLng,
            destination: myLatLng,
            travelMode: google.maps.TravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
            }
        });
    }
  }
}());
