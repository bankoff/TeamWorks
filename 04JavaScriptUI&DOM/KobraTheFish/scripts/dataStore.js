function saveSession() {
    if (typeof (Storage) !== "undefined") {
        saveToLocalStorage();
    } else {
        saveToCookies();
    }
}

function loadSession() {
    if (typeof (Storage) !== "undefined") {
        loadFromLocalStorage();
    } else {
        loadFromCookies();
    }
}

function saveToLocalStorage() {
    localStorage.setItem("userName", 'test');
    //and so on need to check whats what
}

function saveToCookies() {
    var cookiesString;
    cookiesString=
    cookiesString = "" + "username=test";
    //and so on need to see whats what
    document.cookie = cookiesString;
}

function loadFromLocalStorage() {
    //work in progress, might change function all together
}
function loadFromCookies() {
    //work in progress, might change function all together
}