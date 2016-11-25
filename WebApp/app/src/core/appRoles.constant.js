(function () {

    'use strict';

    var appUserRole = {
        Driver: 'Driver',
        Customer: 'Customer',
        All: 'All'
    };

    angular
        .module('app.core')
        .constant('appUserRole', appUserRole);
}());