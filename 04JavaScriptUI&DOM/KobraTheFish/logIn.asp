
<!--#include file="mainIncludes.asp"-->
<title>Hello</title>
</head>
<body>
    <form id="myForm">
        <div id="user-ask"> User name: </div>
        <input id="userName" type="text" /><br>
        <div id="logIn" onclick="logUserIn(document.getElementById('userName').value);"> Log in </div>
        <div id="register" onclick="registerUser();"> Register </div>
    </form>
</body>
<script type="text/javascript">
    if (typeof (Storage) !== "undefined") {
        if (localStorage.userName != "" && typeof(localStorage.userName) !== "undefined") {
            logUserIn(localStorage.userName);
        }
    } else {
        if (getCookie("userName") != "" && typeof(getCookie("userName")) !== "undefined") {
            logUserIn(getCookie("userName"));
        }
    }
</script>
</html>