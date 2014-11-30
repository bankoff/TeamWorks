myApp.controller('ByAuthorController' , function($scope ,articleData, $routeParams){
    articleData.getArticleAuthorName($routeParams.authorName).then(function(data){
        $scope.articles = data;
    })
})