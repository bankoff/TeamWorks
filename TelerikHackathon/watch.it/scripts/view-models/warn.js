/**
 * Warn view model
 */

var app = app || {};

app.Warn = (function () {
    'use strict';

    var warnViewModel = (function () {
        var show = function () {
            $('#user-greeting-warn').text('Welcome, ' + app.currentUser.data.DisplayName + '!');
        };
        
        var settings= function(){
            navigator.notification.alert("Username: " + app.currentUser.data.DisplayName + "\nPhone number: " + app.currentUser.PhoneNumber + "\nEmail: " + app.currentUser.data.Email);
        };

        var logout = function () {
            navigator.notification.confirm('Do you really want to exit?', function (confirmed) {
                
                if (confirmed === true || confirmed === 1) {
                    app.currentUser = kendo.observable({ data: null });
                    app.helper.logout();
                    app.mobileApp.navigate('views/login.html');
                };

                var exit = function () {
                    navigator.app.exitApp();
                };

            }, 'Exit', ['OK', 'Cancel']);
        };
        
        
        var currentLocation = function() {
            var options = {
                    enableHighAccuracy: true
                },
                currentPosition = {};


            var locator = navigator.geolocation.getCurrentPosition(onSuccess, onError, options);

            // onSuccess Geolocation
            function onSuccess(position) {
                currentPosition.latitude = position.coords.latitude;
                currentPosition.longitude = position.coords.longitude;
                
                console.log(currentPosition.longitude);
                console.log(currentPosition.latitude);

                return true;
            }

            // onError Callback receives a PositionError object
            function onError(error) {
                alert('code: ' + error.code + '\n' +
                    'message: ' + error.message + '\n');
                return false;
            }

            if (locator) {
                return currentPosition;
            } else {
                return false;
            }
        };
        
        var loc = currentLocation();
        
        var isLocationValidSite = function (photo) {
            var dist = 0.01;

            console.log(currentLocation());
            console.log(currentLocation().longitude);
            console.log(currentLocation().latitude);
            
            if (Math.abs(photo.Longitude-currentLocation().longitude)<dist && Math.abs(photo.Latitude - currentLocation().latitude)<dist) {
                return true;
            } else {
                return false;
            }
        };
        
        

        var issuesDataList = [];

        var issuesData = (function () {
            var images = app.everlive.Files;

            images.get()
                .then(function (data) {
                    for (var i = 0; i < data.result.length; i++) {
                        var photo = data.result[i];
                        if(photo.Latitude != null && photo.Longitude != null && photo.Category != null && photo.Transportation != null) {
                            if(isLocationValidSite(photo)){
                                issuesDataList.push(data.result[i]);
                            }
                        }
                        //console.log(photo);
                    }
                },
                function (error) {
                    console.log(JSON.stringify(error));
                });
        }());
        
        var selectionIssuesList = function (event) {
            var selectedValue = parseInt(event.target.value),
                template = kendo.template($("#issuesTemplate").html()),
                filteredData = [];
            
        

            switch(selectedValue) {
                case 1:
                    filteredData = issuesDataList.filter(function (element) {
                        return element;
                    });
                    break;
                case 2:
                    filteredData = issuesDataList.filter(function (element) {
                        return element.Owner === app.currentUser.data.Id;
                    });
                    break;
                default:
                    filteredData = issuesDataList.filter(function (element) {
                        return element;
                    });
                    break;

            }

            $("#issuesList").html(kendo.render(template, filteredData));        }

        return {
            show: show,
            logout: logout,
            selectionIssuesList: selectionIssuesList,
            issuesDataList: issuesDataList,
            settings: settings
        };


    }());

    return warnViewModel;
}());