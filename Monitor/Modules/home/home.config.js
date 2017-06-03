(function () {
    'use strict';

    angular
        .module('pulse.home')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider'];

    function routeConfig($stateProvider) {

        $stateProvider
            .state('home', {
                url: '/home',
                views: {
                    'main': {
                        templateUrl: 'modules/home/templates/home.tpl.html',
                        controller: 'HomeController',
                        controllerAs: 'home'
                    }
                },
                data: {
                    title: 'Home',
                    state: 'home'
                }
            });

    }

})();