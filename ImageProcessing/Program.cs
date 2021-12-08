using lib;
var matrix = new int[,]
{
    { 1, 3, 6, 3, 2 },
    { 4, 1, 5, 2, 4 },
    { 4, 3, 1, 3, 4 },
    { 4, 2, 4, 1, 7 },
    { 2, 3, 5, 3, 3 },
    // { 131, 137, 141 },
    // { 139, 133, 133 },
    // { 138, 132, 127 },
};
Console.WriteLine(matrix.GetCenterIndex() + "-" + matrix.GetCenterValue());