myApp.controller('ArticleController' , function($scope , articleData , $routeParams , comments , $route , helper){
    articleData.getArticleById($routeParams.articleId).then(function(data){
        $scope.articleId = data.ArticleId;
        $scope.articleHead = data.ArticleHead;
        $scope.articleAuthor = data.ArticleAuthor;
        $scope.articleText = data.ArticleText;
        $scope.date = data.Date;
        $scope.category = data.Category;
        $scope.comments = data.Comments;
    },function(){
        helper.showError("Id not Found");
    })
    $scope.show = false;
    $scope.showCommentFrom = function(){
        $scope.show = true;
    }
    $scope.AddComment = function(articleId , comment){
        comments.addComment(articleId , comment).then(function(data){
            $route.reload();
        },function(err){
            helper.showError(err.Message);
        });
    };
})