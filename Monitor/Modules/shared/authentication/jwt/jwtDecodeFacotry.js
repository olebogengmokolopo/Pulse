/* global escape */
(function () {
    'use strict';
    // factory
    angular
        .module('pulse.authentication.jwt.decode', [])
        .factory('jwtTokenDecoder', ['$window', '$base64', function ($window, $base64) {

            var jwtAuthDecoder = {};

            //Using from open source angular-jwt library (https://github.com/auth0/angular-jwt). Consider just including the library itself. Uses MIT License
            //angular-jwt -- Begin
            function decodeToken(token) {

                var parts = token.split('.');

                if (parts.length !== 3) {
                    throw new Error('JWT must have 3 parts');
                }

                //Middle part represents the payload
                var decoded = urlBase64Decode(parts[1]);
                if (!decoded) {
                    throw new Error('Cannot decode the token');
                }
                return angular.fromJson(decoded);
            }

            function urlBase64Decode(str) {
                var output = str.replace(/-/g, '+').replace(/_/g, '/');
                switch (output.length % 4) {
                    case 0: { break; }
                    case 2: { output += '=='; break; }
                    case 3: { output += '='; break; }
                    default: {
                        throw 'Illegal base64url string!';
                    }
                }
                return $window.decodeURIComponent(escape($base64.decode(output)));
            }

            function getTokenExpirationDate(token) {
                var decoded = decodeToken(token);

                if (typeof decoded.exp === 'undefined') {
                    return null;
                }

                var d = new Date(0); // The 0 here is the key, which sets the date to the epoch
                d.setUTCSeconds(decoded.exp);

                return d;
            }

            function isTokenExpired(token, offsetSeconds) {
                var d = getTokenExpirationDate(token);
                offsetSeconds = offsetSeconds || 0;
                if (d === null) {
                    return false;
                }

                // Token expired?
                return !(d.valueOf() > (new Date().valueOf() + (offsetSeconds * 1000)));
            }
            //angular-jwt -- End

            jwtAuthDecoder.decodeToken = decodeToken;
            jwtAuthDecoder.getTokenExpirationDate = getTokenExpirationDate;
            jwtAuthDecoder.isTokenExpired = isTokenExpired;

            return jwtAuthDecoder;
        }]);
})();
