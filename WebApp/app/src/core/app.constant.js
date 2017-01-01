(function () {

    'use strict';

    var appFormats = {
        Date: 'dd-MMM-yyyy',
        DateAsFilter: 'date:"dd-MMM-yyyy"'
    };

    angular
        .module('app.core')
        .constant('appFormats', appFormats);
}());