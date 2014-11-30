myApp.controller('EditPostController' , function($scope , posts , articleData, helper, categories , $routeParams , hash ,$location){
    var postId = $routeParams.articleId;
    categories.getCategories().then(function(data){
        $scope.categories = data;
    })
    //posts.createNewPost(post).then(function(data){
    //})
    articleData.getArticleById(postId).then(function(data){
        $scope.post = data;
    },function(){
        helper.showError("Id not Found");
    });
    $scope.submit = function(post){
        posts.editPost($routeParams.articleId , post).then(function(data){
            $location.path('#/');
        },function(err){
            helper.showError(err.Message);
        })
    }
    $scope.delete = function(post){
        var password = post.password;
        posts.deletePost($routeParams.articleId , password).then(function(data){
            $location.path('#/');
        },function(err){
            helper.showError(err.Message);
        })
    }
    $scope.pageInfo = "Edit Post";
    $scope.isNewPost = false;
});