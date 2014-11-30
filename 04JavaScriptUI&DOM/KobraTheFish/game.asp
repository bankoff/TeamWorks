﻿<!--#include file="mainIncludes.asp"-->
<title>Kobra The Fish</title>
<style>
 div{
    z-index:10;
    opacity:.9;
    position:absolute;
    display:inline-block;
}
</style>
</head>
<body>
    <div class="mainContainer">
        <ul id='menu'>
            <li id="startGame">Start Game</li>
            <li id="scoreSubmit">Submit score</li>
            <li id="logout">Logout</li>
            <li id="help">Instructions</li>
        </ul>
        <div id="instructionsContainer">
            <ul>
                <li>Move your fish with the mouse.</li>
                <li>Eat smaller fish, avoid bigger fish.</li>
                <li>The more fish you eat the higher your score.</li>
            </ul>
            <div id="closeHelp" title="close help">X</div>
        </div>
        <!--input type="button" onclick="Game()" value="Play" id="playBtn" style="width:80px"/-->    
        <canvas width="1024" height="768" id="canvas" style="position: absolute">Your Browser Does Not Support Canvas :(</canvas>
        <svg id="svg" width="1024" height="768" style="position: absolute">
            <rect x="0" y="0" width="1024" height="300" style="fill: #05358c; stroke: none;"></rect>
            <rect x="0" y="300" width="1024" height="368" style="fill: #051837; stroke: none;"></rect>
            <rect x="0" y="668" width="1024" height="100" style="fill: #041527; stroke: none;"></rect>

            <path style="fill: #0545b9; stroke: none;" d="M0 0L0 59L134 59L179 59L200.892 59.3171L208 64C208 81.1149 212.76 98.2912 215.741 115.09C216.573 119.779 216.562 130.782 220.603 133.972C225.879 138.138 243.353 135 250 135L256.985 158.004L274 208L306 208C299.955 182.393 280.252 161.182 274 136L248 134C247.771 126.094 243.444 120.266 241.094 112.999C235.624 96.0834 226.257 76.6323 224 59L205 59L204 49C185.553 49 168.923 47.7149 151.001 43.1258C146.574 41.9922 134.5 37.8327 137.157 31.169C142.919 16.7206 171.146 20.0797 183 16.9854C200.233 12.4869 215.281 12.7365 233 11.9606C253.927 11.0443 273.796 9.6665 294.09 15.1605C301.349 17.1258 324.718 20.3495 327.673 28.0393C329.691 33.2927 318.482 35.7581 318 42L301 48L308 58C285.111 60.8927 261.075 59 238 59C241.967 71.1721 248.194 83.3699 254.096 94.7106C258.147 102.495 263.899 110.989 264 120L267 120L272 135L400 135C398.958 128.781 392.348 124.896 387.576 121.296L358.424 96.8858C353.655 93.4126 350.069 88.888 344 88C342.72 84.1065 339.95 82.5918 336 82C334.581 73.0721 319.083 65.692 313 59L1024 59L1024 0L0 0z" />
            <path style="fill: #0751d7; stroke: none;" d="M221 48C222.313 58.0903 226.857 58 236 58L232 47C259.409 52.3155 292.177 53.038 318 42C318.976 35.8267 330.143 33.9428 328.199 28.0393C325.7 20.4503 302.046 17.0083 295.039 15.1605C274.121 9.6438 253.56 11.0166 232 11.9606C214.283 12.7365 199.237 12.4874 182 16.9854C169.749 20.1823 144.062 16.6552 137.042 30.2863C134.153 35.8967 141.843 40.4681 146.174 42.0363C158.747 46.589 171.777 48 185 48L221 48z" />
            <path style="fill: #0d61fb; stroke: none;" d="M218 20C222.974 22.0872 229.638 21 235 21C230.026 18.9128 223.362 20 218 20z" />
            <path style="fill: #206cfc; stroke: none;" d="M209 27L223 28.6998L232 29C234.49 28.9962 249.171 27.2431 241.677 22.3171C235.32 18.1383 210.795 18.7003 209 27z" />
            <path style="fill: #0856e7; stroke: none;" d="M173 26L173 32L189.812 33.7214C197.151 31.9874 200.123 27.0059 209 27L209 24L194 26C190.692 19.9135 177.783 24.7531 173 26z" />
            <path style="fill: #357dfd; stroke: none;" d="M199 27C204.469 29.295 212.099 28 218 28C212.531 25.705 204.901 27 199 27z" />
            <path style="fill: #4d89ff; stroke: none;" d="M194 29L194 32C203.737 34.3182 214.17 32.7758 224 32C221.428 24.6852 200.368 27.484 194 29z" />
            <path style="fill: #0d61fb; stroke: none;" d="M224 29L224 32L192 32C195.168 42.4672 219.522 38.0715 228 37C230.339 30.5811 236.087 30.5961 242 32L243 28L224 29z" />
            <path style="fill: #206cfc; stroke: none;" d="M257 38C255.656 29.7656 236.608 28.1202 230.438 32.3179C223.438 37.0791 234.708 39.9555 238 39.9962L246 39.9992L257 38z" />
            <path style="fill: #0549c7; stroke: none;" d="M232 47L236 58C226.992 58 222.884 57.5447 221 48L178 48C185.169 51.0081 196.239 49 204 49L205 59L224 59L231.275 81.2855L241.443 114.985C243.819 121.451 247.549 126.922 248 134C255.991 136.854 263.705 135.308 272 136L267 120L264 120C263.967 110.441 258.271 102.128 254.096 93.8295L238 59C260.572 59 285.798 62.1218 308 58C305.832 55.0153 303.41 49.9164 299.811 48.5641C293.41 46.1588 286.437 49.9578 280 49.9992C263.489 50.1055 248.265 49.1004 232 47z" />
            <path style="fill: #0741ad; stroke: none;" d="M0 59L0 136L8 136L8 140L208 140L208 136L218 135L218 144L221 144L221 152L224 152L228 184L231 184L232 208L274 208C268.887 183.111 253.643 160.035 250 135C242.917 135 227.289 137.954 221.318 133.972C217.1 131.159 216.456 119.719 215.872 115.09C213.722 98.0537 208 81.2585 208 64C191.443 54.278 164.678 59 145 59L0 59M313 59C318.493 67.4886 333.199 72.3099 336 82C339.699 82.9737 342.184 84.6059 344 88C359.511 92.0344 370.019 110.219 382.986 118.83C388.852 122.725 397.877 128.033 400 135L272 135C285.558 157.171 297.137 183.473 306 208L275 208L285 240L288 240L288 252C293.312 254.624 289.754 262.181 296 264C296.011 267.819 295.475 273.507 298.56 276.386C301.134 278.787 306.749 277.974 310.004 277.997L340 277L333 264L336 264C334.304 259.929 332.541 256.778 328 256C327.999 249.518 327.84 241.344 320 240L320 232C312.352 227.907 310.487 215.678 308 208L488 208L488 204L484 200C472.416 196.844 467.986 182.177 456 180L456 176L452 176C450.516 171.478 444.546 168.69 440 168C438.765 163.828 436.172 161.235 432 160C430.828 153.161 418.559 144.994 412 144C411.161 141.373 410.627 140.839 408 140L408 135L1024 135L1024 59L313 59z" />
            <path style="fill: #053da0; stroke: none;" d="M208 136L208 140L8 140L8 136L0 136L0 208L232 208L232 216L224 216L224 212L0 212L0 277L161 277C189.594 277 219.641 274.416 248 278L248 296L251 296L256 332L298 332C303.169 332 311.077 330.546 315.736 333.14C321.438 336.313 321.998 343.419 323.299 348.91C324.844 355.434 330.102 371.656 334.884 376.397C337.762 379.25 344.3 378 348 378L384 378C383.352 367.823 375.773 358.354 372.14 349C370.471 344.704 369.772 340.349 365 339L366 331C375.819 333.338 386.944 332 397 332L455 332L640 332L629.469 322.599C622.717 316.71 613.18 305.336 604 304L600 296C594.154 294.475 582.811 285.242 580 280L576 280L576 277L1024 277L1024 274L584 274L584 272L1024 272L1024 212L660 212L545 212C528.099 212 507.93 208.449 492 212L491 208L1024 208L1024 140L416 140C415.518 137.636 415.364 137.482 413 137C430.485 131.832 454.738 136 473 136L602 136L1024 136C1019.03 133.915 1012.35 135 1007 135L971 135L845 135L408 135L408 140L412 144C418.331 145.725 430.001 153.587 432 160C435.716 161.8 438.2 164.284 440 168C444.432 169.188 449.782 171.929 452 176L456 176L456 180C467.423 183.402 472.045 198.188 484 200C484.839 202.626 485.374 203.161 488 204L488 208L308 208C309.467 215.01 312.436 229.514 320 232L320 240C327.119 242.219 327.995 249.491 328 256C332.107 257.281 333.828 260.422 336 264L333 264L333 266L340 277C324.918 278.906 296.17 284.594 296 264C290.863 260.888 293.521 253.849 288 252L288 240L285 240L275 208L232 208L231 184L228 184L224 152L221 152L221 144L218 144L218 135L208 136z" />
            <path style="fill: #0741ad; stroke: none;" d="M413 136L416 140L1024 140L1024 136L413 136z" />
            <path style="fill: #063796; stroke: none;" d="M0 208L0 212L224 212L224 216L232 216L232 208L0 208M491 208L492 212C509.984 209.621 530.268 212 549 212L666 212L1024 212L1024 208L491 208M584 272L584 274L1024 274L1024 272L584 272z" />
            <path style="fill: #05358c; stroke: none;" d="M0 277L0 378L192 378L243 378C248.226 378 258.171 376.105 262.697 379.028C265.683 380.957 266.118 385.826 266.789 389C268.853 398.761 271.999 409.073 272 419L327 419C332.114 419 343.446 416.893 347.436 420.603C354.718 427.375 356.755 444.915 360 454L420 454C417.496 442.314 410.75 430.94 406 420C417.604 417.237 431.105 419 443 419L515 419L745 419C734.787 401.171 710.3 394.661 699 377C711.598 379.339 725.215 378 738 378L807 378L1024 378L1024 277L576 277L576 280L580 280C581.756 285.443 594.268 295.16 600 296L604 304C615.47 306.968 632.123 323.25 640 332L458 332C428.494 332 395.003 336.385 366 331L365 339C370.597 341.578 371.434 348.626 373.492 353.996C376.624 362.17 382.904 369.066 384 378L349 378C345.103 378 338.7 379.196 335.546 376.397C330.431 371.858 324.823 354.564 323.299 347.961C322.104 342.785 321.75 336.316 316.526 333.14C312.128 330.466 303.969 332 299 332L256 332L251 296L248 296L248 278C221.779 273.132 191.67 277 165 277L0 277z" />
            <path style="fill: #062c73; stroke: none;" d="M699 377C706.821 395.044 732.495 404.273 745 419L512 419L441 419C430.045 419 416.522 416.89 406 420L420 454L360 454L352.149 431.09L347.436 420.028C343.213 416.912 332.079 419 327 419L272 419C272 408.902 269.003 398.917 266.996 389C266.359 385.852 266 380.177 262.697 378.603C257.258 376.013 246.966 378 241 378L188 378L0 378L0 454L280 454C280.001 459.477 280.514 478.271 285.573 481.142C290.87 484.149 302.019 482 308 482L363.996 482.059C374.873 483.019 369.406 496.742 376.318 500.258C380.832 502.554 389.039 501 394 501C409.049 501 428.575 504.264 443 500L435 482L701 482L782 482C794.126 482 809.362 484.44 821 481C816.673 476.607 814.617 472.215 808 472C805.771 465.211 796.813 459.289 792 454L1022 454C1025.17 445.129 1024 435.34 1024 426L1024 378L811 378C774.291 378 735.402 381.601 699 377z" />
            <path style="fill: #052258; stroke: none;" d="M1022 451C1019.04 455.564 1011.9 454 1007 454L966 454L792 454L808 472C814.408 472.485 816.207 477.473 821 481C807.913 484.116 792.424 482 779 482L697 482L435 482L443 500C428.432 503.468 410.951 501 396 501C390.54 501 382.206 502.545 377.148 500.258C370.368 497.192 374.988 483.644 365.956 482.148C347.377 479.071 325.853 482 307 482C301.486 482 289.098 484.309 284.894 480.106C280.64 475.855 280.005 459.91 280 454L0 454L0 519L225 519L273 519C277.422 519 287 517.216 290.397 520.603C293.466 523.665 292.966 531.936 293 536C323.125 541.593 356.159 530.896 385.981 537.573C396.641 539.959 388.898 558.449 401.004 558.981L447 559L466.677 559.231C472.254 557.239 462.816 542.266 459 541C462.749 533.913 477.886 537 485 537L563 537L890 537C885.957 532.029 878.223 525.675 872 524L872 520L867 520C881.703 515.654 901.659 519 917 519L1024 519L1024 451L1022 451z" />
            <path style="fill: #051b45; stroke: none;" d="M0 519L0 538L202 538L264 538C272.246 538 284.083 535.755 291.941 538.028C300.192 540.414 292.489 556.121 301.148 558.682L323 559L370 559C376.633 559 389.187 556.608 394.79 560.589C399.705 564.081 400.341 570.685 402 576L478 576L470 560C480.522 556.89 494.045 559 505 559L575 559L805 559L888 559C894.144 559 911.638 562.126 915 557C908.129 553.308 904.455 544.627 896 544L893 538L1024 538L1024 519L867 519L872 520L872 524L890 536C879.758 539.028 866.662 537 856 537L787 537L562 537L484 537C477.427 537 461.247 533.665 459 541C462.129 542.69 471.534 556.12 466.628 558.701C462.41 560.921 452.782 559 448 559L402.001 558.981C388.968 558.414 397.162 540.07 387.032 537.398C378.935 535.262 368.338 537 360 537C337.9 537 314.923 538.771 293 536C292.989 532.128 293.734 522.665 290.397 520.028C286.845 517.222 277.325 519 273 519L225 519L0 519z" />
            <path style="fill: #051837; stroke: none;" d="M0 538L0 576L402 576C397.926 556.156 386.438 559 369 559L324 559L302.059 558.682C292.753 556.132 300.143 540.539 292.852 537.832C286.624 535.52 274.801 538 268 538L207 538L0 538M893 538L896 544C904.303 545.239 907.57 554.577 915 557C909.594 562.191 892.495 559 885 559L802 559L470 559C472.8 563.995 472.724 572.338 478.444 575.142C487.5 579.581 505.946 576 516 576L608 576L1024 576L1024 538L893 538z" />

            <image x="0" y="0" width="100" height="60" xlink:href="scripts/images/A.png">
                <animateTransform attributeName="transform"
                    begin="0s"
                    dur="40s"
                    type="translate"
                    from="0 50"
                    to="100 500"
                    repeatCount="indefinite" />
            </image>
            <image x="0" y="0" width="60" height="100" xlink:href="scripts/images/B.png">
                <animateTransform attributeName="transform"
                    begin="0s"
                    dur="57s"
                    type="translate"
                    from="900 0"
                    to="40 600 "
                    repeatCount="indefinite" />
            </image>
            <image x="0" y="0" width="70" height="60" xlink:href="scripts/images/C.png">
                <animateTransform attributeName="transform"
                    begin="0s"
                    dur="46s"
                    type="translate"
                    from="500 30"
                    to="150 750"
                    repeatCount="indefinite" />
            </image>
            <image x="0" y="0" width="60" height="90" xlink:href="scripts/images/D.png">
                <animateTransform attributeName="transform"
                    begin="0s"
                    dur="63s"
                    type="translate"
                    from="-10 300"
                    to="900 100"
                    repeatCount="indefinite" />
            </image>
            <image x="0" y="0" width="90" height="60" xlink:href="scripts/images/E.png">
                <animateTransform attributeName="transform"
                    begin="0s"
                    dur="95s"
                    type="translate"
                    from="1000 400"
                    to="50 200"
                    repeatCount="indefinite" />
            </image>
            <image x="0" y="0" width="60" height="60" xlink:href="scripts/images/F.png">
                <animateTransform attributeName="transform"
                    begin="0s"
                    dur="47s"
                    type="translate"
                    from="750 600"
                    to="300 0"
                    repeatCount="indefinite" />
            </image>
        </svg>
        <input type="hidden" id="uName" value="<%=request("user") %>" />
        <input type="hidden" id="score" />
    </div>
</body>
<script type="text/javascript">
    var canvasLeft = parseInt($("body").css("width"));
    canvasLeft = (canvasLeft - 1024) / 2
    var mainWidth=1024+2*canvasLeft;
    mainWidth=mainWidth+"px";
    canvasLeft = canvasLeft + "px";
    $("#canvas").css("left", canvasLeft);
    $("#svg").css("left", canvasLeft);
    $("#menu").css("top", "30px");
    canvasLeft = parseInt(canvasLeft);
    canvasLeft = canvasLeft + parseInt($("#menu").css("left"));
    canvasLeft = canvasLeft + "px";
    $("#menu").css("left", canvasLeft);
    $("#instructionsContainer").css("left", canvasLeft);
    $(".mainContainer").css("height", "768px");
    $(".mainContainer").css("width", mainWidth);


    $("#scoreSubmit").click(function(){
        saveScore();
    });
    
    $("#startGame").click(function(){
        $("#menu").fadeOut("slow", Game());
    });
    
    $("#logout").click(function(){
        if (confirm("Would you like to save your score?") == true) {
            saveScore();
            localStorage.removeItem("userName");
            window.location.href="logIN.asp";
        } 
        else {
            localStorage.removeItem("userName");
            window.location.href="logIN.asp";
        }
    });
    
    $("#help").click(function(){
        $("#instructionsContainer").fadeIn("slow");
        $("#menu").fadeOut("slow");
    });
    
    $("#instructionsContainer").click(function(){
        $("#instructionsContainer").fadeOut("slow");
        $("#menu").fadeIn("slow");
    });
</script>
</html>