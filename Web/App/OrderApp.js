var OrdersReportingApp = angular.module('OrderApp', [])
OrdersReportingApp.controller('OrderController', function ($scope, $http, OrderService) {
    OrderService.GetOrders().then(function(data) {
        $scope.orders = data;
    },
    function(exception) {
        console.error("Exception from the Order App : "+ exception);
    });

});

OrdersReportingApp.service("OrderService", ["$http", "$q", function ($http,$q) {
    this.GetOrders = function () {
        var defer = $q.defer();
            $http.get('/api/order/1').then(function (response) {
                defer.resolve(response.data);
            }, function errorCallback(response) {
                defer.reject(Console.log("Error"));
            });
        
        return defer.promise;
    }
}]);
