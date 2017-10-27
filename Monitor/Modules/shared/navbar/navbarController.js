(function () {
    'use strict';

    angular
        .module('pulse.navbar.controller', [])
        .controller('NavBarController', NavBarController);

    NavBarController.$inject = ['$log', 'toaster', 'authentication', '$rootScope', '$state', 'Account', 'localStorageService'];

    function NavBarController($log, toaster, authentication, $rootScope, $state, Account, localStorageService) {

        var scope = this;
        scope.logout = logout;
        scope.gotoHealth = gotoHealth;
        scope.switchTenancy = switchTenancy;

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
                scope.currentTenancy = currentUser.TenancyUserRoles[0].Tenancy;
                scope.availableTenancies = currentUser.TenancyUserRoles.map(function (tenancyUserRole) {
                    return tenancyUserRole.Tenancy;
                });
                scope.currentUser = currentUser.FullName;
                console.log(scope.availableTenancies);
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

        function gotoHealth(){
            var params = {
                tenancyId: scope.currentTenancy.TenancyId
            };
            $state.go('health', params);
        }

        function switchTenancy(tenancyIndex){

            var currentUser = localStorageService.get('currentUser');
            scope.currentTenancy = currentUser.TenancyUserRoles[tenancyIndex].Tenancy;

            console.log(tenancyIndex);
            console.log(scope.currentTenancy);

            $state.params.tenancyId = scope.currentTenancy.TenancyId;
            $state.reload( );
        }
    }
})();
