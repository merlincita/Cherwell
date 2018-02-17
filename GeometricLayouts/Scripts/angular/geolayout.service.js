(function () {

    angular.module('app').service('GeoLayoutService', GeoLayoutService);

    GeoLayoutService.$inject = ['$http', '$q'];

    function GeoLayoutService($http, $q) {

        var service = {
            calculateTriangleCoordinates: calculateTriangleCoordinates,
            calculateRowColumn: calculateRowColumn
        };

        return service;


        function calculateTriangleCoordinates(data) {
            var deferred = $q.defer();
            $http({
                method: "POST",
                url: "/api/Geometry/CalculateTriangleCoordinates",
                data: data
            })
            .then(function (response) {
                deferred.resolve(response);
            })
            .catch(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        function calculateRowColumn(data) {
            var deferred = $q.defer();
            $http({
                method: "POST",
                url: "/api/Geometry/CalculateRowColumn",
                data: data
            })
            .then(function (response) {
                deferred.resolve(response);
            })
            .catch(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }
        
        
    }
})();
