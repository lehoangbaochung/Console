var VSHADER_SOURCE =
  'attribute vec4 a_Position;\n' +
  'attribute vec2 a_TexCoord;\n' +
  'attribute vec4 a_Color;\n' + 
  'attribute vec4 a_Normal;\n' + 
  'uniform mat4 u_MvpMatrix;\n' +
  'uniform mat4 u_ModelMatrix;\n' +
  'varying vec2 v_TexCoord;\n' +
  'uniform vec3 u_LightColor;\n' +     
  'uniform vec3 u_LightDirection;\n' + 
  'varying vec4 v_Color;\n' +
  'void main() {\n' +
  '  gl_Position = u_MvpMatrix * u_ModelMatrix * a_Position;\n' +
  '  vec3 normal = normalize(a_Normal.xyz);\n' +
  '  float nDotL = max(dot(u_LightDirection, normal), 0.0);\n' +
  '  vec3 diffuse = u_LightColor * a_Color.rgb * nDotL;\n' +
  '  v_Color = vec4(diffuse, a_Color.a);\n' +
  '  v_TexCoord = a_TexCoord;\n' +
  '}\n';

var FSHADER_SOURCE =
    '#ifdef GL_ES\n' +
    'precision mediump float;\n' +
    '#endif\n' +
    'uniform sampler2D u_Sampler;\n' +
    'varying vec2 v_TexCoord;\n' +
    'varying vec4 v_Color;\n' +
    'void main() {\n' +
    '  gl_FragColor = texture2D(u_Sampler, v_TexCoord) + v_Color;\n' +
    '}\n';

function main() {
    var canvas = document.getElementById('webgl');
    var gl = getWebGLContext(canvas);  
    initShaders(gl, VSHADER_SOURCE, FSHADER_SOURCE);

    var mvpMatrix = new Matrix4();
    mvpMatrix.setPerspective(80, 1, 1, 100);
    mvpMatrix.lookAt(-10, 15, 15, 0, 0, 0, 0, 1, 0);
    var u_MvpMatrix = gl.getUniformLocation(gl.program, 'u_MvpMatrix');  
    gl.uniformMatrix4fv(u_MvpMatrix, false, mvpMatrix.elements);
   
    var modelMatrix = new Matrix4();
    modelMatrix.setIdentity();
    var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
    gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);

    gl.enable(gl.DEPTH_TEST);
    gl.clearColor(0.1, 0.1, 0.1, 1.0);
    gl.viewport(0, 0, canvas.width, canvas.height);  

    texture = gl.createTexture();
    u_Sampler = gl.getUniformLocation(gl.program, 'u_Sampler');

    var footAngle = 0;
    var currentAngle = [0.0, 0.0];
    initEventHandlers(canvas, currentAngle);

    var tick = function() {
        gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);     

        // left-foot
        modelMatrix.setIdentity();
        modelMatrix.setTranslate(-0.5, -2, 0);
        modelMatrix.scale(0.5, 3, 0.5);
        modelMatrix.rotate(currentAngle[0] + footAngle, 1, 0, 0);
        gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
        drawCube(gl, 0);  

        // right-foot
        modelMatrix.setIdentity();
        modelMatrix.setTranslate(2.5, -2, 0);
        modelMatrix.scale(0.5, 3, 0.5);
        modelMatrix.rotate(currentAngle[0] - footAngle, 1, 0, 0);
        gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
        drawCube(gl, 0); 
        
        // body
        modelMatrix.setIdentity();
        modelMatrix.setTranslate(1, 3, 0);
        modelMatrix.scale(2, 3, 2);
        gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
        drawCube(gl, 0); 

        // right-arm
        modelMatrix.setIdentity();
        modelMatrix.setTranslate(-1.5, 5.5, 2);
        modelMatrix.scale(0.5, 0.5, 2);
        modelMatrix.rotate(currentAngle[0] - footAngle, 1, 0, 0);
        gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
        drawCube(gl, 1);

        // left-arm
        modelMatrix.setIdentity();
        modelMatrix.setTranslate(3.5, 5.5, 2);
        modelMatrix.scale(0.5, 0.5, 2);
        modelMatrix.rotate(currentAngle[0] + footAngle, 1, 0, 0);
        gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
        drawCube(gl, 1);

        // head
        modelMatrix.setIdentity();
        modelMatrix.setTranslate(1, 7, 0);
        modelMatrix.rotate(currentAngle[1], 0, 1, 0); 
        gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
        drawCube(gl, 1);

        // // ground
        // modelMatrix.setIdentity();
        // modelMatrix.setTranslate(-10, -10, -20);
        // modelMatrix.scale(50, 0.5, 50);
        // gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
        // drawCube(gl, 0);

        requestAnimationFrame(tick, canvas);
    };
    tick();
}

