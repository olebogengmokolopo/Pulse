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
    }
})();
