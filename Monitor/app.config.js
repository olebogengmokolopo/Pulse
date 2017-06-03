(function () {
    'use strict';
    angular.module('pulse')
        .provider('appEnvironment', function appEnvironmentProvider() {
            this.environment = {
                serverName: 'http://pulse.local/api/',
                serverBase: 'http://pulse.local/',
                debug: 'true',
                environment: 'dev'
            };

            this.$get = function () {
                return this.environment;
            };
        })
        .config(['$urlRouterProvider', '$logProvider', '$compileProvider', 'appEnvironmentProvider', function ($urlRouterProvider, $logProvider, $compileProvider, appEnvironmentProvider) {
            $urlRouterProvider.otherwise('/home');
            $compileProvider.debugInfoEnabled(appEnvironmentProvider.environment.debug === 'true');
            $logProvider.debugEnabled(appEnvironmentProvider.environment.debug === 'true');
        }])
        .config(['localStorageServiceProvider', 'appEnvironmentProvider', function (localStorageServiceProvider, appEnvironmentProvider) {
            localStorageServiceProvider.setPrefix('pulse');
            localStorageServiceProvider.setStorageCookieDomain(appEnvironmentProvider.environment.serverBase);
            localStorageServiceProvider.setNotify(true, true);
        }])
        .config(['$httpProvider', function ($httpProvider) {
            $httpProvider.useApplyAsync(true);
            //initialize get if not there
            if (!$httpProvider.defaults.headers.get) {
                $httpProvider.defaults.headers.get = {};
            }    

            // Answer edited to include suggestions from comments
            // because previous version of code introduced browser-related errors

            //disable IE ajax request caching
            $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
            // extra
            $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
            $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
        }]);

} ());