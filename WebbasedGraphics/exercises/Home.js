// tạo chương trình  vecter shader 
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

// chương trình Fragment shader 
var FSHADER_SOURCE =
  '#ifdef GL_ES\n' +
  'precision mediump float;\n' +
  '#endif\n' +
  'uniform sampler2D u_Sampler;\n' +
  'varying vec2 v_TexCoord;\n' +
  'void main() {\n' +
  '  gl_FragColor = texture2D(u_Sampler, v_TexCoord);\n' +
  '}\n';

// tạo hàm main 
function main() {
    var canvas = document.getElementById('webgl'); // lấy canvas để thực hiện thao tác vẽ 
    var gl = getWebGLContext(canvas);     // lấy hàm thực hiện thao tác vẽ 
    initShaders(gl, VSHADER_SOURCE, FSHADER_SOURCE);

    var mvpMatrix = new Matrix4(); // khởi tạo ma trận điểm nhìn 
    mvpMatrix.setPerspective(50, 1, 1, 100);  // phép phối cảnh tỉ lệ 50 
    mvpMatrix.lookAt(-9, 0, 10, 0, 0, 0, 0, 1, 0); // đặt điểm nhìn 
    var u_MvpMatrix = gl.getUniformLocation(gl.program, 'u_MvpMatrix');  // lấy vị trí ma trận điểm nhìn
    gl.uniformMatrix4fv(u_MvpMatrix, false, mvpMatrix.elements);
   
    var modelMatrix = new Matrix4(); // khởi tạo phép chiếu đối tượng
    modelMatrix.setIdentity();
    var u_ModelMatrix = gl.getUniformLocation(gl.program, 'u_ModelMatrix'); // lấy vị trí của ma trận đối tượng 
    gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);

    gl.enable(gl.DEPTH_TEST); // bật điểm nhìn có độ sâu 
    gl.clearColor(0.1, 0.1, 0.1, 1.0); 
    gl.viewport(0, 0, canvas.width, canvas.height);  

    texture = gl.createTexture(); // khởi tạo texture để dán ảnh 
    u_Sampler = gl.getUniformLocation(gl.program, 'u_Sampler'); // lấy vị trí texture 

    var angle = 0,  z = -20; // khai báo góc quay 
    var currentAngle = [0.0, 0.0];  // góc quay chuột cho ngôi nhà 
    initEventHandlers(canvas, currentAngle);
    // tạo hàm thực thi theo thời gian thực cho đối tượng 

    var tick = function() {
      gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);     

      // vẽ mặt trời 
      modelMatrix.setIdentity();
      modelMatrix.rotate(30, 0, 1, 0);
      modelMatrix.setTranslate(3, 5, 3);
      modelMatrix.rotate(angle, 0, 0, 1); 
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawSphere(gl); 

      // vẽ mái nhà 
      modelMatrix.setIdentity();
      modelMatrix.rotate(currentAngle[1], 0, 1, 0); 
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawRoof(gl, 0);
      
      // vẽ thân nhà
      modelMatrix.setIdentity();
      modelMatrix.rotate(currentAngle[1], 0, 1, 0); 
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 1); 

      // vẽ cửa sổ
      modelMatrix.setIdentity();
      modelMatrix.rotate(currentAngle[1], 0, 1, 0); 
      modelMatrix.translate(-1, 0, 0);
      modelMatrix.scale(0.1, 1, 0.5);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 3); 

      modelMatrix.setIdentity();
      modelMatrix.rotate(currentAngle[1], 0, 1, 0); 
      modelMatrix.translate(-1, 0, 0);
      modelMatrix.scale(0.1, 1, 0.5);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 3); 

      // vẽ nền đất
      modelMatrix.setIdentity();
      modelMatrix.setTranslate(0, -2, -20);
      modelMatrix.scale(60, 0.5, 60);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 3); 
      
      // vẽ 4 đám mây 
      modelMatrix.setIdentity();
      modelMatrix.setTranslate(0, 5, z);
      modelMatrix.scale(1, 0.1, 1);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 2);

      modelMatrix.setIdentity();
      modelMatrix.setTranslate(0, 10, z - 10);
      modelMatrix.scale(1, 0.1, 1);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 2);

      modelMatrix.setIdentity();
      modelMatrix.setTranslate(5, 5, z + 10);
      modelMatrix.scale(1, 0.1, 1);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 2);

      modelMatrix.setIdentity();
      modelMatrix.setTranslate(5, 5, z);
      modelMatrix.scale(1, 0.1, 1);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 2);

      // vẽ thân cây
      modelMatrix.setIdentity();
      modelMatrix.setTranslate(8, 0, 0);
      modelMatrix.scale(0.2, 2, 0.2);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 1);

      // vẽ tán cây
      modelMatrix.setIdentity();
      modelMatrix.setTranslate(8, 2, 0);
      modelMatrix.scale(1, 1, 1);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 3);

      // vẽ thân cây
      modelMatrix.setIdentity();
      modelMatrix.setTranslate(-5, 0, 0);
      modelMatrix.scale(0.2, 2, 0.2);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 1);

      // vẽ tán cây
      modelMatrix.setIdentity();
      modelMatrix.setTranslate(-5, 2, 0);
      modelMatrix.scale(1, 1, 1);
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 3);

      // vẽ phông trời 
      modelMatrix.setIdentity();
      modelMatrix.setTranslate(40, 10, -30);
      modelMatrix.scale(80, 80, 1);
      modelMatrix.rotate(angle, 0, 0, 1); 
      gl.uniformMatrix4fv(u_ModelMatrix, false, modelMatrix.elements);
      drawCube(gl, 2); 
      
      if (z < 20) {
        z += 0.1; // tốc độ di chuyển mây 
      } else {
        z = -20; // vị trí xuất hiện ban đầu của mây 
      }
      
      angle++;
      requestAnimationFrame(tick, canvas);
    };
    tick();
}
// vẽ hình lập phương 
function drawCube(gl, index) {
  loadTexture(gl, index);

  var vertices = new Float32Array([
    1.0, 1.0, 1.0,  -1.0, 1.0, 1.0,  -1.0,-1.0, 1.0,   1.0,-1.0, 1.0,    // tọa độ mặt trước 
    1.0,-1.0,-1.0,  -1.0,-1.0,-1.0,  -1.0, 1.0,-1.0,   1.0, 1.0,-1.0,    // tọa độ mặt sau 
    1.0, 1.0, 1.0,   1.0, 1.0,-1.0,  -1.0, 1.0,-1.0,  -1.0, 1.0, 1.0,    // tọa độ mặt trên 
    -1.0,-1.0,-1.0,   1.0,-1.0,-1.0,   1.0,-1.0, 1.0,  -1.0,-1.0, 1.0,    // tọa độ mặt dưới
    1.0, 1.0, 1.0,   1.0,-1.0, 1.0,   1.0,-1.0,-1.0,   1.0, 1.0,-1.0,    // tọa độ mặt bên phải
    -1.0, 1.0, 1.0,  -1.0, 1.0,-1.0,  -1.0,-1.0,-1.0,  -1.0,-1.0, 1.0,    // tọa độ mặt trái
  ]);
  // khởi tạo thứ tự vẽ các đỉnh hình lập phương
  var indices = new Uint8Array([
      0, 1, 2, 0, 2, 3, // front
      4, 5, 6, 4, 6, 7, // back
      8, 9, 10, 8, 10, 11, // up
      12, 13, 14, 12, 14, 15, // down
      16, 17, 18, 16, 18, 19, // right
      20, 21, 22, 20, 22, 23 // left  
  ]);
  // tạo đỉnh cho ảnh dán 
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
// tạo buffer vẽ lần lượt các đỉnh 
  var indexBuffer = gl.createBuffer();
  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);
  gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_BYTE, 0);
}
// vẽ mái nhà
function drawRoof(gl, index) {
  loadTexture(gl, index);
  var vertices = new Float32Array([
    // vẽ tam giác    
		-1, 1, -1, 		//mặt sau mái nhà 	
		0, 2, -1,	
		0, 1, -1,	
		1, 1, -1,		
		0, 1, -1,	
		0, 2, -1,
	
		-1, 1, 1, 		//mặt trước mái nhà 
		0, 2, 1,		
		0, 1, 1,	
		1, 1, 1,		
		0, 1, 1,	
		0, 2, 1,
	
		-1, 1, -1,		//mặt trái mái nhà 
		-1, 1, 1,		
		0, 2,-1,
		-1, 1, 1,	
		0, 1.5, 1,
		0, 2, -1,
	
		1, 1, -1,		//mặt phải mái nhà 
		0, 2, -1,		
		1, 1, 1,	
		1, 1, 1,	
		0, 2, -1,
		0, 2, 1, 
  ]);
  // thứ tự vẽ các đỉnh 
  var indices = new Uint8Array([
      //mái 
		0,1,2,
		3,4,5,
		
		6,7,8,
		9,10,11,
		
		12,13,14,
		15,16,17,
		
		18,19,20,
		21,22,23,
  ]);
  // các đỉnh dán ảnh 
  var texCoords = new Float32Array([
    // mái nhà 
    1.0, 1.0,   0.0, 1.0,   0.0, 0.0,   1.0, 0.0,    // v0-v1-v2-v3 front
    0.0, 1.0,   0.0, 0.0,   1.0, 0.0,   1.0, 1.0,    // v0-v3-v4-v5 right
    1.0, 0.0,   1.0, 1.0,   0.0, 1.0,   0.0, 0.0,    // v0-v5-v6-v1 up
    1.0, 1.0,   0.0, 1.0,   0.0, 0.0,   1.0, 0.0,    // v1-v6-v7-v2 left
    0.0, 0.0,   1.0, 0.0,   1.0, 1.0,   0.0, 1.0,    // v7-v4-v3-v2 down
    0.0, 0.0,   1.0, 0.0,   1.0, 1.0,   0.0, 1.0,     // v4-v7-v6-v5 back
  ]);

  initArrayBuffer(gl, vertices, 3, gl.FLOAT, 'a_Position');   
  initArrayBuffer(gl, texCoords, 2, gl.FLOAT, 'a_TexCoord');

  var indexBuffer = gl.createBuffer();
  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, indices, gl.STATIC_DRAW);
  gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_BYTE, 0);
}
// vẽ hình cầu 
function drawSphere(gl) {
  loadTexture(gl, 1);
  
  var SPHERE_DIV = 100;

  var i, ai, si, ci;
  var j, aj, sj, cj;
  var p1, p2;

  var positions = [];
  var indices = [];

  // khởi tạo các tọa độ cho hình cầu 
  for (j = 0; j <= SPHERE_DIV; j++) {
    aj = j * Math.PI / SPHERE_DIV;
    sj = Math.sin(aj);
    cj = Math.cos(aj);
    for (i = 0; i <= SPHERE_DIV; i++) {
      ai = i * 2 * Math.PI / SPHERE_DIV;
      si = Math.sin(ai);
      ci = Math.cos(ai);

      positions.push(si * sj);  // X
      positions.push(cj);       // Y
      positions.push(ci * sj);  // Z
    }
  }

  // khởi tạo vị trí vẽ các đỉnh 
  for (j = 0; j < SPHERE_DIV; j++) {
    for (i = 0; i < SPHERE_DIV; i++) {
      p1 = j * (SPHERE_DIV+1) + i;
      p2 = p1 + (SPHERE_DIV+1);

      indices.push(p1);
      indices.push(p2);
      indices.push(p1 + 1);

      indices.push(p1 + 1);
      indices.push(p2);
      indices.push(p2 + 1);
    }
  }
  
  initArrayBuffer(gl, new Float32Array(positions), 3, gl.FLOAT, 'a_Position');
 

  // viết các vị trí đỉnh nằm trong buffer 
  var indexBuffer = gl.createBuffer();
  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, new Uint16Array(indices), gl.STATIC_DRAW);

	// xóa màu và buffer độ sâu 
	// gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);

	// vẽ hình cầu 
	gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_SHORT, 0);
}

