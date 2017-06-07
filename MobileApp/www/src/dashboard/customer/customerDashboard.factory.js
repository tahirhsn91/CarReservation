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

    var directionsDisplay = null;
    var directionsService = new google.maps.DirectionsService();
    var driverMarkers = [];
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
                // if (activeRide.ride) {
                    var posOptions = {timeout: 10000, enableHighAccuracy: true};
                    $cordovaGeolocation.getCurrentPosition(posOptions).then(function (position) {
                        var ride = {
                            Source: {
                                Latitude: position.coords.latitude,
                                Longitude: position.coords.longitude
                            }
                        };
                        rideNowHeartBeat(ride).then(function (result) {
                            activeRide.ride = result;
                            removeDriverMarkers();
                            removeRoute();
                            addDriverMarker();
                            rideHeartBeat();
                        });
                    }, function (error) {
                        rideHeartBeat();
                    });
                // }
                // else {
                //     GetActiveRide().then(function (result) {
                //         activeRide.ride = result;
                //         removeDriverMarkers();
                //         removeRoute();
                //         addDriverMarker();
                //         createRoute();
                //         rideHeartBeat();
                //     }, function (error) {
                //         rideHeartBeat();
                //     });
                // }
            }
            else {
                rideHeartBeat();
            }
        }, 2000);
    }
    
    function rideNow(data){
      return Restangular.all('Ride').post(data);
    }

    function rideNowHeartBeat(data){
      return Restangular.all('Ride/RideNow/HeartBeat').post(data);
    }

    function GetActiveRide() {
        return Restangular.one('Ride/GetActiveRide').get();
    }

    function addDriverMarker() {
        if (activeRide.ride && activeRide.ride.Driver && activeRide.ride.Driver.DriverLocation && activeRide.ride.Driver.DriverLocation.Location) {
            var myLatLng = {lat: activeRide.ride.Driver.DriverLocation.Location.Latitude, lng: activeRide.ride.Driver.DriverLocation.Location.Longitude};
            var marker = new google.maps.Marker({
                position: myLatLng,
                map: customerMap.map,
                title: 'Driver Location'
            });
            driverMarkers.push(marker);
        }
    }
    
    function removeDriverMarkers() {
        if(driverMarkers && driverMarkers.length > 0) {
            for (var i = 0; i < driverMarkers.length; i++) {
                driverMarkers[i].setMap(null);
            }
        }
        driverMarkers = [];
    }

    function removeRoute() {
        if(directionsDisplay != null) {
            directionsDisplay.setMap(null);
            directionsDisplay = null;
            directionsDisplay = new google.maps.DirectionsRenderer();
        }
        else {
            directionsDisplay = new google.maps.DirectionsRenderer();
        }
    }

    function createRoute() {
        if (activeRide.ride && activeRide.ride.RideStatusId === 2) {
            var sourceMark = {lat: activeRide.ride.Source.Latitude, lng: activeRide.ride.Source.Longitude};
            var destinationMark = {lat: activeRide.ride.Destination.Latitude, lng: activeRide.ride.Destination.Longitude};

            directionsDisplay.setMap(customerMap.map);
            var request = {
                origin: sourceMark,
                destination: destinationMark,
                travelMode: google.maps.TravelMode.DRIVING
            };
            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                }
            });
        }
    }
  }

}());
