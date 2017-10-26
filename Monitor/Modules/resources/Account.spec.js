(function() {
    'use strict';
    describe('Account', function () {
        var mockAccountResource;
        var $httpBackend;
        beforeEach(angular.mock.module('pulse'));

        beforeEach(function () {
            angular.mock.inject(function ($injector) {
                $httpBackend = $injector.get('$httpBackend');
                mockAccountResource = $injector.get('Account');
            });
        });
        
                        
        /**
         * @action POST
         * @name Account.register
         * @body param object userModel 
         */
        describe('register', function () {
            var result;
            
            beforeEach(inject(function(Account) {
                spyOn(Account, 'register').and.callThrough();
                
                $httpBackend.expectPOST('/api/accounts/Register').respond();

                result = mockAccountResource.register(

                    {}
                );

                $httpBackend.flush();
            }));
            
            it('should be defined as a function', inject(function (Account) {
                expect(typeof Account.register === 'function').toEqual(true);
            }));    
            
            it('should be called with the correct parameters', inject(function (Account) {
                expect(Account.register).toHaveBeenCalledWith(

                    {}
                );
            }));
            
            it('should respond with a promise', inject(function () {
                expect(typeof result.$promise === 'object').toEqual(true);
            }));
        });
                        
        /**
         * @action GET
         * @name Account.getCurrentUser
         * @ param string authorization 
         */
        describe('getCurrentUser', function () {
            var result;
            
            beforeEach(inject(function(Account) {
                spyOn(Account, 'getCurrentUser').and.callThrough();
                
                $httpBackend.expectGET('/api/accounts/user')
                    .respond(
                        {
                            data: 'test'
                        }
                    );

                result = mockAccountResource.getCurrentUser();

                $httpBackend.flush();
            }));
            
            it('should be defined as a function', inject(function (Account) {
                expect(typeof Account.getCurrentUser === 'function').toEqual(true);
            }));    
            
            it('should be called with the correct parameters', inject(function (Account) {
                expect(Account.getCurrentUser).toHaveBeenCalledWith();
            }));
            
            it('should respond with a promise containing data', inject(function () {
                expect(typeof result.$promise === 'object').toEqual(true);
                expect(result.data).toEqual('test');
            }));
        });
    });
}());

