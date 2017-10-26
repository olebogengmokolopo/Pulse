(function () {
    'use strict';

    angular
        .module('pulse.sensors.diskSpace.controllers')
        .controller('DiskSpaceController', DiskSpaceController);

    DiskSpaceController.$inject = ['$log', 'appEnvironment', 'toaster', 'DiskSpace'];

    function DiskSpaceController($log, appEnvironment, toaster, DiskSpace) {
        var scope = this;
        scope.environment = appEnvironment.environment;

        /* IMPLEMENTATIONS */
        scope.getDiskSpaceSummary = getDiskSpaceSummary;

        function getDiskSpaceSummary()
        {
            return DiskSpace.getDiskSummaries({tenantId: 48});
        }

        scope.drives = scope.getDiskSpaceSummary();
    }
})();