(function () {
    'use strict';

    angular
        .module('pulse.login.controllers')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', '$location', '$timeout', 'authentication'];

    function LoginController($scope, $location, $timeout, Authentication) {

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {

            Authentication.login($scope.loginData).then(function (response) {
                    $location.path('/orders');
                },
                function (err) {
                    $scope.message = err.error_description;
                });
        };

    }
})();
