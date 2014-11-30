/// <reference path="../kendo/js/kendo.mobile.min.js" />
/// <reference path="../kendo/js/kendo.mobile.min.intellisense.js" />
/// <reference path="../kendo/js/kendo.mobile-vsdoc.js" />

var app = (function (win) {
    'use strict';

    var showAlert = {};
    var showConfirm = {};
    var showError = {};

    // Initialize Everlive SDK
    var el = new Everlive({
        apiKey: appSettings.everlive.apiKey,
        scheme: appSettings.everlive.scheme
    });

    //object with the current user details
    var currentUser = kendo.observable({ data: null });

    var setSitesToLocalStorage = function () {
        var query = new Everlive.Query(),
            data = el.data('Locations'),
            locations = [];

        query.select('Name', 'Location');

        data.get(query)
            .then(function (data) {
                locations = JSON.stringify(data.result);
                win.localStorage.setItem("sites", locations);
            },
            //TODO set this to navigator.notification
            function (error) {
                console.log(JSON.stringify(error));
            });
    }

    var getSitesToLocalStorage = function () {
        var sites = win.localStorage.getItem("sites");
        return JSON.parse(sites);
    };

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
                AppHelper.logout().then(exit, exit);
            }
        }, 'Exit', ['OK', 'Cancel']);
    };

    var onDeviceReady = function () {
        win.addEventListener('error', function (e) {
            e.preventDefault();

            var message = e.message + " from " + e.filename + ":" + e.lineno;

            showAlert(message, 'Error occured');

            return true;
        });

        // Global error handling
        this.showAlert = function (message, title, callback) {
            navigator.notification.alert(message, callback || function () {
            }, title, 'OK');
        };

        // Global confirm dialog
        this.showConfirm = function (message, title, callback) {
            navigator.notification.confirm(message, callback || function () {
            }, title, ['OK', 'Cancel']);
        };

        this.showError = function (message) {
            showAlert(message, 'Error occured');
        };

        //set all available sites to local storage
        //setSitesToLocalStorage();

        // Handle "backbutton" event
        document.addEventListener('backbutton', onBackKeyDown, false);

        navigator.splashscreen.hide();
        fixViewResize();
    };

    // Handle "deviceready" event
    document.addEventListener('deviceready', onDeviceReady, false);
    // Handle "orientationchange" event
    document.addEventListener('orientationchange', fixViewResize);

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
        skin: 'flat',
        initial: 'views/login.html'
    });

    var getYear = (function () {
        return new Date().getFullYear();
    }());

    var isConnected = function() {
        var networkState = navigator.connection.type;

        var states = {};

        states[Connection.NONE] = 'Check your \nnetwork connection';

        if (states[networkState] === states[Connection.NONE]) {
            navigator.notification.alert(states[networkState]);
            navigator.notification.vibrate(1000);
            return false;
        }

        return true;
    };

    return {
        showAlert: showAlert,
        showError: showError,
        showConfirm: showConfirm,
        isKeySet: isKeySet,
        mobileApp: mobileApp,
        helper: AppHelper,
        everlive: el,
        getYear: getYear,
        currentUser: currentUser,
        isConnected: isConnected,
        getSitesToLocalStorage: getSitesToLocalStorage
    };
}(window));