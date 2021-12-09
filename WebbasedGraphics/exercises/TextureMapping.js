var VSHADER_SOURCE =
  'attribute vec4 a_Position;\n' +
  'attribute vec2 a_TexCoord0;\n' +
  'attribute vec2 a_TexCoord1;\n' +
  'uniform mat4 u_MvpMatrix;\n' +
  'uniform mat4 u_ModelMatrix;\n' +
  'varying vec2 v_TexCoord0;\n' +
  'varying vec2 v_TexCoord1;\n' +
  'void main() {\n' +
  '  gl_Position = u_MvpMatrix * u_ModelMatrix * a_Position;\n' +
  '  v_TexCoord0 = a_TexCoord0;\n' +
  '  v_TexCoord1 = a_TexCoord1;\n' +
  '}\n';

var FSHADER_SOURCE =
    '#ifdef GL_ES\n' +
    'precision mediump float;\n' +
    '#endif\n' +
    'uniform sampler2D u_Sampler0;\n' +
    'uniform sampler2D u_Sampler1;\n' +
    'varying vec2 v_TexCoord0;\n' +
    'varying vec2 v_TexCoord1;\n' +
    'void main() {\n' +
    '  gl_FragColor = (texture2D(u_Sampler0, v_TexCoord0) + texture2D(u_Sampler1, v_TexCoord1));\n' +
    '}\n';

function main() {
    var canvas = document.getElementById('webgl');
    var gl = getWebGLContext(canvas);  
    initShaders(gl, VSHADER_SOURCE, FSHADER_SOURCE);

    var mvpMatrix = new Matrix4();
    mvpMatrix.setPerspective(30, 1, 1, 100);
    mvpMatrix.lookAt(3, 3, 10, 0, 0, 0, 0, 1, 0);
    var u_MvpMatrix = gl.getUniformLocation(gl.program, 'u_MvpMatrix');  
    gl.uniformMatrix4fv(u_MvpMatrix, false, mvpMatrix.elements);
   
    var ModelMatrix = new Matrix4();
    ModelMatrix.setIdentity();
    var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
    gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);

    gl.clearColor(0.1, 0.1, 0.1, 1.0);
    gl.enable(gl.DEPTH_TEST);
    gl.viewport(0, 0, canvas.width, canvas.height);  

    var currentAngle = [0.0, 0.0];
    initEventHandlers(canvas, currentAngle);
    initTextures(gl);

    var tick = function() {
        gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);
        ModelMatrix.setIdentity();
        ModelMatrix.rotate(currentAngle[0], 1, 0, 0);
        ModelMatrix.rotate(currentAngle[1], 0, 1, 0);      
        var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
        gl.uniformMatrix4fv(u_ModelMatrix, false, ModelMatrix.elements);
        drawCube(gl);  
        requestAnimationFrame(tick, canvas);
    };
    tick();
}

