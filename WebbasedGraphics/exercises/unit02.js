// Vertex shader program
var VSHADER_SOURCE =
  'attribute vec4 a_Position;\n' +
  'attribute vec4 a_Color;\n' +
  'uniform mat4 u_MvpMatrix;\n' +
  'uniform mat4 u_modelMatrix;\n' +
  'varying vec4 v_Color;\n' +
  'void main() {\n' +
  '  gl_Position = u_MvpMatrix * u_modelMatrix * a_Position;\n' +
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
  // Lấy thành phần canvas
  var canvas = document.getElementById('webgl');
  // Get the rendering context for WebGL
  var gl = getWebGLContext(canvas); 
  // Khởi tạo các shader
  initShaders(gl, VSHADER_SOURCE, FSHADER_SOURCE); 
  
  // Đặt điểm nhìn và điều chỉnh kích thước
  var mvpMatrix = new Matrix4();
  mvpMatrix.setPerspective(20, canvas.width/canvas.height, 1, 100);
  mvpMatrix.lookAt(5, 5, 10, 0, 0, 0, 0, 1, 0);
  var u_MvpMatrix = gl.getUniformLocation(gl.program, 'u_MvpMatrix');  
  // Pass the model view projection matrix to u_MvpMatrix
  gl.uniformMatrix4fv(u_MvpMatrix, false, mvpMatrix.elements);
    
  // Khởi tạo ma trận
  var modelMatrix = new Matrix4();
  // Lấy vị trí của ma trận
  var u_modelMatrix = gl.getUniformLocation(gl.program, 'u_modelMatrix');
  // Trỏ vị trí của ma trận vào modelMatrix.elements
  gl.uniformMatrix4fv(u_modelMatrix, false, modelMatrix.elements);
  
  /*================= Mouse events ======================*/
  var drag = false;
  var old_x, old_y;
  var dX = 0, dY = 0;
  var THETA = 0, PHI = 0;

  var mouseDown = function(e) {
    drag = true;
    old_x = e.pageX, old_y = e.pageY;
    e.preventDefault();
    return false;
  };

  var mouseUp = function(e) {
    drag = false;
  };

  var mouseMove = function(e) {
    if (!drag) return false;
    dX = (e.pageX-old_x)*2*Math.PI/canvas.width,
    dY = (e.pageY-old_y)*2*Math.PI/canvas.height;
    THETA+= dX;
    PHI+=dY;
    old_x = e.pageX, old_y = e.pageY;
    e.preventDefault();
  };

  canvas.addEventListener("mousedown", mouseDown, false);
  canvas.addEventListener("mouseup", mouseUp, false);
  canvas.addEventListener("mouseout", mouseUp, false);
  canvas.addEventListener("mousemove", mouseMove, false);

  // Auto rotate
  // if (!drag) {
  //   dX *= AMORTIZATION, dY*=AMORTIZATION;
  //   THETA+=dX, PHI+=dY; 
  // } 
  var angle = 0;
  var animate = function() {
    angle++;           

    gl.clearColor(0.0, 0.0, 0.0, 1.0);
    gl.enable(gl.DEPTH_TEST);
    gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);     
    gl.viewport(0, 0, canvas.width, canvas.height);  

    // Vẽ hệ trục toạ độ
    modelMatrix.setTranslate(0, 0, 0);
    drawCoordinate(gl, modelMatrix);

    // Vẽ hình lập phương có một đỉnh trùng với gốc tọa độ
    // modelMatrix.setTranslate(1, 1, 1);
    // drawCube(gl, modelMatrix);

    // // Vẽ trục đi qua điểm (5,0,0) và song song với oy
    // modelMatrix.setTranslate(5, 0, 0);
    // drawLine(gl, modelMatrix);

    // // Vẽ hình lập phương liên tục xoay xung quanh trục vừa vẽ
    // modelMatrix.setTranslate(5, 1, 0);
    // modelMatrix.rotate(PHI * 50, 1, 0, 0);
    // modelMatrix.rotate(THETA * 50, 0, 1, 0);
    // drawCube(gl, modelMatrix); 

    
    //  modelMatrix.scale(2, 2, 2);
    modelMatrix.setTranslate(0.5, 0, 0);
    modelMatrix.rotate(45, 0,0,1);
    // modelMatrix.translate(0.5, 0, 0.0);
    drawTriangle(gl, modelMatrix);

    window.requestAnimationFrame(animate);
  }
  animate();
}

function drawCoordinate(gl, modelMatrix) {  
  var u_modelMatrix = gl.getUniformLocation(gl.program, 'u_modelMatrix');
  gl.uniformMatrix4fv(u_modelMatrix, false, modelMatrix.elements);

  var vertices = new Float32Array([   // Vertex coordinates   
    0.0, 0.0, 0.0,   
    10.0, 0.0, 0.0,  
    0.0, 10.0, 0.0, 
    0.0, 0.0, 10.0
  ]); 
  
  var colors = new Float32Array([     // Colors 
    1.0, 0.0, 0.0,
    0.0, 0.0, 0.0,  
    0.0, 0.0, 0.0,  
    0.0, 0.0, 0.0,   
  ]);
  
  var indices = new Uint8Array([       // Indices of the vertices
    0,1,0,2,0,3     
  ]);
  
  // Create a buffer object for index
  var indexBuffer = gl.createBuffer();
  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);

  // Create a buffer object for
  initArrayBuffer(gl, vertices, 3, gl.FLOAT, 'a_Position');  
  initArrayBuffer(gl, colors, 3, gl.FLOAT, 'a_Color');   
  
  gl.drawElements(gl.LINES, indices.length, gl.UNSIGNED_BYTE,0);  
}

