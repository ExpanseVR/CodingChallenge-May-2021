using System;

namespace SingularHealth.Cube
{
    public static class CubeDesigner
    {
        public static (int, int) GetCube(int totalSize)
        {
            int cube = (int)Math.Ceiling(Math.Pow(totalSize, (double)1 / 3)) -1;
            int remainder = totalSize - (int)Math.Pow(cube, 3);
            return (cube -1, remainder);
        }
    }
}