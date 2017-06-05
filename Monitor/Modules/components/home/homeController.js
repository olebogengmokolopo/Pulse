(function () {
    'use strict';

    angular
        .module('pulse.home.controllers')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$log', 'appEnvironment', 'toaster'];

    function HomeController($log, appEnvironment, toaster) {

        var scope = this;

        /* IMPLEMENTATIONS */
        scope.environment = appEnvironment.environment;
    }
})();
