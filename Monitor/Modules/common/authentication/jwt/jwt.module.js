(function () {
	'use strict';

	angular.module('pulse.common.authentication.jwt', [
		'pulse.common.authentication.jwt.factory',
		'pulse.common.jwt-authentication.interceptor',
		'pulse.common.jwt-authentication.decode',
	]);

})();
