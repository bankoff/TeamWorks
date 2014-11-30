myApp.controller('NewPostController' , function($scope , posts , helper , categories,hash , $routeParams , $location){
    categories.getCategories().then(function(data){
        $scope.categories = data;
        $scope.post = { Category : $scope.categories[0].Id};
    })
    //posts.createNewPost(post).then(function(data){
    //})
    $scope.submit = function(post){
        posts.createNewPost(post).then(function(data){
            $location.path('#/');
        },function(err){
            console.log(err);
            if(err){
                helper.showError(err.Message);
            }
            else{
                $location.path('#/');
            }
        });
    }
    $scope.pageInfo = "Create New Post";
    $scope.isNewPost = true;

});