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
  function locationFactory(Restangular){
    
    return {
        postDriverLocation: postDriverLocation,
        saveCurrectLoction: saveCurrectLoction
    };

    function postDriverLocation(data){
      return Restangular.all('DriverLocation').post(data);
    }

    function saveCurrectLoction() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function(position) {
                var pos = {
                    Location: {
                        Latitude: position.coords.latitude,
                        Longitude: position.coords.longitude
                    }
                };
                postDriverLocation(pos);
            });
        } else {
            // Browser doesn't support Geolocation
            handleLocationError(false, infoWindow, vm.map.getCenter());
        }
    }
  }

}());
