(function() {
	'use strict';
	angular.module('pulse')
	.provider('resourceConfig', function resourceConfigProvider() {
		this.config ={
			serverBase: 'http://pulse.local/',
			debug: true
		};

		this.$get = function (){
			return this.config;
		};
	});

}());