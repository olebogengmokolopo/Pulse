(function () {
    'use strict';

    angular
        .module('pulse.navbar.controller', [])
        .controller('NavBarController', NavBarController);

    NavBarController.$inject = ['$log', 'toaster', 'authentication', '$rootScope', '$state', 'Account', 'localStorageService'];

    function NavBarController($log, toaster, authentication, $rootScope, $state, Account, localStorageService) {

        var scope = this;
        scope.logout = logout;

        scope.authentication = {};
        setupUser();

        $rootScope.$on('userLoggedInStatusChangedReloadNavBar', function () {
            getRoles();
            setupUser();
        });

        function getRoles() {
            scope.authentication.roles = authentication.getClaims();
        }

        function hasRole(role) {
            if (!scope.authentication.roles) {
                getRoles();
            }
            if (!scope.authentication.roles) {
                return false;
            }
            return (scope.authentication.roles.indexOf(role) > -1);
        }

        function setupUser() {
            scope.hasAdminRole = hasRole('Admin');
            scope.hasConfigurationRole = hasRole('Configuration');
            scope.isLoggedIn = authentication.isLoggedIn();

            scope.hasIncidentResolversRole = hasRole('IncidentResolvers');
            scope.hasUserRole = hasRole('User');
            var currentUser = localStorageService.get('currentUser');
            if (currentUser) {
                scope.currentUser = currentUser.FullName;
            }
        }

        function logout() {
            $state.go('login');
            authentication.logout().then(function () {
                $rootScope.$broadcast('userLoggedInStatusChangedReloadNavBar');
            });
            getRoles();
            setupUser();
        }
    }
})();
