(function () {

    'use strict';

    var appRegex = {
        email: "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"
    };

    angular
        .module('app.core')
        .constant('appRegex', appRegex);
}());