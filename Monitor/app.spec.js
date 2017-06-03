(function () {
    'use strict';
    describe('AppCtrl', function () {
        describe('is the root controller', function () {
            var AppCtrl, $location, $scope;

            var moduleInvokationWhiteList = ['factory'];

            beforeEach(module('pulse'));

            beforeEach(inject(function ($controller, _$location_, $rootScope) {
                $location = _$location_;
                $scope = $rootScope.$new();
                AppCtrl = $controller('AppCtrl', { $location: $location, $scope: $scope });
            }));

            it('should have a working root application controller', inject(function () {
                expect(AppCtrl).toBeTruthy();
            }));

        });
    });

})();