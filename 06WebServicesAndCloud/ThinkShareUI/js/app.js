var myApp = angular.module('myApp', ['ngResource' , 'ngRoute']);

myApp.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: "../partials/articles.html",
            controller: 'AllArticlesController'
        })
        .when('/byauthor/:authorName', {
            templateUrl: 'partials/articles.html',
            controller: 'ByAuthorController'
        })
        .when('/article/:articleId', {
            templateUrl: 'partials/article.html',
            controller: 'ArticleController'
        })
        .when('/category/:categoryId', {
            templateUrl: 'partials/articles.html',
            controller: 'CategoryController'
        })
        .when('/newpost' , {
            templateUrl: 'partials/post.html',
            controller: 'NewPostController'
        })
        .when('/edit/:articleId', {
            templateUrl: 'partials/post.html',
            controller: 'EditPostController'
        })
        .when('/byword/:tagName', {
            templateUrl: 'partials/articles.html',
            controller: 'ByTagController'
        })
        .when('/error/:errorMessage', {
            templateUrl: 'partials/error.html',
            controller: 'ErrorController'
        })
        .otherwise({ redirectTo: '/'});
});
