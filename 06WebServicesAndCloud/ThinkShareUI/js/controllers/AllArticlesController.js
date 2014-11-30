myApp.controller('AllArticlesController' , function($scope , articleData){
    articleData.getAllArticles().then(function(data){
        $scope.articles = data;
    })
})