function drawCube(gl){
    var vertices = new Float32Array([
         1.0, 1.0, 1.0,  -1.0, 1.0, 1.0,  -1.0,-1.0, 1.0,   1.0,-1.0, 1.0,    // v0-v1-v2-v3 front
         1.0,-1.0,-1.0,  -1.0,-1.0,-1.0,  -1.0, 1.0,-1.0,   1.0, 1.0,-1.0,    // v4-v7-v6-v5 back
         1.0, 1.0, 1.0,   1.0, 1.0,-1.0,  -1.0, 1.0,-1.0,  -1.0, 1.0, 1.0,    // v0-v5-v6-v1 up
        -1.0,-1.0,-1.0,   1.0,-1.0,-1.0,   1.0,-1.0, 1.0,  -1.0,-1.0, 1.0,    // v7-v4-v3-v2 down
         1.0, 1.0, 1.0,   1.0,-1.0, 1.0,   1.0,-1.0,-1.0,   1.0, 1.0,-1.0,    // v0-v3-v4-v5 right
        -1.0, 1.0, 1.0,  -1.0, 1.0,-1.0,  -1.0,-1.0,-1.0,  -1.0,-1.0, 1.0,    // v1-v6-v7-v2 left
    ]);
    var indices = new Uint8Array([
        0, 1, 2, 0, 2, 3, // front
        4, 5, 6, 4, 6, 7, // back
        8, 9, 10, 8, 10, 11, // up
        12, 13, 14, 12, 14, 15, // down
        16, 17, 18, 16, 18, 19, // right
        20, 21, 22, 20, 22, 23 // left  
    ]);
    var texCoords0 = new Float32Array([
        1.0, 1.0,   0.0, 1.0,   0.0, 0.0,   1.0, 0.0,    // v0-v1-v2-v3 front
        0.0, 0.0,   1.0, 0.0,   1.0, 1.0,   0.0, 1.0,     // v4-v7-v6-v5 back
    ]);
    var texCoords1 = new Float32Array([
        0.0, 0.0,   0.0, 0.0,   0.0, 0.0,   0.0, 0.0,    // v0-v1-v2-v3 front
        0.0, 0.0,   0.0, 0.0,   0.0, 0.0,   0.0, 0.0,     // v4-v7-v6-v5 back
        1.0, 0.0,   1.0, 1.0,   0.0, 1.0,   0.0, 0.0,    // v0-v5-v6-v1 up
        0.0, 0.0,   1.0, 0.0,   1.0, 1.0,   0.0, 1.0,    // v7-v4-v3-v2 down
    ]);

    var indexBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
    gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);

    initArrayBuffer(gl, vertices, 3, gl.FLOAT, 'a_Position');   
    initArrayBuffer(gl, texCoords0, 2, gl.FLOAT, 'a_TexCoord0');
    initArrayBuffer(gl, texCoords1, 2, gl.FLOAT, 'a_TexCoord1');

    gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_BYTE, 0);
}

function initTextures(gl) {
    var texture0 = gl.createTexture();
    var texture1 = gl.createTexture();  

    var u_Sampler0 = gl.getUniformLocation(gl.program, 'u_Sampler0');
    var u_Sampler1 = gl.getUniformLocation(gl.program, 'u_Sampler1');  

    var image0 = new Image();
    var image1 = new Image();

    image0.onload = function(){ loadTexture(gl, texture0, u_Sampler0, image0, 0); };
    image1.onload = function(){ loadTexture(gl, texture1, u_Sampler1, image1, 1); };

    image0.src = '../resources/redflower.jpg';
    image1.src = '../resources/yellowflower.jpg';
    return true;
}

var g_texUnit0 = false, g_texUnit1 = false;
function loadTexture(gl, texture, u_Sampler, image, texUnit) {
    gl.pixelStorei(gl.UNPACK_FLIP_Y_WEBGL, 1);
    if (texUnit == 0) {
        gl.activeTexture(gl.TEXTURE0);
        g_texUnit0 = true;
    } else {
        gl.activeTexture(gl.TEXTURE1);
        g_texUnit1 = true;
    }
    gl.bindTexture(gl.TEXTURE_2D, texture);  
    gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
    gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, image);
    gl.uniform1i(u_Sampler, texUnit);
}

function initEventHandlers(canvas, currentAngle1) {
    var dragging = false;
    var lastX = -1, lastY = -1;

    canvas.onmousedown = function(ev) {
        var x = ev.clientX, y = ev.clientY;
        var rect = ev.target.getBoundingClientRect();
        if (rect.left <= x && x < rect.right && rect.top <= y && y < rect.bottom) {
            lastX = x; lastY = y;
            dragging = true;
        }
    };

    canvas.onmouseup = function(ev) { dragging = false;  };

    canvas.onmousemove = function(ev) {
        var x = ev.clientX, y = ev.clientY;
        if (dragging) {
            var factor = 100/canvas.height;
            var dx = factor * (x - lastX);
            var dy = factor * (y - lastY);
            currentAngle1[0] = Math.max(Math.min(currentAngle1[0] + dy, 90.0), -90.0);
            currentAngle1[1] = currentAngle1[1] + dx;
        }
        lastX = x, lastY = y;
    };
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
