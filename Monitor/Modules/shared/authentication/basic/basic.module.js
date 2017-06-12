(function () {
	'use strict';

	angular.module('pulse.authentication.basic', [
		'pulse.authentication.basic.factory',
		'pulse.authentication.basic.interceptor',
		'pulse.authentication.basic.heartbeat'
	]);

})();
