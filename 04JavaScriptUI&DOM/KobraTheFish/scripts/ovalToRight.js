function drawOvalToRight(CONST_WIDTH, CONST_HEIGHT, id) {
    var stage = new Kinetic.Stage({
            container: id,
            width: CONST_WIDTH,
            height: CONST_HEIGHT
        }),
        layer = new Kinetic.Layer();

    // border
    var rect = new Kinetic.Rect({
        x: 0,
        y: 0,
        width: CONST_WIDTH,
        height: CONST_HEIGHT,
        stroke: '#000'
    });

    var body = new Kinetic.Circle({
        x: CONST_WIDTH * 0.63 + 2,
        y: CONST_HEIGHT * 0.5,
        radius: CONST_WIDTH * 0.37,
        stroke: 'red'
    });

    var eye = new Kinetic.Ellipse({
        x: CONST_WIDTH * 0.8 + 2,
        y: CONST_HEIGHT * 0.5,
        radius: {
            x: CONST_WIDTH * 0.2,
            y: CONST_HEIGHT * 0.3//
        },
        fill: '#E65151'
    });

    var pupil = new Kinetic.Circle({
        x: CONST_WIDTH * 0.86,
        y: CONST_HEIGHT * 0.37,
        radius: CONST_WIDTH * 0.11,
        fill: '#AE0909'
    });

    var eyelash1 = new Kinetic.Line({
        points: [CONST_WIDTH * 0.86, CONST_HEIGHT * 0.28, CONST_WIDTH * 0.81, CONST_HEIGHT * 0.18],
        stroke: 'black'
    });

    var eyelash2 = new Kinetic.Line({
        points: [CONST_WIDTH * 0.82, CONST_HEIGHT * 0.28, CONST_WIDTH * 0.77, CONST_HEIGHT * 0.18],
        stroke: 'black'
    });

    var eyelash3 = new Kinetic.Line({
        points: [CONST_WIDTH * 0.78, CONST_HEIGHT * 0.28, CONST_WIDTH * 0.73, CONST_HEIGHT * 0.18],
        stroke: 'black'
    });

    var finUp = new Kinetic.Line({
        points: [CONST_WIDTH * 0.73, CONST_HEIGHT * 0.91, CONST_WIDTH * 0.5, CONST_HEIGHT - 1, CONST_WIDTH * 0.55, CONST_HEIGHT * 0.91],
        fill: '#AE0909',
        tension: 2,
        closed: true
    });

    var finDown = new Kinetic.Line({
        points: [CONST_WIDTH * 0.73, CONST_HEIGHT * 0.09, CONST_WIDTH * 0.5, 1, CONST_WIDTH * 0.55, CONST_HEIGHT * 0.09],
        fill: '#AE0909',
        tension: 2,
        closed: true
    });

    var tail = new Kinetic.Line({
        points: [CONST_WIDTH * 0.26, CONST_HEIGHT * 0.5, CONST_WIDTH * 0.17, CONST_HEIGHT * 0.65, CONST_WIDTH * 0.17, CONST_HEIGHT * 0.35],
        stroke: '#E65151',
        closed: true,
        tension: 5,
        fill: 'pink'
    });


    layer.add(finUp);
    layer.add(finDown);
    layer.add(eye);
    layer.add(eyelash1);
    layer.add(eyelash2);
    layer.add(eyelash3);
    layer.add(body);
    layer.add(pupil);
    layer.add(tail);
    //layer.add(rect);
    return stage.add(layer);
}

// HEIGHT MUST BE EXACTLY AS LONG AS THE WIDTH
var width = 100,
    height = 100;
//drawOval(width, height);