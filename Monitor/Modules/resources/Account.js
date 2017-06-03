(function() {
    'use strict';
    angular.module('pulse')
        .factory('Account', function($resource, resourceConfig) {

                var serverUrl = resourceConfig.serverName;
                return $resource(serverUrl, null, {
                    
                        // Account.getUsers

                        // The `getUsers` method performs a `GET` on `/api/accounts/users`
                        
                        getUsers: { 
                            url: '/api/accounts/users', 
                            method: 'GET',
                        },
                    
                        // Account.getCurrentUser

                        // The `getCurrentUser` method performs a `GET` on `/api/accounts/user`
                        
                        getCurrentUser: { 
                            url: '/api/accounts/user', 
                            method: 'GET',
                        },
                    
                        // Account.getUserByName

                        // The `getUserByName` method performs a `GET` on `/api/accounts/user/:username`
                        
                        // Path parameter: `string username`
                        
                        getUserByName: { 
                            url: '/api/accounts/user/:username', 
                            method: 'GET',
                            params: {
                                username: '@username',
                            }
                        },
                    
                        // Account.confirmEmail

                        // The `confirmEmail` method performs a `GET` on `/api/accounts/ConfirmEmail`
                        
                        confirmEmail: { 
                            url: '/api/accounts/ConfirmEmail', 
                            method: 'GET',
                        },
                    
                        // Account.changePassword

                        // The `changePassword` method performs a `POST` on `/api/accounts/ChangePassword`
                        
                        // Payload: `object dto`
                        changePassword: { 
                            url: '/api/accounts/ChangePassword', 
                            method: 'POST',
                        },
                    
                        // Account.assignRolesToUser

                        // The `assignRolesToUser` method performs a `PUT` on `/api/accounts/user/:id/roles`
                        
                        // Path parameter: `integer id`
                        
                        // Payload: `object rolesToAssign`
                        assignRolesToUser: { 
                            url: '/api/accounts/user/:id/roles', 
                            method: 'PUT',
                            params: {
                                id: '@id',
                            }
                        },
                    
                        // Account.assignClaimsToUser

                        // The `assignClaimsToUser` method performs a `PUT` on `/api/accounts/user/:id/assignclaims`
                        
                        // Path parameter: `integer id`
                        
                        // Payload: `object claimsToAssign`
                        assignClaimsToUser: { 
                            url: '/api/accounts/user/:id/assignclaims', 
                            method: 'PUT',
                            params: {
                                id: '@id',
                            }
                        },
                    
                        // Account.removeClaimsFromUser

                        // The `removeClaimsFromUser` method performs a `PUT` on `/api/accounts/user/:id/removeclaims`
                        
                        // Path parameter: `integer id`
                        
                        // Payload: `object claimsToRemove`
                        removeClaimsFromUser: { 
                            url: '/api/accounts/user/:id/removeclaims', 
                            method: 'PUT',
                            params: {
                                id: '@id',
                            }
                        },
                });
            }
        );
}());

