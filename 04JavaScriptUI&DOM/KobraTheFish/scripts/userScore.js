function registerUser() {
    var uName = document.getElementById('userName').value;
    if (uName.length<3 ) {
        alert("at least 3 symbols for user name")
    }
    else {
        var xmlhttp;
        if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp = new XMLHttpRequest();
        }
        else {// code for IE6, IE5
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }

        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                if (xmlhttp.responseText == "sucsess") {
                    alert("sucsessfull registration (work in progress, aslo could use a fancy message box)");
                    window.location.href = "game.asp?user=" + uName;
                }
                else if (xmlhttp.responseText == "error2") {
                    alert("username taken");
                }
                else if (xmlhttp.responseText == "error1") {
                    alert("an error occured on the server please try again later.");
                }
            }
        }
        xmlhttp.open("GET", "register.asp?uName=" + document.getElementById('userName').value, true);
        xmlhttp.send();
    }
}

function updateCurrentScoreToStore(currentScore) {
    if (typeof (Storage) !== "undefined") {
        localStorage.setItem("score", currentScore);
    }
    else {
        setCookie("userName", currentScore, 365);
    }
}

function logUserIn(userName) {
    var logged=false
    for (i = 0; i < users.length; i++) {
        if (users[i].uName == userName) {
                if (typeof (Storage) !== "undefined") {
                    localStorage.setItem("userName", userName);
                }
                else {
                    setCookie("userName", userName, 365);
                }
                logged = true;
            }       
    }
    if (logged == false) {
        alert("no such user please register");
    }
    else {
        window.location.href = "game.asp?user=" + userName;
    }
}

function saveScore(){
    var user= document.getElementById("uName").value;
    var score = parseInt(document.getElementById("score").value);
    var isHighScore=false;
    for (i = 0; i < users.length; i++) {
        if (users[i].uName == user) {
            
            if (users[i].score<=score){
                isHighScore=true;
                var xmlhttp;
                 if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }

                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        if (xmlhttp.responseText == "sucsess") {
                            alert("your highscore has been saved");
                            window.location.href = "game.asp?user=" + uName;
                        }
                        else  {
                            alert("an error occured on the server please try again later.");
                        }
                    }
                }
                xmlhttp.open("GET", "saveScore.asp?uName=" + user + "&score="+score, true);
                xmlhttp.send();
            }
            i=users.length;
        }
    }
    if (isHighScore==false){
        alert("your current score is higher");
    }
}

function gameOver() {
    if (confirm("Would you like to save your score?") == true) {
        saveScore();
        localStorage.removeItem("score");
        window.location.href = "logIN.asp";
    }
    else {
        localStorage.removeItem("score");
        window.location.href = "logIN.asp";
    }
}