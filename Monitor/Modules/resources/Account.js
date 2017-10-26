(function() {
    'use strict';
    angular.module('pulse')
        .factory('Account', function($resource, resourceConfig) {

                var serverUrl = resourceConfig.serverName;
                return $resource(serverUrl, null, {
                    
                        // Account.register

                        // The `register` method performs a `POST` on `/api/accounts/Register`
                        
                        // Payload: `object userModel`
                        register: { 
                            url: '/api/accounts/Register', 
                            method: 'POST',
                        },
                    
                        // Account.getCurrentUser

                        // The `getCurrentUser` method performs a `GET` on `/api/accounts/user`
                        
                        getCurrentUser: { 
                            url: '/api/accounts/user', 
                            method: 'GET',
                        },
                });
            }
        );
}());

