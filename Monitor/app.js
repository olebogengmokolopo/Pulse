(function () {
    'use strict';
    angular.module('pulse')
        .run(['$rootScope', '$state', '$interpolate', 'authentication', 'toaster', function ($rootScope, $state, $interpolate,  authentication, toaster) {
            $rootScope.$state = $state;
            $rootScope.pageTitle = 'Pulse Monitor';
            $rootScope.$on('$stateChangeStart', function (e, toState, toParams, fromState, fromParams) {
                if (!authentication.isLoggedIn() && toState.name.indexOf('login') === -1) {
                    toaster.error('You are not logged in', 'Error');
                    $state.go('login');
                }
            });
            $rootScope.$on('$stateChangeSuccess', function () {
                var state = $rootScope.$state.$current;
                if (state.data && state.data.title) {
                    if (state.locals.globals.breadCrumb) {
                        state.locals.globals.breadCrumb.$promise.then(function () {
                            $rootScope.pageTitle = $interpolate(state.data.title)(state.locals.globals) + ' | Pulse Monitor';
                        });
                    } else {
                        $rootScope.pageTitle = state.data.title + ' | Pulse Monitor';
                    }
                } else {
                    $rootScope.pageTitle = 'Pulse Monitor';
                }
            });
        }])

        .controller('AppCtrl', AppController);


    AppController.$inject = ['$log', 'authentication','$rootScope'];

    function AppController($log,authentication,$rootScope) {
        var scope = this;
        scope.currentDate = Date.now();
        scope.logStartUpMessage = logStartUpMessage;
        scope.message = 'pulse application logging in debug mode';

        scope.logStartUpMessage();

        $rootScope.$watch(function () {
            return authentication.isLoggedIn();
        }, function () {
            scope.isLoggedIn = authentication.isLoggedIn();

        }, true);

        /* Implementations */

        function logStartUpMessage() {
            $log.debug(scope.message);
            $log.debug('user is logged in:' + scope.isLoggedIn);
        }
    }

})();
