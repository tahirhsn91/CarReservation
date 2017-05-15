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
        var posOptions = {timeout: 10000, enableHighAccuracy: false};
        $cordovaGeolocation.getCurrentPosition(posOptions).then(function (position) {
            var pos = {
                Location: {
                    Latitude: position.coords.latitude,
                    Longitude: position.coords.longitude
                }
            };
            postDriverLocation(pos).then(function (result) {
                currentRide.data = result;

                var myLatLng = {lat: result.Source.Latitude, lng: result.Source.Longitude};
                new google.maps.Marker({
                    position: myLatLng,
                    map: driverMap.map,
                    title: 'Customer Location'
                });

                logCurrentLocation();
            });
        }, function(err) {
        });
    }
  }
}());
