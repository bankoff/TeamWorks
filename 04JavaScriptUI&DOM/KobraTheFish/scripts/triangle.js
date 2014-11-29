function drawTriangle (CONST_WIDTH, CONST_HEIGHT, x, y, id) {
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

    var body = new Kinetic.Line({
        points: [1, CONST_HEIGHT * 0.5, CONST_WIDTH * 0.8, 1, CONST_WIDTH * 0.8, CONST_HEIGHT - 1, 1, CONST_HEIGHT * 0.5, CONST_WIDTH * 0.2, CONST_HEIGHT * 0.5],
        stroke: '#DEA31A'
    });

    var eye = new Kinetic.Circle({
        x: CONST_WIDTH * 0.34,
        y: CONST_HEIGHT * 0.4,
        radius: CONST_HEIGHT * 0.05,
        fill: '#DEA31A'
    });

    var curve = new Kinetic.Line({
        points: [CONST_WIDTH * 0.35, CONST_HEIGHT * 0.28, CONST_WIDTH * 0.5, CONST_HEIGHT * 0.5, CONST_WIDTH * 0.34, CONST_HEIGHT * 0.70],
        stroke: '#DEA31A',
        tension: 1
    });

    var tail = new Kinetic.Line({
        points: [CONST_WIDTH * 0.8, CONST_HEIGHT * 0.5, CONST_WIDTH, CONST_HEIGHT * 0.25, CONST_WIDTH * 0.9, CONST_HEIGHT * 0.5, CONST_WIDTH, CONST_HEIGHT * 0.75, CONST_WIDTH * 0.8, CONST_HEIGHT * 0.5],
        stroke: '#DEA31A',
        tension: 1
    });

    layer.add(tail);
    layer.add(curve);
    layer.add(eye);
    layer.add(body);
    //layer.add(rect);
    return stage.add(layer);
}

// HEIGHT MUST BE EXACTLY AS LONG AS THE WIDTH
var width = 100,
    height = 100;
//drawTriangle(width, height, 100, 100);