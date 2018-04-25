app.controller('GeneralController', [
  '$scope',
  '$http',
  function($scope, $http, $sce) {

    $scope.getRoles = function() {
      $http.get('/api/rol/get_rol').success(function(data, status, headers, config) {
        $scope.listRoles = data;
      }).error(function(data, status, headers, config) {
        console.log("Error> " + data);
      });
    };

 
  }
]);