function drawCube(gl, index) {
  loadTexture(gl, index);

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
  var normals = new Float32Array([    // Normal
    0.0, 0.0, 1.0,   0.0, 0.0, 1.0,   0.0, 0.0, 1.0,   0.0, 0.0, 1.0,  // v0-v1-v2-v3 front
    1.0, 0.0, 0.0,   1.0, 0.0, 0.0,   1.0, 0.0, 0.0,   1.0, 0.0, 0.0,  // v0-v3-v4-v5 right
    0.0, 1.0, 0.0,   0.0, 1.0, 0.0,   0.0, 1.0, 0.0,   0.0, 1.0, 0.0,  // v0-v5-v6-v1 up
    -1.0, 0.0, 0.0,  -1.0, 0.0, 0.0,  -1.0, 0.0, 0.0,  -1.0, 0.0, 0.0,  // v1-v6-v7-v2 left
    0.0,-1.0, 0.0,   0.0,-1.0, 0.0,   0.0,-1.0, 0.0,   0.0,-1.0, 0.0,  // v7-v4-v3-v2 down
    0.0, 0.0,-1.0,   0.0, 0.0,-1.0,   0.0, 0.0,-1.0,   0.0, 0.0,-1.0   // v4-v7-v6-v5 back
  ]);
  var texCoords = new Float32Array([
    1.0, 1.0,   0.0, 1.0,   0.0, 0.0,   1.0, 0.0,    // v0-v1-v2-v3 front
    0.0, 1.0,   0.0, 0.0,   1.0, 0.0,   1.0, 1.0,    // v0-v3-v4-v5 right
    1.0, 0.0,   1.0, 1.0,   0.0, 1.0,   0.0, 0.0,    // v0-v5-v6-v1 up
    1.0, 1.0,   0.0, 1.0,   0.0, 0.0,   1.0, 0.0,    // v1-v6-v7-v2 left
    0.0, 0.0,   1.0, 0.0,   1.0, 1.0,   0.0, 1.0,    // v7-v4-v3-v2 down
    0.0, 0.0,   1.0, 0.0,   1.0, 1.0,   0.0, 1.0     // v4-v7-v6-v5 back
  ]);

  initArrayBuffer(gl, vertices, 3, gl.FLOAT, 'a_Position');   
  initArrayBuffer(gl, texCoords, 2, gl.FLOAT, 'a_TexCoord');
  initArrayBuffer(gl, normals, 3, gl.FLOAT, 'a_Normal');

  var indexBuffer = gl.createBuffer();
  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);
  gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_BYTE, 0);
}

var texture, u_Sampler; 
var textureImages = [ new Image(), new Image(), new Image(), ];
textureImages[0].src = '../resources/sky.jpg';
textureImages[1].src = '../resources/circle.gif';
textureImages[2].src = '../resources/sky_cloud.jpg';

function loadTexture(gl, index) {
  gl.pixelStorei(gl.UNPACK_FLIP_Y_WEBGL, 1);
  gl.activeTexture(gl.TEXTURE0);
  gl.bindTexture(gl.TEXTURE_2D, texture); 
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
  gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, textureImages[index]);
  gl.uniform1i(u_Sampler, 0); 
  return true;
}

function initEventHandlers(canvas, currentAngle) {
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

  canvas.onmouseup = function() { dragging = false; };

  canvas.onmousemove = function(ev) {
    var x = ev.clientX, y = ev.clientY;
    if (dragging) {
      var factor = 100/canvas.height;
      var dx = factor * (x - lastX);
      var dy = factor * (y - lastY);
      currentAngle[0] = Math.max(Math.min(currentAngle[0] + dy, 90.0), -90.0);
      currentAngle[1] = currentAngle[1] + dx;
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