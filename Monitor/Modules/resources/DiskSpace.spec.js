(function() {
    'use strict';
    describe('DiskSpace', function () {
        var mockDiskSpaceResource;
        var $httpBackend;
        beforeEach(angular.mock.module('pulse'));

        beforeEach(function () {
            angular.mock.inject(function ($injector) {
                $httpBackend = $injector.get('$httpBackend');
                mockDiskSpaceResource = $injector.get('DiskSpace');
            });
        });
        
                        
        /**
         * @action GET
         * @name DiskSpace.getDiskSummaries
         * @path param integer tenantId 
         * @ param string authorization 
         */
        describe('getDiskSummaries', function () {
            var result;
            
            beforeEach(inject(function(DiskSpace) {
                spyOn(DiskSpace, 'getDiskSummaries').and.callThrough();
                
                $httpBackend.expectGET('/diskspace/1')
                    .respond(
                        [{
                            data: 'test'
                        }]
                    );

                result = mockDiskSpaceResource.getDiskSummaries(
                {
                    tenantId: 1,
                }
                );

                $httpBackend.flush();
            }));
            
            it('should be defined as a function', inject(function (DiskSpace) {
                expect(typeof DiskSpace.getDiskSummaries === 'function').toEqual(true);
            }));    
            
            it('should be called with the correct parameters', inject(function (DiskSpace) {
                expect(DiskSpace.getDiskSummaries).toHaveBeenCalledWith(
                {
                    tenantId: 1,
                }
                );
            }));
            
            it('should respond with a promise containing data', inject(function () {
                expect(typeof result.$promise === 'object').toEqual(true);
                expect(result[0].data).toEqual('test');
            }));
        });
                        
        /**
         * @action GET
         * @name DiskSpace.getDiskHistories
         * @path param integer tenantId 
         * @ param integer previousDays 
         * @ param string authorization 
         */
        describe('getDiskHistories', function () {
            var result;
            
            beforeEach(inject(function(DiskSpace) {
                spyOn(DiskSpace, 'getDiskHistories').and.callThrough();
                
                $httpBackend.expectGET('/diskspace/1/history')
                    .respond(
                        [{
                            data: 'test'
                        }]
                    );

                result = mockDiskSpaceResource.getDiskHistories(
                {
                    tenantId: 1,
                }
                );

                $httpBackend.flush();
            }));
            
            it('should be defined as a function', inject(function (DiskSpace) {
                expect(typeof DiskSpace.getDiskHistories === 'function').toEqual(true);
            }));    
            
            it('should be called with the correct parameters', inject(function (DiskSpace) {
                expect(DiskSpace.getDiskHistories).toHaveBeenCalledWith(
                {
                    tenantId: 1,
                }
                );
            }));
            
            it('should respond with a promise containing data', inject(function () {
                expect(typeof result.$promise === 'object').toEqual(true);
                expect(result[0].data).toEqual('test');
            }));
        });
                        
        /**
         * @action POST
         * @name DiskSpace.createNewDiskReading
         * @body param object diskSensorDto 
         * @ param string authorization 
         */
        describe('createNewDiskReading', function () {
            var result;
            
            beforeEach(inject(function(DiskSpace) {
                spyOn(DiskSpace, 'createNewDiskReading').and.callThrough();
                
                $httpBackend.expectPOST('/diskspace').respond();

                result = mockDiskSpaceResource.createNewDiskReading(

                    {}
                );

                $httpBackend.flush();
            }));
            
            it('should be defined as a function', inject(function (DiskSpace) {
                expect(typeof DiskSpace.createNewDiskReading === 'function').toEqual(true);
            }));    
            
            it('should be called with the correct parameters', inject(function (DiskSpace) {
                expect(DiskSpace.createNewDiskReading).toHaveBeenCalledWith(

                    {}
                );
            }));
            
            it('should respond with a promise', inject(function () {
                expect(typeof result.$promise === 'object').toEqual(true);
            }));
        });
    });
}());

