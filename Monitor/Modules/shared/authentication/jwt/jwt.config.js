(function () {
    'use strict';

    angular.module('pulse.authentication.jwt')
        .config(function ($httpProvider) {
            $httpProvider.interceptors.push('jwtAuthInterceptor');
        });

})();