var texture, u_Sampler; 
// khởi tạo 1 mảng chưa các hình ảnh được dán 
var textureImages = [ new Image(), new Image(), new Image(), new Image(), ];
textureImages[0].src = '../resources/wheel.png'; 
textureImages[1].src = '../resources/wall.jpg';
textureImages[2].src = '../resources/sky_cloud.jpg'; 
textureImages[3].src = '../resources/lawn.jpg';
// khởi tạo hàm load ảnh lên 
function loadTexture(gl, index) {
  gl.pixelStorei(gl.UNPACK_FLIP_Y_WEBGL, 1);
  gl.activeTexture(gl.TEXTURE0);
  gl.bindTexture(gl.TEXTURE_2D, texture); 
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
  gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, textureImages[index]);
  gl.uniform1i(u_Sampler, 0); 
  return true;
}
// bắt sự kiện chuột 
function initEventHandlers(canvas, currentAngle) {
  var dragging = false;
  var lastX = -1, lastY = -1;
// sự kiện nhấn chuột xuống 
  canvas.onmousedown = function(ev) {
      var x = ev.clientX, y = ev.clientY;
      var rect = ev.target.getBoundingClientRect();
      if (rect.left <= x && x < rect.right && rect.top <= y && y < rect.bottom) {
          lastX = x; lastY = y;
          dragging = true;
      }
  };
// sự kiện nhả chuột 
  canvas.onmouseup = function() { dragging = false; };
// di chuyển chuột 
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
// khởi tạo buffer để vẽ 
function initArrayBuffer(gl, data, num, type, attribute) {
  var buffer = gl.createBuffer();  
  gl.bindBuffer(gl.ARRAY_BUFFER, buffer);
  gl.bufferData(gl.ARRAY_BUFFER, data, gl.STATIC_DRAW);
  var a_attribute = gl.getAttribLocation(gl.program, attribute);
  gl.vertexAttribPointer(a_attribute, num, type, false, 0, 0);
  gl.enableVertexAttribArray(a_attribute);  
}

