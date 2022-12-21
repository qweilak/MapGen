using UnityEngine;

namespace MapGenerator 
{
    public static class Utils 
    {
        // Rows and colums of the grid picked from camera size and aspect.
        public static readonly int rows   = (int)Camera.main.orthographicSize * 2;
        public static readonly int colums = (int)(rows * Camera.main.aspect);

        /// <summary>
        /// GetTileByPosition returns int as index of _sprites Array. Coded by the sides of the map limits.
        /// <list><em>
        /// <param name="pos">vector2 position: pass the tile's position in world map.</param>
        /// </em></list>
        /// <returns><strong>returns int between 0 and _sprites.Lenght relative to position in map.
        /// </strong></returns>
        /// </summary>
        public static Sprite GetTileByPosition(ScriptableTheme theme, Vector2 pos)
        {
            if (pos.x == 0 && pos.y == 0) return theme.bottomLeft;
            else if (pos.x == Utils.colums - 1 && pos.y == Utils.rows - 1) return theme.topRight;
            else if (pos.x == Utils.colums - 1 && pos.y == 0) return theme.bottomRight;
            else if (pos.x == 0 && pos.y == Utils.rows - 1) return theme.topLeft;
            else if (pos.x == 0) return theme.left;
            else if (pos.x == Utils.colums - 1) return theme.right;
            else if (pos.y == 0) return theme.bottom;
            else if (pos.y == Utils.rows - 1) return theme.top;
            return theme.center;
        }
    }
}
