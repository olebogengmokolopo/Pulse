(function () {
	'use strict';

	angular.module('pulse.common.authentication.basic', [
		'pulse.common.authentication.basic.factory',
		'pulse.common.authentication.basic.interceptor',
		'pulse.common.authentication.basic.heartbeat'
	]);

})();
