(function () {
	'use strict';

	angular.module('pulse.authentication.jwt', [
		'pulse.authentication.jwt.factory',
		'pulse.authentication.jwt.interceptor',
		'pulse.authentication.jwt.decode'
	]);

})();
