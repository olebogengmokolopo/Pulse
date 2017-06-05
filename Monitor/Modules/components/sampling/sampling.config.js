(function () {
    'use strict';

    angular
        .module('pulse.sampling')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider'];

    function routeConfig($stateProvider) {

        $stateProvider
            .state('sampling', {
                url: '/sampling',
                views: {
                    'main': {
                        templateUrl: 'modules/components/sampling/sampling.tpl.html',
                        controller: 'SamplingController',
                        controllerAs: 'sampling'
                    }
                },
                data: {
                    title: 'sampling',
                    state: 'sampling'
                }
            });

    }

})();