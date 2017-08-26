(function () {
    'use strict';

    angular
        .module('pulse.register')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider'];

    function routeConfig($stateProvider) {

        $stateProvider
            .state('register', {
                url: '/register',
                views: {
                    'main': {
                        templateUrl: 'modules/components/register/register.tpl.html',
                        controller: 'RegisterController',
                        controllerAs: 'register'
                    }
                },
                data: {
                    title: 'Register',
                    state: 'register'
                }
            });

    }

})();