/// <reference path="../kendo/js/kendo.mobile.min.js" />
/// <reference path="../kendo/js/kendo.mobile.min.intellisense.js" />
/// <reference path="../kendo/js/kendo.mobile-vsdoc.js" />

//(function () {

//    // store a reference to the application object that will be created
//    // later on so that we can use it if need be
//    var app;

//    // create an object to store the models for each view
//    window.APP = {
//      models: {
//        home: {
//          title: 'new.....'
//        },
//        settings: {
//          title: 'Settings'
//        },
//        contacts: {
//          title: 'Contacts',
//          ds: new kendo.data.DataSource({
//            data: [{ id: 1, name: 'Bob' }, { id: 2, name: 'Mary' }, { id: 3, name: 'John' }]
//          }),
//          alert: function(e) {
//            alert(e.data.name);
//          }
//        }
//      }
//    };

//    // this function is called by Cordova when the application is loaded by the device
//    //document.addEventListener('deviceready', function () {  
      
//    //  // hide the splash screen as soon as the app is ready. otherwise
//    //  // Cordova will wait 5 very long seconds to do it for you.
//    //  navigator.splashscreen.hide();

//    //  app = new kendo.mobile.Application(document.body, {
        
//    //    // you can change the default transition (slide, zoom or fade)
//    //    transition: 'slide',
        
//    //    // comment out the following line to get a UI which matches the look
//    //    // and feel of the operating system
//    //    skin: 'flat',

//    //    // the application needs to know which view to load first
//    //    initial: 'views/settings.html'
//    //  });

//    //}, false);


//}());

    var app = (function (win) {
        'use strict';

        var showAlert = {};
        var showConfirm = {};
        var showError = {};


        var isNullOrEmpty = function (value) {
            return typeof value === 'undefined' || value === null || value === '';
        };

        var isKeySet = function (key) {
            var regEx = /^\$[A-Z_]+\$$/;
            return !isNullOrEmpty(key) && !regEx.test(key);
        };

        var fixViewResize = function () {
            if (device.platform === 'iOS') {
                setTimeout(function () {
                    $(document.body).height(window.innerHeight);
                }, 10);
            }
        };

        // Handle device back button tap
        var onBackKeyDown = function (e) {
            e.preventDefault();

            navigator.notification.confirm('Do you really want to exit?', function (confirmed) {
                var exit = function () {
                    navigator.app.exitApp();
                };

                if (confirmed === true || confirmed === 1) {
                    // Stop EQATEC analytics monitor on app exit
                    if (analytics.isAnalytics()) {
                        analytics.Stop();
                    }
                    AppHelper.logout().then(exit, exit);
                }
            }, 'Exit', ['OK', 'Cancel']);
        };

        var onDeviceReady = function () {
            win.addEventListener('error', function (e) {
                e.preventDefault();

                var message = e.message + "' from " + e.filename + ":" + e.lineno;

                showAlert(message, 'Error occured');

                return true;
            });

            // Global error handling
            showAlert = function (message, title, callback) {
                navigator.notification.alert(message, callback || function () {
                }, title, 'OK');
            };

            // Global confirm dialog
            showConfirm = function (message, title, callback) {
                navigator.notification.confirm(message, callback || function () {
                }, title, ['OK', 'Cancel']);
            };

            showError = function (message) {
                showAlert(message, 'Error occured');
            };
            // Handle "backbutton" event
            document.addEventListener('backbutton', onBackKeyDown, false);

            navigator.splashscreen.hide();
            fixViewResize();

            //if (analytics.isAnalytics()) {
            //    analytics.Start();
            //}

        };

        // Handle "deviceready" event
        document.addEventListener('deviceready', onDeviceReady, false);
        // Handle "orientationchange" event
        document.addEventListener('orientationchange', fixViewResize);

        // Initialize Everlive SDK
        var el = new Everlive({
            apiKey: appSettings.everlive.apiKey,
            scheme: appSettings.everlive.scheme
        });

        var emptyGuid = '00000000-0000-0000-0000-000000000000';

        var AppHelper = {

            // Return user profile picture url
            resolveProfilePictureUrl: function (id) {
                if (id && id !== emptyGuid) {
                    return el.Files.getDownloadUrl(id);
                } else {
                    return 'styles/images/avatar.png';
                }
            },

            // Return current activity picture url
            resolvePictureUrl: function (id) {
                if (id && id !== emptyGuid) {
                    return el.Files.getDownloadUrl(id);
                } else {
                    return '';
                }
            },

            // Date formatter. Return date in d.m.yyyy format
            formatDate: function (dateString) {
                return kendo.toString(new Date(dateString), 'MMM d, yyyy');
            },

            // Current user logout
            logout: function () {
                return el.Users.logout();
            }
        };

        var os = kendo.support.mobileOS,
            statusBarStyle = os.ios && os.flatVersion >= 700 ? 'black-translucent' : 'black';

        // Initialize KendoUI mobile application
        var mobileApp = new kendo.mobile.Application(document.body, {
            transition: 'slide',
            //statusBarStyle: statusBarStyle,
            skin: 'flat',
            initial: 'views/signup.html'
        });

        var getYear = (function () {
            return new Date().getFullYear();
        }());

        return {
            showAlert: showAlert,
            showError: showError,
            showConfirm: showConfirm,
            isKeySet: isKeySet,
            mobileApp: mobileApp,
            helper: AppHelper,
            everlive: el,
            getYear: getYear
        };
    }(window));