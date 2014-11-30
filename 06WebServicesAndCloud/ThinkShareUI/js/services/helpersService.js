myApp.factory('helper' , function($location){
    return {
        baseUrl: function(){
            return "http://thinkshare.apphb.com/";
            //return "http://localhost:6466/";
        },
        convertDate:function(date){
            var year = date.getYear();
            var month = date.getMonth()+1;
            var day = date.getDay();
            var hours = day.getHours();
            var minutes = day.getMinutes();
            var result = hours+':'+minutes+' '+day+'/'+month+'/'+year;
            return result;
        },
        showError:function(message){
            $location.path('/error/'+message);
        }
    }
})