// vertex shader program
var VSHADER_SOURCE =
  'attribute vec4 a_Position;\n' +
  'attribute vec2 a_TexCoord;\n' +
  'uniform mat4 u_MvpMatrix;\n' +
  'uniform mat4 u_ModelMatrix;\n' +
  'varying vec2 v_TexCoord;\n' +
  'void main() {\n' +
  '  gl_Position = u_MvpMatrix * u_ModelMatrix * a_Position;\n' +
  '  v_TexCoord = a_TexCoord;\n' +
  '}\n';

// fragment shader program
var FSHADER_SOURCE =
  '#ifdef GL_ES\n' +
  'precision mediump float;\n' +
  '#endif\n' +
  'uniform sampler2D u_Sampler;\n' +
  'varying vec2 v_TexCoord;\n' +
  'void main() {\n' +
  '  gl_FragColor = texture2D(u_Sampler, v_TexCoord);\n' +
  '}\n';

var gl, texture, u_ModelMatrix, u_Sampler; 
var mvpMatrix = new Matrix4();
var modelMatrix = new Matrix4();
// the images of scene
var sceneImages = [new Image(), new Image(), new Image(), new Image(), new Image()];
sceneImages[0].src = '../resources/sky_cloud.jpg';
sceneImages[1].src = '../resources/lawn.jpg';
sceneImages[2].src = '../resources/road.jpg';
sceneImages[3].src = '../resources/across-road.png';
sceneImages[4].src = '../resources/traffic-sign.png';
// the images of traffic light
var trafficLightImages = [new Image(), new Image(), new Image(), new Image()];
trafficLightImages[0].src = '../resources/traffic-light-black.png';
trafficLightImages[1].src = '../resources/traffic-light-red.png';
trafficLightImages[2].src = '../resources/traffic-light-yellow.png';
trafficLightImages[3].src = '../resources/traffic-light-green.png';
// the images of car
var carImages = [new Image(), new Image(), new Image()];
carImages[0].src = '../resources/car-wheel.png';
carImages[1].src = '../resources/car-skin-red.png';
carImages[2].src = '../resources/car-skin-yellow.png';

function main() {
  var canvas = document.getElementById('webgl');
  gl = getWebGLContext(canvas);  
  initShaders(gl, VSHADER_SOURCE, FSHADER_SOURCE);

  mvpMatrix.setPerspective(100, canvas.width/canvas.height, 1, 100);
  mvpMatrix.lookAt(-10, 10, 0, 0, 0, 0, 0, 1, 0);
  var u_MvpMatrix = gl.getUniformLocation(gl.program, 'u_MvpMatrix');  
  gl.uniformMatrix4fv(u_MvpMatrix, false, mvpMatrix.elements);

  modelMatrix.setIdentity();
  u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix');
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);

  gl.enable(gl.DEPTH_TEST);
  gl.clearColor(0.1, 0.1, 0.1, 1.0);
  gl.viewport(0, 0, canvas.width, canvas.height);  

  texture = gl.createTexture();
  u_Sampler = gl.getUniformLocation(gl.program, 'u_Sampler');

  var tick = 0, angle = 0, wheelSpeed = -20;
  var carPositions1 = [0, 0, 0], carPositions2 = [-10, 0, -10];

  var draw = function() {
    gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);   
    drawScene(angle);
    drawCar(carImages[2], carPositions2, wheelSpeed*2);
    // repeat
    if (tick > 45) {
      tick = 0;
      wheelSpeed = 0;
      carPositions1[0] = 0;
      carPositions2[0] = -10;
      drawTrafficLight(tick);
      drawCar(carImages[1], carPositions1, wheelSpeed);
    // traffic light: red (10s)
    } else if (tick >= 10 && tick < 20) {
      drawTrafficLight(tick);
      drawCar(carImages[1], carPositions1, wheelSpeed);
      wheelSpeed -= 0;
      carPositions1[0] += 0;
    // traffic light: yellow (5s)
    } else if (tick >= 5 && tick < 10) { 
      drawTrafficLight(tick);
      drawCar(carImages[1], carPositions1, wheelSpeed); 
      wheelSpeed -= 10;
      carPositions1[0] += 1;
    // traffic light: green
    } else {  
      drawTrafficLight(tick);
      drawCar(carImages[1], carPositions1, wheelSpeed);
      wheelSpeed -= 20;
      carPositions1[0] += 5;
    }
    tick++; angle++;
    carPositions2[0] += 10;
    requestAnimationFrame(draw, canvas);
  };
  draw();
}

