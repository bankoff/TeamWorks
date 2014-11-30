/**
 * Application Settings
 */

var appSettings = {

    everlive: {
        apiKey: 'zVRqr8DCPpmcJj2f', // Put your Backend Services API key here
        scheme: 'http'
    },

    eqatec: {
        productKey: '$EQATEC_PRODUCT_KEY$',  // Put your EQATEC product key here
        version: '1.0.0.0' // Put your application version here
    },

    feedback: {
        apiKey: '$APPFEEDBACK_API_KEY$'  // Put your AppFeedback API key here
    },

    facebook: {
        appId: '', // Put your Facebook App ID here
        redirectUri: 'https://www.facebook.com/connect/login_success.html' // Put your Facebook Redirect URI here
    },

    google: {
        clientId: '', // Put your Google Client ID here
        redirectUri: 'http://localhost' // Put your Google Redirect URI here
    },

    liveId: {
        clientId: '', // Put your LiveID Client ID here
        redirectUri: 'https://login.live.com/oauth20_desktop.srf' // Put your LiveID Redirect URI here
    },

    adfs: {
        adfsRealm: '$ADFS_REALM$', // Put your ADFS Realm here
        adfsEndpoint: '$ADFS_ENDPOINT$' // Put your ADFS Endpoint here
    },

    messages: {
        mistSimulatorAlert: 'The social login doesn\'t work in the In-Browser Client, you need to deploy the app to a device, or run it in the simulator of the Windows Client or Visual Studio.',
        removeActivityConfirm: 'Are you sure you want to delete this Activity?'
    }
};
