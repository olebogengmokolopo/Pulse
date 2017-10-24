(function () {
    'use strict';

    angular.module('pulse.toaster')
        .config(function (toastrConfig) {
            angular.extend(toastrConfig, {
                allowHtml: true,
                closeButton: false,
                closeHtml: '<button>&times;</button>',
                containerId: 'toast-container',
                extendedTimeOut: 1000,
                iconClasses: {
                    error: 'toast-error',
                    info: 'toast-info',
                    success: 'toast-success',
                    warning: 'toast-warning'
                },
                messageClass: 'toast-message',
                positionClass: 'toast-bottom-right',
                tapToDismiss: true,
                timeOut: 3000,
                titleClass: 'toast-title',
                toastClass: 'toast',
                templates: {
                    toast: 'modules/shared/toaster/toast.html',
                    progressbar: 'directives/progressbar/progressbar.html'
                }
            });
        });

})();