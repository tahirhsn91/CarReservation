(function () {

    'use strict';

    var appModules = {
        VehicleTransmission: ['Name', 'Code'],
        VehicleModel: ['Name', 'Code'],
        VehicleMaker: ['Name', 'Code'],
        VehicleFeature: ['Name', 'Code'],
        VehicleBodyType: ['Name', 'Code'],
        VehicleAssembly: ['Name', 'Code'],
        TravelUnit: ['Name', 'Code'],
        RideStatus: ['Name', 'Code'],
        DriverStatus: ['Name', 'Code'],
        DistanceUnit: ['Name', 'Code'],
        Currency: ['Name', 'Code', 'Rate',{
            'Field':'Country'
            }],
        Color: ['Name', 'Code'],
        Country: ['Name', 'Code'],
        State: ['Name', 'Code', {
            'Field':'Country'
            }],
        City: ['Name', 'Code', {
            'Field':'State'
            }]
    };

    angular
        .module('app.common')
        .constant('appModules', appModules);
}());