(function () {
    'use strict';

    angular
        .module('pulse.login.controllers')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', '$state', '$location', '$timeout', 'authentication', '$rootScope'];

    function LoginController($scope, $state, $location, $timeout, Authentication, $rootScope) {

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {
            console.log($scope.loginData.userName);
            console.log($scope.loginData.password);
            Authentication.login($scope.loginData).then(function (response) {
                    $state.go('health');
                    $rootScope.$broadcast('userLoggedInStatusChangedReloadNavBar');
                },
                function (err) {
                    $scope.message = err.error_description;
                });
        };

    }
})();
