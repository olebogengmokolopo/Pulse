(function() {
	'use strict';
	angular.module('pulse')
	.provider('resourceConfig', function resourceConfigProvider() {
		this.config ={
			serverBase: 'http://pulse.local/',
			debug: false
		};

		this.$get = function (){
			return this.config;
		};
	});

}());