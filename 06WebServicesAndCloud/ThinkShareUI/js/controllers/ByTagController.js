myApp.controller('ByTagController' , function($scope ,articleData, $routeParams){
    articleData.getArticleAuthorTag($routeParams.tagName).then(function(data){
        $scope.articles = data;
    })
})