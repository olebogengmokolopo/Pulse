(function () {
	'use strict';
			/*
			
			Choose either basic or JWT authentication.
			
			Note that the 'authentication service' will have different features exposed depending on which authentication you choose.
			
			*/
	angular.module('pulse.common.authentication', [

		//'pulse.shared.authentication.basic',
		'pulse.common.authentication.jwt'
	]);

})();
