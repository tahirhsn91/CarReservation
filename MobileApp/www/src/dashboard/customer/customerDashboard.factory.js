/**
 * @ngdoc factory
 * @name app.wallet.factory:customerDashboardFactory
 * @description Customer Dashboard Factory
 */

(function(){

  'use strict';

  angular.module('app.core')
    .factory('customerDashboardFactory', customerDashboardFactory);

  /* @ngInject */
  function customerDashboardFactory(Restangular, $timeout, $cordovaGeolocation, authFactory){

    var activeRide = {};
    var customerMap = {};
    init();
    
    return {
        rideNow: rideNow,
        GetActiveRide: GetActiveRide,
        activeRide: activeRide,
        customerMap: customerMap
    };

    function init(){
        rideHeartBeat();
    }

    function rideHeartBeat() {
        $timeout(function () {
            if (authFactory.getUser() && authFactory.getUser().Role === 'Customer') {
                if (activeRide.ride) {
                    var posOptions = {timeout: 10000, enableHighAccuracy: true};
                    $cordovaGeolocation.getCurrentPosition(posOptions).then(function (position) {
                        var ride = {
                            Source: {
                                Latitude: position.coords.latitude,
                                Longitude: position.coords.longitude
                            }
                        };
                        rideNow(ride).then(function (result) {
                            activeRide.ride = result;
                            addDriverMarker();
                            rideHeartBeat();
                        });
                    }, function (error) {
                        rideHeartBeat();
                    });
                }
                else {
                    GetActiveRide().then(function (result) {
                        activeRide.ride = result;
                        addDriverMarker();
                        rideHeartBeat();
                    }, function (error) {
                        rideHeartBeat();
                    });
                }
            }
            else {
                rideHeartBeat();
            }
        }, 2000);
    }
    
    function rideNow(data){
      return Restangular.all('Ride/RideNow/HeartBeat').post(data);
    }

    function GetActiveRide() {
        return Restangular.one('Ride/GetActiveRide/HeartBeat').get();
    }

    function addDriverMarker() {
        if (activeRide.ride.Driver && activeRide.ride.Driver.DriverLocation && activeRide.ride.Driver.DriverLocation.Location) {
            var myLatLng = {lat: activeRide.ride.Driver.DriverLocation.Location.Latitude, lng: activeRide.ride.Driver.DriverLocation.Location.Longitude};
            new google.maps.Marker({
                position: myLatLng,
                map: customerMap.map,
                title: 'Customer Location'
            });
        }
    }
  }

}());
