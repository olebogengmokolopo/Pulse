(function () {
    'use strict';

    angular.module('pulse.authentication.basic')
        .config(function ($httpProvider) {
            $httpProvider.interceptors.push('basicAuthHttpInterceptor');
        });

})();