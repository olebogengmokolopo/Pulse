(function () {
    'use strict';

    angular.module('pulse.common.authentication.jwt')
        .config(function ($httpProvider) {
            $httpProvider.interceptors.push('jwtAuthInterceptor');
        });

})();