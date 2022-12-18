using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapGenerator 
{
    public static class Utils 
    {
        // Rows and colums of the grid picked from camera size and aspect.
        public static readonly int rows   = (int)Camera.main.orthographicSize * 2;
        public static readonly int colums = (int)(rows * Camera.main.aspect);
    }
}
