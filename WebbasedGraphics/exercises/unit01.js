// Vertex shader program
var VSHADER_SOURCE =
    'attribute vec4 a_Position;\n' +
    'attribute vec4 a_Color;\n' +
    'uniform mat4 u_MvpMatrix;\n' +
    'uniform mat4 u_ModelMatrix;\n' +
    'varying vec4 v_Color;\n' +
    'void main() {\n' +
    '  gl_Position = u_MvpMatrix * u_ModelMatrix * a_Position;\n' +
    '  v_Color = a_Color;\n' +
    '}\n';

// Fragment shader program
var FSHADER_SOURCE =
    '#ifdef GL_ES\n' +
    'precision mediump float;\n' +
    '#endif\n' +
    'varying vec4 v_Color;\n' +
    'void main() {\n' +
    '  gl_FragColor = v_Color;\n' +
    '}\n';

function main() {
    var canvas = document.getElementById('webgl');
    var gl = getWebGLContext(canvas);
    initShaders(gl, VSHADER_SOURCE, FSHADER_SOURCE);

    var mvpMatrix = new Matrix4();
    mvpMatrix.setPerspective(30, 1, 1, 100);
    mvpMatrix.lookAt(0, 0, 20, 0, 0, 0, 0, 1, 0);
    var u_MvpMatrix = gl.getUniformLocation(gl.program, 'u_MvpMatrix');
    gl.uniformMatrix4fv(u_MvpMatrix, false, mvpMatrix.elements);

    var ModelMatrix = new Matrix4();
    ModelMatrix.setTranslate(0, 0, 0);
    var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
    gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);

    gl.clearColor(0.0, 0.0, 0.0, 1.0);
    gl.enable(gl.DEPTH_TEST);
    gl.viewport(0, 0, canvas.width, canvas.height);

    var currentAngle = 0.0;
    // gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);

    var tick = function() {
        gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);

        currentAngle = animate(currentAngle);


        ModelMatrix.setTranslate(0, 0, 0);
        ModelMatrix.setScale(2, 3, 1.5)
            //ModelMatrix.rotate(currentAngle, 0, 1, 0);
        var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
        gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);
        drawcube(gl);

        ModelMatrix.setTranslate(0, 2.3, 0);
        //ModelMatrix.setScale(0.5, 0.5, 0.5);
        //ModelMatrix.rotate(currentAngle, 0, 1, 0)
        var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
        gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);
        drawcube(gl);

        ModelMatrix.setTranslate(0, 2, 0);
        ModelMatrix.scale(0.3, 1, 0.3)
        var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
        gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);
        drawcube(gl);

        ModelMatrix.setTranslate(1.3, 1.15, 0);
        ModelMatrix.scale(1.5, 0.5, 0.5)
        var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
        gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);
        drawcube(gl);

        ModelMatrix.setTranslate(-1.3, 1.15, 0);
        ModelMatrix.scale(1.5, 0.5, 0.5)
        var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
        gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);
        drawcube(gl);

        ModelMatrix.setTranslate(-1.8, 0.6, 0);
        ModelMatrix.scale(0.5, 1.5, 0.5)
        var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
        gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);
        drawcube(gl);
        ModelMatrix.setTranslate(1.8, 0.6, 0);
        ModelMatrix.scale(0.5, 1.5, 0.5)
        var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
        gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);
        drawcube(gl);

        ModelMatrix.setTranslate(0.65, -2.4, 0);
        ModelMatrix.scale(0.7, 2.5, 0.7)
        var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
        gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);
        drawcube(gl);
        ModelMatrix.setTranslate(-0.65, -2.4, 0);
        ModelMatrix.scale(0.7, 2.5, 0.7)
        var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
        gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);
        drawcube(gl);



        requestAnimationFrame(tick, canvas);
    };
    tick();
}

