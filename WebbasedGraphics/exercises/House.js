var cv = document.getElementById('cv');
var ig = new Image();
ig.src = 'http://www.mygeo.info/wallpaper/land_ocean_ice_1024.jpg';
var ctx = cv.getContext('2d');

// draw the part of img defined by the rect (startX, startY, endX, endY) inside 
//   the circle of center (cx,cy) between radius (innerRadius -> outerRadius) 
// - no check performed -
function drawRectInCircle(img, cx, cy, innerRadius, outerRadius, startX, startY, endX, endY, rotation) {
    var angle = 0;

    var step = 1 * Math.atan2(1, outerRadius);
    var limit = 2 * Math.PI;

    ctx.save();
    ctx.translate(cx, cy);
    while (angle < limit) {
        ctx.save();
        ctx.rotate(angle);
        ctx.translate(innerRadius, 0);
        ctx.rotate(rotation);
        var ratio = angle / limit;
        var x = startX + ratio * (endX - startX);
        ctx.drawImage(img, x, startY, 1, (endY - startY), 0, 0, 1, (outerRadius - innerRadius));
        ctx.restore();
        angle += step;
    }
    ctx.restore();
}

var cx = 300,
    cy = 300;

var innerRadius = 0;
var outerRadius = 300;

var startX = 0,
    endX = 1361,
    startY = 0,
    endY = 681;
var rad = 0;
var tick = function() {
    rad += 1;
    drawRectInCircle(ig, cx, cy, innerRadius, outerRadius, startX, startY, endX, endY, rad);
    requestAnimationFrame(tick, ctx);
};
tick();
