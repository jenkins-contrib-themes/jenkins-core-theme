(function() {
    'use strict';

    angular
        .module('app')
        .config(Config);

    Config.$inject = ['$routeProvider'];

    function Config($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'app/components/home/index.html'
            })
            .otherwise({
                redirectTo: '/'
            });
    }
})();