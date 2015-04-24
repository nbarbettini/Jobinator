'use strict';
app.factory('authInterceptorService', ['$q', '$injector', '$location', 'localStorageService', function ($q, $injector, $location, localStorageService) {

    var authInterceptorServiceFactory = {};
    var $http;

    var _request = function (config) {

        config.headers = config.headers || {};

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    var _responseError = function (rejection) {
        var deferred = $q.defer();

        if (rejection.status === 401 &&
            !rejection.headers['IsRetry']) {
            var authService = $injector.get('authService');
            debugger;
            authService.refreshToken().then(function (response) {
                _retryHttpRequest(rejection.config, deferred);
            }, function () {
                authService.logOut();
                $location.path('/login');
                deferred.reject(rejection);
            })
        } else {
            deferred.reject(rejection);
        }
        return deferred.promise;
    }

    var _retryHttpRequest = function (config, deferred) {
        $http = $http || $injector.get('$http');
        config.headers['IsRetry'] = "1";
        $http(config).then(function (response) {
            deferred.resolve(resposne);
        }, function (response) {
            deferred.reject(response);
        });
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);