(function () {

    'use strict';

    var appRegex = {
        email: "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"
    };

    angular
        .module('app.common')
        .constant('appRegex', appRegex);
}());