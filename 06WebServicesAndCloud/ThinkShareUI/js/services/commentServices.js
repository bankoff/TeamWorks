myApp.factory('comments' , function($http , $q , helper){
    return {
        addComment: function(articleId , comment){
            comment.articleId = articleId;
            var defer = $q.defer();
            $http({
                url: helper.baseUrl()+'api/Comments/PostComment',
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                data: comment
            }).success(function(data, status, headers, config) {
                defer.resolve(data);
            }).
                error(function(data, status, headers, config) {
                    defer.reject(data);
                });

            return defer.promise;
        }
    }
})