(function () {
    'use strict';
    angular.module('pulse', [
        // all vendor/bower module defined above
        'pulse.vendors',
        // all app modules defined below
        'pulse.navbar',
        'pulse.authentication',
        'pulse.toaster',
        'pulse.home',
        'pulse.health',
        'pulse.sampling',
        'pulse.sensors',
        'pulse.register',
        'pulse.login'
    ]);
})();
