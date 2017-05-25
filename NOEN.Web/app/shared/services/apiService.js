/// <reference path="Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService'];

    function apiService($http, notificationService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        }

        //Hàm put Update
        function put(url, data, success, failure) {
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không có quyền!');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        // Hàm post Create
        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không có quyền.');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        //Hàm get 
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không có quyền!');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        //Hàm Delete
        function del(url, data, success, failure) {
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không có quyền!');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }
    }
})(angular.module('noenshop.common'));