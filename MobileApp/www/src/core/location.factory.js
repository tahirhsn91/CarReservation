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
  function locationFactory(Restangular, $timeout, $cordovaGeolocation, authFactory){
    var currentRide = null;
    logCurrentLocation();

    return {
        postDriverLocation: postDriverLocation,
        saveCurrentLoction: saveCurrentLoction,
        logCurrentLocation: logCurrentLocation,
        currentRide: currentRide
    };

    function postDriverLocation(data){
      return Restangular.all('DriverLocation/HeartBeat').post(data);
    }

    function logCurrentLocation() {
        $timeout(function () {
            if (authFactory.getUser() && authFactory.getUser().Role === 'Driver') {
                saveCurrentLoction();
            }
        }, 2000)
    }

    function saveCurrentLoction() {
        var posOptions = {timeout: 10000, enableHighAccuracy: false};
        $cordovaGeolocation.getCurrentPosition(posOptions).then(function (position) {
            var pos = {
                Location: {
                    Latitude: position.coords.latitude,
                    Longitude: position.coords.longitude
                }
            };
            postDriverLocation(pos).then(function (result) {
                currentRide = result;
                logCurrentLocation();
            });
        }, function(err) {
        });
    }
  }

}());
