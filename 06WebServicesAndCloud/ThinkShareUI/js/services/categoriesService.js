myApp.factory('categories' , function($http , $q , helper){
    return {
        getCategories: function(){
            var defer = $q.defer();
            $http.get(helper.baseUrl()+'api/Categories/GetCategories').
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