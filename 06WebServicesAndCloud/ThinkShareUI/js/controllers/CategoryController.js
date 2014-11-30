myApp.controller('CategoryController' , function($scope , articleData , $routeParams){
    articleData.getArticleCategoryId($routeParams.categoryId).then(function(data){
        $scope.articles = data;
    })
})