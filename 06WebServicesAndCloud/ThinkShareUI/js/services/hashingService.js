myApp.factory('hash' , function($http , $q){
    return {
        generateHashPassword: function(password){
            var hash = CryptoJS.SHA1(password).toString();
            return hash;
        }
    }
})