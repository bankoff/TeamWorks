myApp.factory('articleData', function($http , $q , helper){
    return{
        getAllArticles: function(){
            var defer = $q.defer();
            $http.get(helper.baseUrl()+'api/Articles/GetArticles').
                success(function(data, status, headers, config) {
                    defer.resolve(data);
                }).
                error(function(data, status, headers, config) {
                    defer.reject(data);
                });

            return defer.promise;
        },
        getArticleById: function (articleId) {
            var defer = $q.defer();
            $http.get(helper.baseUrl()+'api/Articles/GetArticle/'+articleId).
                success(function(data, status, headers, config) {
                    defer.resolve(data);
                }).
                error(function(data, status, headers, config) {
                    defer.reject(data);
                });

            return defer.promise;
        },
        getArticleCategoryId: function (categoryId) {
            var defer = $q.defer();
            $http.get(helper.baseUrl()+'api/Articles/GetArticlesByCategoryId/'+categoryId).
                success(function(data, status, headers, config) {
                    defer.resolve(data);
                }).
                error(function(data, status, headers, config , statusText ) {
                    defer.reject(status);
                });

            return defer.promise;
        },
        getArticleAuthorName: function (authorName) {
            var defer = $q.defer();
            $http.get(helper.baseUrl()+'api/Articles/GetArticlesByAuthorName?name='+authorName).
                success(function(data, status, headers, config) {
                    defer.resolve(data);
                }).
                error(function(data, status, headers, config) {
                    defer.reject(data);
                });

            return defer.promise;
        },
        getArticleAuthorTag: function (tag) {
            var defer = $q.defer();
            $http.get(helper.baseUrl()+'api/Articles/GetArticlesByTag?tagName='+tag).
                success(function(data, status, headers, config) {
                    defer.resolve(data);
                }).
                error(function(data, status, headers, config) {
                    defer.reject(data);
                });

            return defer.promise;
        }
    }
})