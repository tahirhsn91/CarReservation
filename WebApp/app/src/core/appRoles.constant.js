(function () {

    'use strict';

    var appUserRole = {
        SuperAdmin: 'SuperAdministrator',
        Admin: 'Administrator',
        Supervisor: 'Supervisor',
        Driver: 'Driver',
        Customer: 'Customer',
        All: 'All'
    };

    angular
        .module('app.core')
        .constant('appUserRole', appUserRole);
}());