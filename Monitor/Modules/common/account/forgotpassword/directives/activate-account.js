(function () {
	'use strict';

	angular
		.module('pulse.common.account.forgotpassword.activate-account', [])
		.directive('dtActivateAccount', activateAccount);

	activateAccount.$inject = ['$state', '$templateCache', '$compile'];

	function activateAccount($state, $templateCache, $compile) {

		var directive = {
			controller: ActivateAccount,
			controllerAs: 'activateAccount',
			link: link,
			templateUrl: 'modules/common/account/forgotpassword/templates/activate-account.tpl.html',
			scope: {
				state: '='
			},
			restrict: 'EA'
		};


		ActivateAccount.$inject = ['$log', '$scope', '$state', '$stateParams', 'Account', 'toaster'];

		function link(scope, element, attr) {
			if (attr.state === 'resetpassword') {
				var template = $templateCache.get('modules/common/account/forgotpassword/templates/resetpassword.tpl.html');
				element.html(template);
				$compile(element.contents())(scope);
			}
		}

		function ActivateAccount($log, $scope, $state, $stateParams, Account, toaster) {
			var scope = this;
			scope.hasAcceptedTnC = false;
			scope.resetPassword = resetPassword;
			scope.resetPasswordCredentials = {
				guid: $stateParams.guid,
				password: null,
				confirmPassword: null
			};


			validateResetPassword();


			/* Implementations */
			function validateResetPassword() {
				var validateResetPasswordPromise = Account.validateGuid({guid:  $stateParams.guid});
				validateResetPasswordPromise.$promise.then(function () {

					},
					function (result) {
						toaster.error(result.data.message, 'Error');
					});
			}

			function resetPassword() {
				var resetPasswordPromise = Account.activateMyAccount(scope.resetPasswordCredentials);
				resetPasswordPromise.$promise.then(function () {
						toaster.success('Password reset successfully', 'Success');
						$state.go('home');
					},
					function (result) {
						toaster.error(result.data.message, 'Error');
					});
			}
		}

		return directive;
	}
})();