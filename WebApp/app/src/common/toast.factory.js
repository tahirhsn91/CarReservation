/**
 * @ngdoc service
 * @name app.notifications.toast
 * @description This service implement material toast message box for the interface
 */

(function () {

    'use strict';

    angular
        .module('app.common')
        .factory('toast', toast);

    /* @ngInject */
    function toast(ngToast) {
        return {
            success: success,
            error: error,
            info: info,
            dismiss: dismiss
        };

        function success(message) {
            var alert = {
                className: 'success toast-success',
                content: message
            };
            ngToast.create(alert);
        }

        function info(message) {
            var alert = {
                className: 'info toast-info',
                content: message
            };
            ngToast.create(alert);
        }

        function error(message) {
            var alert = {
                className: 'warning toast-warning',
                content: message
            };
            ngToast.create(alert);
        }

        function dismiss() {
            ngToast.dismiss();
        }
    }

}());