function drawScene(angle) {
  // sky
  modelMatrix.setIdentity();
  modelMatrix.translate(100, 0, 0);
  modelMatrix.scale(1, 100, 200);
  modelMatrix.rotate(angle, 1, 0, 0);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[0]);

  modelMatrix.setIdentity();
  modelMatrix.translate(-100, 0, 0);
  modelMatrix.scale(1, 100, 200);
  modelMatrix.rotate(angle, 0, 0, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[0]);

  modelMatrix.setIdentity();
  modelMatrix.translate(0, 0, 100);
  modelMatrix.scale(200, 100, 1);
  modelMatrix.rotate(angle, 1, 0, 0);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[0]);

  modelMatrix.setIdentity();
  modelMatrix.translate(0, 0, -100);
  modelMatrix.scale(200, 100, 1);
  modelMatrix.rotate(angle, 0, 0, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[0]);

  // lawn
  modelMatrix.setIdentity();
  modelMatrix.translate(0, -1.2, 0);
  modelMatrix.scale(200, 0.1, 200);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[1]); 

  // road
  modelMatrix.setIdentity();
  modelMatrix.translate(10, -1, 0);
  modelMatrix.scale(200, 0, 10);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[2]); 

  // across-road
  modelMatrix.setIdentity();
  modelMatrix.translate(45, -0.5, 0);
  modelMatrix.scale(5, 0, 10);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[3]); 

  // traffic sign
  modelMatrix.setIdentity();
  modelMatrix.translate(10, 0, -15);
  modelMatrix.scale(0.2, 5, 0.2);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[2]);

  modelMatrix.setIdentity();
  modelMatrix.translate(10, 6, -15);
  modelMatrix.scale(1, 1, 1);
  modelMatrix.rotate(180, 1, 0, 0);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[4]);  
}

