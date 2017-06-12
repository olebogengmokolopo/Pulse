/**
 * Created by authg on 2017/06/12.
 */
(function () {
    'use strict';

    angular
        .module('pulse.sensors.diskSpace')
        .directive('diskSpace', diskSpace);

    function diskSpace() {

        var directive = {
            controller: DiskSpaceController,
            controllerAs: 'diskSpace',
            templateUrl: 'modules/common/sensors/diskSpace/diskSpace.tpl.html',
            restrict: 'E',
            replace: true
        };

        DiskSpaceController.$inject = ['$log'];

        function DiskSpaceController($log) {

            var scope = this;

            /* IMPLEMENTATIONS */

        }

        return directive;
    }
})();