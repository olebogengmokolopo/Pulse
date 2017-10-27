(function () {
    'use strict';

    angular
        .module('pulse.health.controllers')
        .controller('HealthController', HealthController);

    HealthController.$inject = ['$log', 'appEnvironment', 'toaster', '$stateParams'];

    function HealthController($log, appEnvironment, toaster, $stateParams) {
        var scope = this;

        /* IMPLEMENTATIONS */
        scope.environment = appEnvironment.environment;
        scope.currentTenancyId = $stateParams.tenancyId;
    }
})();
