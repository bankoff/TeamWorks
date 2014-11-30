myApp.controller('ErrorController' , function($scope ,articleData, $routeParams){
        var message = $routeParams.errorMessage;
        $scope.errorMsg = message;
})