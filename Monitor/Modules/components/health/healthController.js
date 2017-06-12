(function () {
    'use strict';

    angular
        .module('pulse.health.controllers')
        .controller('HealthController', HealthController);

    HealthController.$inject = ['$log', 'appEnvironment', 'toaster'];

    function HealthController($log, appEnvironment, toaster) {
        var scope = this;

        /* IMPLEMENTATIONS */
        scope.environment = appEnvironment.environment;
    }
})();
