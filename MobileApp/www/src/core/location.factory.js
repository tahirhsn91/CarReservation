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
    
    return {
        postDriverLocation: postDriverLocation,
        saveCurrentLoction: saveCurrentLoction,
        logCurrentLocation: logCurrentLocation
    };

    function postDriverLocation(data){
      return Restangular.all('DriverLocation/HeartBeat').post(data);
    }

    function logCurrentLocation() {
        $timeout(function () {
            if (authFactory.getUser()) {
                saveCurrentLoction();
                logCurrentLocation();
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
            postDriverLocation(pos);
        }, function(err) {
            // error
        });

        // if (navigator.geolocation) {
        //     navigator.geolocation.getCurrentPosition(function(position) {
        //         var pos = {
        //             Location: {
        //                 Latitude: position.coords.latitude,
        //                 Longitude: position.coords.longitude
        //             }
        //         };
        //         postDriverLocation(pos);
        //     });
        // } else {
        //     // Browser doesn't support Geolocation
        //     handleLocationError(false, infoWindow, vm.map.getCenter());
        // }
    }
  }

}());
