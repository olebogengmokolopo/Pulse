(function () {
    'use strict';

    angular.module('pulse.common.authentication.basic')
        .config(function ($httpProvider) {
            $httpProvider.interceptors.push('basicAuthHttpInterceptor');
        });

})();