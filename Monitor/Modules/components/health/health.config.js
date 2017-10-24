(function () {
    'use strict';

    angular
        .module('pulse.health')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider'];

    function routeConfig($stateProvider) {

        $stateProvider
            .state('health', {
                url: '/{tenantId}/health',
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