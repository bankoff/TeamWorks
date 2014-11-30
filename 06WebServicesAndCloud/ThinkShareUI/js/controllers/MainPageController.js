myApp.controller('MainPageController', function($scope , categories){
    categories.getCategories().then(function(data){
        $scope.categories = data;
    })
    $scope.authorName = "Team Lime";
    $scope.linkedInLink = "https://github.com/ThinkShare";
});