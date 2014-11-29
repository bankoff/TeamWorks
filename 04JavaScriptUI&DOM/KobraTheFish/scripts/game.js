/// <reference path="inheritancejs.js" />
/// <reference path="Objects/gameObject.js" />
/// <reference path="hero.js" />
/// <reference path="oval.js" />
/// <reference path="triangle.js" />
/// <reference path="skeleton.js" />
/// <reference path="triangleToRight.js" />
/// <reference path="ovalToRight.js" />


function Game() {
    //appendDivstoDom(200);
    var self = this,
        animation,
        canvas = $("#canvas")[0],
        ctx = canvas.getContext('2d'),
        mainLoop,
        enemyFishSpeed = 1,
        enemyFishCounter = -1;

    //TODO:implement for random number of objects
    var enemiesArr = [];

    var generator = setInterval(function () {
       
        var enemy = generateEnemyObj();
        enemiesArr.push(enemy);
        
    }, 1000);

    
    mainLoop = function () {

        ctx.save();
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        drawEnemies(enemiesArr);
        checkForCollision();
        updateEnemiesPosition(enemiesArr);

        ctx.restore();
        animation = requestAnimationFrame(mainLoop);

    };
    generateHero();
    $(document).on('mousemove', moveHeroByMouse)
    mainLoop();

    function generateHero() {
        var hero = new MainFish();
        var heroDiv = document.createElement('div');
        heroDiv.id = 'heroDiv';
        document.body.appendChild(heroDiv);
        hero.init(window.innerWidth / 2, window.innerHeight / 2, 50, 50);
        hero.canvas = drawHero(50, 50, window.innerWidth / 2, window.innerHeight / 2, 'heroDiv');
        hero.div = heroDiv;
        hero.div.style.top = window.innerHeight / 2 + 'px';
        hero.div.style.left = window.innerWidth / 2 + 'px';
    }

    function moveHeroByMouse(e) {
        var fishLeft = e.clientX - ($('#heroDiv').width() / 2);
        var fishTop = e.clientY - ($('#heroDiv').height() / 2);
        $('#heroDiv').css({
            top: fishTop + 'px',
            left: fishLeft + 'px'
        });
    }
    var overlaps = (function () {
        function getPositions(elem) {
            var pos, width, height;
            pos = $(elem).position();
            width = $(elem).width() / 2;
            height = $(elem).height();
            return [[pos.left, pos.left + width], [pos.top, pos.top + height]];
        }

        function comparePositions(p1, p2) {
            var r1, r2;
            r1 = p1[0] < p2[0] ? p1 : p2;
            r2 = p1[0] < p2[0] ? p2 : p1;
            return r1[1] > r2[0] || r1[0] === r2[0];
        }

        return function (a, b) {
            var pos1 = getPositions(a),
                pos2 = getPositions(b);
            return comparePositions(pos1[0], pos2[0]) && comparePositions(pos1[1], pos2[1]);
        };
    })();
    function checkForCollision() {
        var enemyFishes = $('.enemyFishes');
        for (var i = 0; i < enemyFishes.length; i++) {
            if (overlaps($('#heroDiv'), enemyFishes[i])) {
                if ($('#heroDiv').height() < $(enemyFishes[i]).height() && $('#heroDiv').width() < $(enemyFishes[i]).width()) {
                    console.log('YOU DIED, LOOSER!');
                } else {
                    $(enemyFishes[i]).html('').removeClass('enemyFishes');
                    $('#heroDiv').css({
                        height: $('#heroDiv').height() + 3 + 'px',
                        width: $('#heroDiv').width() + 3 + 'px'
                    });
                    $('#heroDiv').find('canvas').css({
                        height: $('#heroDiv').height() + 'px',
                        width: $('#heroDiv').width() + 'px'
                    });
                    console.log($('#heroDiv').find('canvas').height());
                }
            }
        }
    }
    

    function generateEnemyObj() {
        enemyFishCounter += 1;
        var xPosForRightObjs = parseInt($('.mainContainer').css("width"));
        var xPosForLeftObjs = -50;
        var currentEnemy = new EnemyFish();
        var randomObjType = randomGenerator(1, 3);
        var currentYPos = randomGenerator(10, window.innerHeight - 100);
        var size = randomGenerator(40, 150);
        var div = document.createElement('div');
        div.id = enemyFishCounter.toString();
        $(div).addClass('enemyFishes');
        document.body.appendChild(div);
        
        
        //objects looking and moving left
        if (enemyFishCounter % 2 == 0) {
            switch (randomObjType) {
                case 1:
                    currentEnemy.init(xPosForRightObjs - size, currentYPos, size, 2 * size);
                    currentEnemy.canvas = drawSkeleton(size, size / 2, enemyFishCounter.toString());
                    break;
                case 2:
                    currentEnemy.init(xPosForRightObjs - size, currentYPos, size, size);
                    currentEnemy.canvas = drawTriangle(size,
                       size, currentEnemy.x, currentEnemy.y, enemyFishCounter.toString());
                    break;
                case 3:
                    currentEnemy.init(xPosForRightObjs - size, currentYPos, size, size);
                    currentEnemy.canvas = drawOval(size, size, enemyFishCounter.toString());
                    break;

                default:
                    break;
            }
        }
            //objects looking and moving right
        else {
            switch (randomObjType) {
                case 1:
                    currentEnemy.init(xPosForLeftObjs - size, currentYPos, size, size);
                    currentEnemy.canvas = drawTriangleToRight(size, size, enemyFishCounter.toString());
                    break;
                case 2:
                    currentEnemy.init(xPosForLeftObjs - size, currentYPos, size, size);
                    currentEnemy.canvas = drawOvalToRight(size, size, enemyFishCounter.toString());
                    break;
                default:
                    break;
            }

        }
        currentEnemy.div = div;
        currentEnemy.div.style.top = currentEnemy.y + 'px';
        currentEnemy.div.style.left = currentEnemy.x + 'px';
        

        return currentEnemy;
    }

    //function appendDivstoDom(enemiesCount) {

    //    var fragment = document.createDocumentFragment();

    //    for (var i = 0; i <= enemiesCount; i++) {
    //        var currDiv = document.createElement('div');
    //        currDiv.id = i;
    //        fragment.appendChild(currDiv);
    //    }

    //    var heroDiv = document.createElement('div');
    //    heroDiv.id = 'heroDiv';
    //    heroDiv.style.top = window.innerHeight / 2 + 'px'
    //    heroDiv.style.left = window.innerWidth / 2 + 'px';
    //    fragment.appendChild(heroDiv);

    //    document.body.appendChild(fragment);
    //}

    function updateEnemiesPosition(enemiesArr) {

        for (var i = 0; i < enemiesArr.length; i++) {
            
            //if a div gets ot of the screen on the left we set it's position back to inital
            if (enemiesArr[i].x < -300) {

                enemiesArr[i].x = parseInt($('.mainContainer').css("width")) - enemiesArr[i].width;

            }
            //if a div gets ot of the screen on the right we set it's position back to inital
            if (enemiesArr[i].x > window.innerWidth - 10) {
                enemiesArr[i].x = -150;
            }

            //if index is even the fish goes left
            if (enemiesArr[i].div.id % 2 == 0) {
                enemiesArr[i].x -= enemyFishSpeed;
            }
            else {
                enemiesArr[i].x += enemyFishSpeed;
            }
        }
    }
    
    function drawEnemies(enemiesArr) {
        for (var i = 0; i < enemiesArr.length; i++) {
           
            //var currDiv = document.getElementById(i);

            enemiesArr[i].div.style.top = enemiesArr[i].y + 'px';
            enemiesArr[i].div.style.left = enemiesArr[i].x + 'px';
            
        }
    }

    //Will be used lately

    //function generateBonus() {
    //    var yPos = 0;
    //    var xPos = randomGenerator(10, window.innerWidth - 10);
    //    var bonus = new Bonus();
    //    bonus.init(xPos, yPos, 30, 30);

    //    return bonus;
    //}
    function randomGenerator(min, max) {

        var randomNum = Math.floor(Math.random() * (max - min + 1)) + min;

        return randomNum;
    }

    function checkRequestAnimationFrame() {
        if (!window.requestAnimationFrame) {

            window.requestAnimationFrame = (function () {

                return window.webkitRequestAnimationFrame ||
                window.mozRequestAnimationFrame || // comment out if FF4 is slow (it caps framerate at ~30fps: https://bugzilla.mozilla.org/show_bug.cgi?id=630127)
                window.oRequestAnimationFrame ||
                window.msRequestAnimationFrame ||
                function ( /* function FrameRequestCallback */ callback, /* DOMElement Element */ element) {

                    window.setTimeout(callback, 1000 / 60);

                };

            })();

        }
    };
}

