(function () {
    'use strict';
    // factory
    angular
        .module('pulse.common.authentication.jwt.factory', [])
        .factory('authentication', Authentication);

    Authentication.$inject = ['$log', '$q', '$http', 'localStorageService', 'Account', 'toaster', 'jwtTokenDecoder'];

    function Authentication($log, $q, $http, localStorageService, Account, toaster, jwtTokenDecoder) {
        var isLoggedInState = null;
        var currentUser = null;
        var currentUserStorageKey = 'currentUser';
        var authorizationDataStorageKey = 'authorizationData';

        var service = {
            login: login,
            logout: logout,
            unauthorizedRequest: unauthorizedRequest,
            getCurrentUser: getCurrentUser,
            isLoggedIn: isLoggedIn,
            getUserNavMenu: getUserNavMenu,
            getClaims: getClaims
        };

        init();

        return service;

        /* Implementations */

        function init() {
            if (localStorageService.isSupported) {
                var localStorageCurrentUser = localStorageService.get(currentUserStorageKey);
                var localStorageAuthorizationData = localStorageService.get(authorizationDataStorageKey); //***************** TODO decode this JWT Token JWT.io
                /*
				Having a user in local storage DOES NOT imply that the user 's token is still valid.
				*/
                if (localStorageCurrentUser && localStorageAuthorizationData) {
                    if (jwtTokenDecoder.isTokenExpired(localStorageAuthorizationData.token)) {
                        toaster.warning('Your session has expired', 'Session expired');
                        toaster.warning('Please log in again', 'Login required');
                        logout();
                    } else {
                        currentUser = localStorageCurrentUser;
                        isLoggedInState = true;
                    }
                } else {
                    logout();
                }
            }
        }

        function login(loginCredentials) {
            var data = 'grant_type=password&username=' + loginCredentials.userName + '&password=' + escape(loginCredentials.password);

            var deferred = $q.defer();

            $http.post('/api/oauth/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

                var isKeySet = localStorageService.set(authorizationDataStorageKey, { token: response.access_token, userName: loginCredentials.userName, refreshToken: '', useRefreshTokens: false });
                if (!isKeySet) {
                    toaster.warning('Browser local storage not available.', 'Warning');
                }
                isLoggedInState = true;

                currentUser = Account.getCurrentUser();

                currentUser.$promise.then(function () {
                    localStorageService.set(currentUserStorageKey, currentUser);
                    deferred.resolve(response);
                }, function (err) {
                    deferred.reject(err);
                });

            }).error(function (err) {
                toaster.error('Incorrect login details provided', 'Error');
                logout();
                deferred.reject(err);
            });

            return deferred.promise;
        }

        function logout() {
            var deferred = $q.defer();

            localStorageService.remove(currentUserStorageKey);
            localStorageService.remove(authorizationDataStorageKey);

            resetState();
            deferred.resolve();
            
            return deferred.promise;
        }

        function unauthorizedRequest() {
            var isAuthorizationDataKeyRemoved = localStorageService.remove(authorizationDataStorageKey);
            var isCurrentUserKeyRemoved = localStorageService.remove(currentUserStorageKey);

            if (isCurrentUserKeyRemoved && isAuthorizationDataKeyRemoved) {
                resetState();
            }

            $log.warn('User not logged in');
        }

        function resetState() {
            isLoggedInState = false;
            currentUser = null;
        }

        function getCurrentUser() {
            return currentUser;
        }

        function isLoggedIn() {
            return isLoggedInState;
        }

        function getUserNavMenu() {
            throw 'Method not supported, use getClaims() instead';
        }

        function getClaims() {
            var tokenObject = localStorageService.get(authorizationDataStorageKey);
            if (tokenObject) {
                var decodedToken = jwtTokenDecoder.decodeToken(tokenObject.token);
                return decodedToken.role;
            }
            return null;
        }
    }
})();