function drawTrafficLight(tick) {
  modelMatrix.setIdentity();
  modelMatrix.translate(40, 0, 15);
  modelMatrix.scale(0.2, 10, 0.2);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[3]);

  modelMatrix.setIdentity();
  modelMatrix.translate(40, 10, 6);
  modelMatrix.scale(0.1, 0.1, 9);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[2]);

  // traffic light red
  modelMatrix.setIdentity();
  modelMatrix.translate(40, 10, 2);
  modelMatrix.scale(1, 1, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  if (tick >= 10 && tick < 20) {
    drawCube(trafficLightImages[1]);
  } else {
    drawCube(trafficLightImages[0]);
  }

  // traffic light yellow
  modelMatrix.setIdentity();
  modelMatrix.translate(40, 10, 0);
  modelMatrix.scale(1, 1, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  if (tick >= 5 && tick < 10) {
    drawCube(trafficLightImages[2]);
  } else {
    drawCube(trafficLightImages[0]);
  }

  // traffic light green
  modelMatrix.setIdentity();
  modelMatrix.translate(40, 10, -2);
  modelMatrix.scale(1, 1, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  if (tick >= 20 || tick < 5) {
    drawCube(trafficLightImages[3]);
  } else {
    drawCube(trafficLightImages[0]);
  }
}

function drawCar(textureImage, positions, wheelSpeed) {
  // head
  modelMatrix.setIdentity();
  modelMatrix.translate(0 + positions[0], 0 + positions[1], 5 + positions[2]);
  modelMatrix.scale(3, 1, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(textureImage); 

  // hat-head
  modelMatrix.setIdentity();
  modelMatrix.translate(4 + positions[0], -0.5 + positions[1], 5 + positions[2]);
  modelMatrix.scale(1, 0.4, 3);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(textureImage);

  // wheel-head
  modelMatrix.setIdentity();
  modelMatrix.translate(0 + positions[0], 0 + positions[1], 5 + positions[2]);
  modelMatrix.scale(0.1, 0.1, 3.5);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[4]);

  // head-wheel-1
  modelMatrix.setIdentity();
  modelMatrix.translate(0 + positions[0], 0 + positions[1], 3 + positions[2]);
  modelMatrix.scale(1, 1, 1);
  modelMatrix.rotate(wheelSpeed, 0, 0, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(carImages[0]); 

  // head-wheel-2
  modelMatrix.setIdentity();
  modelMatrix.translate(0 + positions[0], 0 + positions[1], 7 + positions[2]);
  modelMatrix.scale(1, 1, 1);
  modelMatrix.rotate(wheelSpeed, 0, 0, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(carImages[0]); 

  // body-1
  modelMatrix.setIdentity();
  modelMatrix.translate(-6 + positions[0], 0 + positions[1], 3 + positions[2]);
  modelMatrix.scale(3, 1, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(textureImage); 

  // car-right
  modelMatrix.setIdentity();
  modelMatrix.translate(-6 + positions[0], 0 + positions[1], 7 + positions[2]);
  modelMatrix.scale(3, 1, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(textureImage); 

  // car-bottom
  modelMatrix.setIdentity();
  modelMatrix.translate(-6 + positions[0], -0.5 + positions[1], 5 + positions[2]);
  modelMatrix.scale(3, 0.1, 3);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(textureImage);

  // car-top
  modelMatrix.setIdentity();
  modelMatrix.translate(-10 + positions[0], 0 + positions[1], 5 + positions[2]);
  modelMatrix.scale(3, 1, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(textureImage);

  // car-head
  modelMatrix.setIdentity();
  modelMatrix.translate(-8 + positions[0], 2 + positions[1], 5 + positions[2]);
  modelMatrix.scale(1, 1, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(textureImage);

  // car-saddle
  modelMatrix.setIdentity();
  modelMatrix.translate(-10 + positions[0], 2 + positions[1], 5 + positions[2]);
  modelMatrix.scale(1, 0.2, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(textureImage);

  // car-behind-top
  modelMatrix.setIdentity();
  modelMatrix.translate(-12 + positions[0], 2 + positions[1], 5 + positions[2]);
  modelMatrix.scale(1, 1, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(textureImage);

  // hat-bottom
  modelMatrix.setIdentity();
  modelMatrix.translate(-12 + positions[0], 3.5 + positions[1], 5 + positions[2]);
  modelMatrix.scale(1, 0.4, 3);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(textureImage);

  // wheel-pivot-body
  modelMatrix.setIdentity();
  modelMatrix.translate(-12 + positions[0], 0 + positions[1], 5 + positions[2]);
  modelMatrix.scale(0.1, 0.1, 3.5);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(sceneImages[4]);

  // body-wheel-1
  modelMatrix.setIdentity();
  modelMatrix.translate(-12 + positions[0], 0 + positions[1], 3 + positions[2]);
  modelMatrix.scale(1, 1, 1);
  modelMatrix.rotate(wheelSpeed, 0, 0, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(carImages[0]); 

  // body-wheel-2
  modelMatrix.setIdentity();
  modelMatrix.translate(-12 + positions[0], 0 + positions[1], 7 + positions[2]);
  modelMatrix.scale(1, 1, 1);
  modelMatrix.rotate(wheelSpeed, 0, 0, 1);
  gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
  drawCube(carImages[0]); 
}

function drawCube(textureImage) {
  // load texture
  gl.pixelStorei(gl.UNPACK_FLIP_Y_WEBGL, 1);
  gl.activeTexture(gl.TEXTURE0);
  gl.bindTexture(gl.TEXTURE_2D, texture); 
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
  gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, textureImage);
  gl.uniform1i(u_Sampler, 0);

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
  var texCoords = new Float32Array([
    1.0, 1.0,   0.0, 1.0,   0.0, 0.0,   1.0, 0.0,    // v0-v1-v2-v3 front
    0.0, 1.0,   0.0, 0.0,   1.0, 0.0,   1.0, 1.0,    // v0-v3-v4-v5 right
    1.0, 0.0,   1.0, 1.0,   0.0, 1.0,   0.0, 0.0,    // v0-v5-v6-v1 up
    1.0, 1.0,   0.0, 1.0,   0.0, 0.0,   1.0, 0.0,    // v1-v6-v7-v2 left
    0.0, 0.0,   1.0, 0.0,   1.0, 1.0,   0.0, 1.0,    // v7-v4-v3-v2 down
    0.0, 0.0,   1.0, 0.0,   1.0, 1.0,   0.0, 1.0     // v4-v7-v6-v5 back
  ]);

  initArrayBuffer(vertices, 3, gl.FLOAT, 'a_Position');   
  initArrayBuffer(texCoords, 2, gl.FLOAT, 'a_TexCoord');

  var indexBuffer = gl.createBuffer();
  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);
  gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_BYTE, 0);
}

function initArrayBuffer(data, num, type, attribute) {
  var buffer = gl.createBuffer();  
  gl.bindBuffer(gl.ARRAY_BUFFER, buffer);
  gl.bufferData(gl.ARRAY_BUFFER, data, gl.STATIC_DRAW);
  var a_attribute = gl.getAttribLocation(gl.program, attribute);
  gl.vertexAttribPointer(a_attribute, num, type, false, 0, 0);
  gl.enableVertexAttribArray(a_attribute);  
}
