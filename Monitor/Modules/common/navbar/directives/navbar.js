(function () {
    'use strict';

    angular
        .module('pulse.common.navbar')
        .directive('navbar', navbar);

    function navbar() {

        var directive = {
            controller: NavbarController,
            controllerAs: 'navbar',
            templateUrl: 'modules/common/navbar/templates/navbar.tpl.html',
            restrict: 'E',
            replace: true
        };

        NavbarController.$inject = ['$log'];

        function NavbarController($log) {

            var scope = this;

            /* IMPLEMENTATIONS */

        }

        return directive;
    }
})();