(function () {

    'use strict';

    var appModules = {
            Administrator: {
                VehicleTransmission: ['Name', 'Code'],
                VehicleModel: ['Name', 'Code', {
                    'Field':'VehicleMaker', 'Type': 'DropDown'
                    }],
                VehicleMaker: ['Name', 'Code'],
                VehicleFeature: ['Name', 'Code'],
                VehicleBodyType: ['Name', 'Code'],
                VehicleAssembly: ['Name', 'Code'],
                TravelUnit: ['Name', 'Code'],
                RideStatus: ['Name', 'Code'],
                DriverStatus: ['Name', 'Code'],
                DistanceUnit: ['Name', 'Code'],
                Currency: ['Name', 'Code', 'Rate',{
                    'Field':'Country', 'Type': 'DropDown'
                    }],
                Color: ['Name', 'Code'],
                Country: ['Name', 'Code'],
                State: ['Name', 'Code', {
                    'Field':'Country', 'Type': 'DropDown'
                    }],
                City: ['Name', 'Code', {
                    'Field':'State', 'Type': 'DropDown'
                    }]
            },
            Supervisor: {
                Vehicle: [  'RegistrationNumber', 
                            { 'Field': 'RegistrationDate', 'Type': 'Date'}, 
                            { 'Field':'PassengerCapacity', 'Type': 'Number'},
                            { 'Field':'Country', 'Type': 'DropDown', 'OnSelect': 'State'},
                            { 'Field':'State', 'Type': 'DropDown', 'OnSelect': 'City'},
                            { 'Field':'City', 'Type': 'DropDown'},
                            { 'Field':'Color', 'Type': 'DropDown'},
                            { 'Field':'VehicleBodyType', 'Type': 'DropDown'},
                            { 'Field':'VehicleAssembly', 'Type': 'DropDown'},
                            { 'Field':'VehicleTransmission', 'Type': 'DropDown'},
                            { 'Field':'VehicleModel', 'Type': 'DropDown'},
                            { 'Field':'VehicleFeature', 'Type': 'MultiDropDown'}
                            
                        ],
                Package: [  'Name',
                            'Code', 
                            { 'Field':'TravelUnit', 'Type': 'Ignore'},
                            { 'Field':'Currency', 'Type': 'Ignore'},
                            { 'Field':'VehicleAssembly', 'Type': 'MultiDropDown'},
                            { 'Field':'VehicleBodyType', 'Type': 'MultiDropDown'},
                            { 'Field':'VehicleFeature', 'Type': 'MultiDropDown'},
                            { 'Field':'VehicleModel', 'Type': 'MultiDropDown'},
                            { 'Field':'VehicleTransmission', 'Type': 'MultiDropDown'}
                            
                        ]
            },
            BaseRoute: {
                Administrator: '',
                Supervisor: 'supervisor'
            }
    };

    angular
        .module('app.common')
        .constant('appModules', appModules);
}());