(function () {
    'use strict';

    angular
        .module('pulse.login')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider'];

    function routeConfig($stateProvider) {

        $stateProvider
            .state('login', {
                url: '/login',
                views: {
                    'main': {
                        templateUrl: 'modules/components/login/login.tpl.html',
                        controller: 'LoginController',
                        controllerAs: 'login'
                    }
                },
                data: {
                    title: 'Login',
                    state: 'login'
                }
            });

    }

})();