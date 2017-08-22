(function () {
    'use strict';

    angular
        .module('pulse.sensors.diskSpace.controllers')
        .controller('DiskSpaceController', DiskSpaceController);

    DiskSpaceController.$inject = ['$log', 'appEnvironment', 'toaster'];

    function DiskSpaceController($log, appEnvironment, toaster) {
        var scope = this;
        scope.environment = appEnvironment.environment;

        /* IMPLEMENTATIONS */
        scope.getDiskSpaceSummary = getDiskSpaceSummary;

        function getDiskSpaceSummary()
        {
            return [
                {
                    volume: "C:/",
                    label: "OS Drive",
                    totalSpace: 1234,
                    freeSpace: 456,
                    usedSpace: 778,
                    alertType: "success"
                },
                {
                    volume: "D:/",
                    label: "Applications",
                    totalSpace: 5678,
                    freeSpace: 910,
                    usedSpace: 4768,
                    alertType: "danger"
                },
                {
                    volume: "E:/",
                    label: "Logging",
                    totalSpace: 123,
                    freeSpace: 34,
                    usedSpace: 89,
                    alertType: "warning"
                }
            ];
        }

        scope.drives = scope.getDiskSpaceSummary();
    }
})();