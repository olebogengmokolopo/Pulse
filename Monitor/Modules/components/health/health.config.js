(function () {
    'use strict';

    angular
        .module('pulse.health')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider'];

    function routeConfig($stateProvider) {

        $stateProvider
            .state('health', {
                url: '/health/{tenantId}',
                views: {
                    'main': {
                        templateUrl: 'modules/components/health/health.tpl.html',
                        controller: 'HealthController',
                        controllerAs: 'health'
                    }
                },
                data: {
                    title: 'Health',
                    state: 'health'
                }
            });
    }
})();