(function () {
    'use strict';

    angular
        .module('pulse.sensors.diskSpace.controllers')
        .controller('DiskSpaceController', DiskSpaceController);

    DiskSpaceController.$inject = ['$log', 'appEnvironment', 'toaster', 'DiskSpace', '$scope'];

    function DiskSpaceController($log, appEnvironment, toaster, DiskSpace, $scope) {
        var scope = this;
        scope.environment = appEnvironment.environment;
        scope.currentTenancyId = $scope.$parent.health.currentTenancyId;

        scope.getDiskSpaceSummary = getDiskSpaceSummary;

        function getDiskSpaceSummary()
        {
            return DiskSpace.getDiskSummaries({tenantId: scope.currentTenancyId});
        }

        scope.drives = scope.getDiskSpaceSummary();
    }
})();