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

    var geocoder = new google.maps.Geocoder;
    var directionsDisplay = null;
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
        driverMap: driverMap,
        pickUpCustomer: pickUpCustomer,
        waitingForPayment: waitingForPayment,
        endRide: endRide
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
                currentRide.data = result;
                removeRoute();
                removeCustomerMarkers();

                if (result) {
                    if (currentRide.data) {
                        var sourceMark = {lat: result.Source.Latitude, lng: result.Source.Longitude};
                        var destinationMark = {lat: result.Destination.Latitude, lng: result.Destination.Longitude};
                        var currentLatLng = {lat: position.coords.latitude, lng: position.coords.longitude};

                        addLocationInfo(currentRide);

                        if (currentRide.data.RideStatusId === 1) {
                            createRoute(currentLatLng, sourceMark);
                        }
                        else if (currentRide.data.RideStatusId === 2) {
                            createRoute(currentLatLng, destinationMark);
                        }
                        else if (currentRide.data.RideStatusId === 3) {
                            var marker = new google.maps.Marker({
                                position: destinationMark,
                                map: driverMap.map,
                                title: 'Customer Location'
                            });
                            customerMarkers.push(marker);
                        }
                    }
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
        customerMarkers = [];
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

    function createRoute(originMark, destinationMark) {
        directionsDisplay.setMap(driverMap.map);
        var request = {
            origin: originMark,
            destination: destinationMark,
            travelMode: google.maps.TravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
            }
        });
    }

    function pickUpCustomer() {
        Restangular.all('RideStatus/ChangeStatusToRiding/' + currentRide.data.Id).post({}).then(function (response) {
        });
    }

    function waitingForPayment() {
        Restangular.all('RideStatus/ChangeStatusToWaitingForPayment/' + currentRide.data.Id).post({}).then(function (response) {
        });
    }

    function endRide() {
        Restangular.all('RideStatus/ChangeStatusToRideOver/' + currentRide.data.Id).post({}).then(function (response) {
        });
    }

      function addLocationInfo(ride) {
          var sourceLatLng = {lat: ride.data.Source.Latitude, lng: ride.data.Source.Longitude};
          var destinationLatLng = {lat: ride.data.Destination.Latitude, lng: ride.data.Destination.Longitude};

          geocoder.geocode({'location': sourceLatLng}, function(results, status) {
              if (status === 'OK') {
                  if (results[1]) {
                      ride.SourceAddress = results[1].formatted_address;
                  }
              }
          });

          geocoder.geocode({'location': destinationLatLng}, function(results, status) {
              if (status === 'OK') {
                  if (results[1]) {
                      ride.DestinationAddress = results[1].formatted_address;
                  }
              }
          });
      }
  }
}());
