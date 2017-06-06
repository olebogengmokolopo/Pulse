(function () {
    'use strict';

    angular
        .module('pulse.sampling.controllers')
        .controller('SamplingController', SamplingController);

    SamplingController.$inject = ['$log', 'appEnvironment', 'toaster'];

    function SamplingController($log, appEnvironment, toaster) {

        var scope = this;

        /* IMPLEMENTATIONS */
        scope.environment = appEnvironment.environment;

        scope.drives = [
            {
                symbol : "C:/",
                label : "OS Drive",
                totalSpace : 1234,
                freeSpace : 456,
                usedSpace : 778,
                alertType : "success"
            },
            {
                symbol : "D:/",
                label : "Applications",
                totalSpace : 5678,
                freeSpace : 910,
                usedSpace : 4768,
                alertType : "danger"
            },
            {
                symbol : "E:/",
                label : "Logging",
                totalSpace : 123,
                freeSpace : 34,
                usedSpace : 89,
                alertType : "warning"
            }
        ]
    }
})();
