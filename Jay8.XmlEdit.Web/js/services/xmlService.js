'use strict'

crtConfig.factory('xmlService', function ($http, $log) {
    return {
        upload: function (onSuccess) {
            $http({ method: 'POST', url: '', data: '' })
                .success(function (data, status, headers, config) {
                    onSuccess(data);
                })
                .error(function (data, status, headers, config) {
                    $log.warn(data, status, headers, config);
            });
        }
    };
});