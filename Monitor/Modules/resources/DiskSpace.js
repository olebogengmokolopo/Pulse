(function() {
    'use strict';
    angular.module('pulse')
        .factory('DiskSpace', function($resource, resourceConfig) {

                var serverUrl = resourceConfig.serverName;
                return $resource(serverUrl, null, {
                    
                        // DiskSpace.getDiskSummaries

                        // The `getDiskSummaries` method performs a `GET` on `/diskspace/:tenantId`
                        
                        // Path parameter: `integer tenantId`
                        
                        getDiskSummaries: { 
                            url: '/diskspace/:tenantId', 
                            method: 'GET',
                            isArray: true,
                            params: {
                                tenantId: '@tenantId',
                            }
                        },
                    
                        // DiskSpace.getDiskHistories

                        // The `getDiskHistories` method performs a `GET` on `/diskspace/:tenantId/history`
                        
                        // Path parameter: `integer tenantId`
                        
                        getDiskHistories: { 
                            url: '/diskspace/:tenantId/history', 
                            method: 'GET',
                            isArray: true,
                            params: {
                                tenantId: '@tenantId',
                            }
                        },
                    
                        // DiskSpace.createNewDiskReading

                        // The `createNewDiskReading` method performs a `POST` on `/diskspace`
                        
                        // Payload: `object diskSensorDto`
                        createNewDiskReading: { 
                            url: '/diskspace', 
                            method: 'POST',
                        },
                });
            }
        );
}());