function drawCube(gl, modelMatrix) {
  var u_modelMatrix = gl.getUniformLocation(gl.program, 'u_modelMatrix');
  gl.uniformMatrix4fv(u_modelMatrix, false, modelMatrix.elements);

  var vertices = new Float32Array([
    -1,-1,-1, 1,-1,-1, 1, 1,-1, -1, 1,-1,
    -1,-1, 1, 1,-1, 1, 1, 1, 1, -1, 1, 1,
    -1,-1,-1, -1, 1,-1, -1, 1, 1, -1,-1, 1,
    1,-1,-1, 1, 1,-1, 1, 1, 1, 1,-1, 1,
    -1,-1,-1, -1,-1, 1, 1,-1, 1, 1,-1,-1,
    -1, 1,-1, -1, 1, 1, 1, 1, 1, 1, 1,-1, 
  ]);

  var colors = new Float32Array([   // Colors
    0.2, 0.58, 0.82,   0.2, 0.58, 0.82,   0.2,  0.58, 0.82,  0.2,  0.58, 0.82, // v0-v1-v2-v3 front
    0.5,  0.41, 0.69,  0.5, 0.41, 0.69,   0.5, 0.41, 0.69,   0.5, 0.41, 0.69,  // v0-v3-v4-v5 right
    0.0,  0.32, 0.61,  0.0, 0.32, 0.61,   0.0, 0.32, 0.61,   0.0, 0.32, 0.61,  // v0-v5-v6-v1 up
    0.78, 0.69, 0.84,  0.78, 0.69, 0.84,  0.78, 0.69, 0.84,  0.78, 0.69, 0.84, // v1-v6-v7-v2 left
    0.32, 0.18, 0.56,  0.32, 0.18, 0.56,  0.32, 0.18, 0.56,  0.32, 0.18, 0.56, // v7-v4-v3-v2 down
    0.73, 0.82, 0.93,  0.73, 0.82, 0.93,  0.73, 0.82, 0.93,  0.73, 0.82, 0.93, // v4-v7-v6-v5 back
   ]);

  var indices = new Uint8Array([
    0,1,2, 0,2,3, 4,5,6, 4,6,7,
    8,9,10, 8,10,11, 12,13,14, 12,14,15,
    16,17,18, 16,18,19, 20,21,22, 20,22,23 
  ]);

  // Create and store data into index buffer
  var index_buffer = gl.createBuffer();
  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, index_buffer);
  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);

  // Create a buffer object for
  initArrayBuffer(gl, vertices, 3, gl.FLOAT, 'a_Position');  
  initArrayBuffer(gl, colors, 3, gl.FLOAT, 'a_Color'); 

  gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_BYTE, 0);
}

function drawLine(gl, modelMatrix) {
  var u_modelMatrix = gl.getUniformLocation(gl.program, 'u_modelMatrix');
  gl.uniformMatrix4fv(u_modelMatrix, false, modelMatrix.elements);

  var vertices = new Float32Array([   // Vertex coordinates   
    0, 0, 0,   
    0, 10, 0, 
    0, -10, 0, 
  ]); 
  
  var colors = new Float32Array([     // Colors 
    0, 0, 1,   
  ]);
  
  var indices = new Uint8Array([       // Indices of the vertices
    0,1, 0,2   
  ]);
  
  // Create a buffer object for index
  var indexBuffer = gl.createBuffer();
  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);

  // Create a buffer object for
  initArrayBuffer(gl, vertices, 3, gl.FLOAT, 'a_Position');  
  initArrayBuffer(gl, colors, 3, gl.FLOAT, 'a_Color');   
  
  gl.drawElements(gl.LINES, indices.length, gl.UNSIGNED_BYTE,0);  
}

function drawTriangle(gl, modelMatrix) {
  var u_modelMatrix = gl.getUniformLocation(gl.program, 'u_modelMatrix');
  gl.uniformMatrix4fv(u_modelMatrix, false, modelMatrix.elements);

  var vertices = new Float32Array([
    0,0,0,
    0,1,0,
    1,0,0, 
 ]);
 
 var indices = new Uint8Array([0,1,2]);

 var index_buffer = gl.createBuffer();
  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, index_buffer);
  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);

  // Create a buffer object for
  initArrayBuffer(gl, vertices, 3, gl.FLOAT, 'a_Position');  

  gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_BYTE, 0);
}
  
function initArrayBuffer(gl, data, num, type, attribute) {
    var buffer = gl.createBuffer();   // Create a buffer object    
    // Write date into the buffer object
    gl.bindBuffer(gl.ARRAY_BUFFER, buffer);
    gl.bufferData(gl.ARRAY_BUFFER, data, gl.STATIC_DRAW);
    // Assign the buffer object to the attribute variable
    var a_attribute = gl.getAttribLocation(gl.program, attribute);
    gl.vertexAttribPointer(a_attribute, num, type, false, 0, 0);
    // Enable the assignment of the buffer object to the attribute variable
    gl.enableVertexAttribArray(a_attribute);
    return true;
}