function drawcood(gl) {
    var vertices = new Float32Array([
        0.0, 0.0, 0.0,
        10.0, 0.0, 0.0,
        0.0, 10.0, 0.0,
        0.0, 0.0, 10.0
    ]);
    var colors = new Float32Array([
        1.0, 1.0, 1.0,
        0.0, 0.0, 0.0,
        0.0, 0.0, 0.0,
        0.0, 0.0, 0.0,
    ]);
    var indices = new Uint8Array([
        0, 1, 0, 2, 0, 3
    ]);

    var indexBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
    gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);

    initArrayBuffer(gl, vertices, 3, gl.FLOAT, 'a_Position');
    initArrayBuffer(gl, colors, 3, gl.FLOAT, 'a_Color');

    gl.drawElements(gl.LINES, indices.length, gl.UNSIGNED_BYTE, 0);
}

function drawcube(gl) {
    var vertices = new Float32Array([
        0.5, 0.5, 0.5, -0.5, 0.5, 0.5, -0.5, -0.5, 0.5, 0.5, -0.5, 0.5, // v0-v1-v2-v3 front
        0.5, 0.5, 0.5, 0.5, -0.5, 0.5, 0.5, -0.5, -0.5, 0.5, 0.5, -0.5, // v0-v3-v4-v5 right
        0.5, 0.5, 0.5, 0.5, 0.5, -0.5, -0.5, 0.5, -0.5, -0.5, 0.5, 0.5, // v0-v5-v6-v1 up
        -0.5, 0.5, 0.5, -0.5, 0.5, -0.5, -0.5, -0.5, -0.5, -0.5, -0.5, 0.5, // v1-v6-v7-v2 left
        -0.5, -0.5, -0.5, 0.5, -0.5, -0.5, 0.5, -0.5, 0.5, -0.5, -0.5, 0.5, // v7-v4-v3-v2 down
        0.5, -0.5, -0.5, -0.5, -0.5, -0.5, -0.5, 0.5, -0.5, 0.5, 0.5, -0.5,
    ]);
    var colors = new Float32Array([
        0.4, 0.4, 1.0, 0.4, 0.4, 1.0, 0.4, 0.4, 1.0, 0.4, 0.4, 1.0, // v0-v1-v2-v3 front(blue)
        0.4, 1.0, 0.4, 0.4, 1.0, 0.4, 0.4, 1.0, 0.4, 0.4, 1.0, 0.4, // v0-v3-v4-v5 right(green)
        1.0, 0.4, 0.4, 1.0, 0.4, 0.4, 1.0, 0.4, 0.4, 1.0, 0.4, 0.4, // v0-v5-v6-v1 up(red)
        1.0, 1.0, 0.4, 1.0, 1.0, 0.4, 1.0, 1.0, 0.4, 1.0, 1.0, 0.4, // v1-v6-v7-v2 left
        1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, // v7-v4-v3-v2 down
        0.4, 1.0, 1.0, 0.4, 1.0, 1.0, 0.4, 1.0, 1.0, 0.4, 1.0, 1.0 // v4-v7-v6-v5 back
    ]);
    var indices = new Uint8Array([
        0, 1, 2, 0, 2, 3, // front
        4, 5, 6, 4, 6, 7, // right
        8, 9, 10, 8, 10, 11, // up
        12, 13, 14, 12, 14, 15, // left
        16, 17, 18, 16, 18, 19, // down
        20, 21, 22, 20, 22, 23 // back   
    ]);

    var indexBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
    gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);

    initArrayBuffer(gl, vertices, 3, gl.FLOAT, 'a_Position');
    initArrayBuffer(gl, colors, 3, gl.FLOAT, 'a_Color');

    gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_BYTE, 0);
}

function initArrayBuffer(gl, data, num, type, attribute) {
    var buffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, buffer);
    gl.bufferData(gl.ARRAY_BUFFER, data, gl.STATIC_DRAW);
    var a_attribute = gl.getAttribLocation(gl.program, attribute);
    gl.vertexAttribPointer(a_attribute, num, type, false, 0, 0);
    gl.enableVertexAttribArray(a_attribute);
    return true;
}

var ANGLE_STEP = 50.0;
var g_last = Date.now();

function animate(angle) {
    var now = Date.now();
    var elapsed = now - g_last;
    g_last = now;
    var newAngle = angle + (ANGLE_STEP * elapsed) / 1000.0;
    return newAngle %= 360;
}