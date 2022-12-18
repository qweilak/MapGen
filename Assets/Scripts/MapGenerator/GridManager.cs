using UnityEngine;

namespace MapGenerator
{
    public class GridManager : MonoBehaviour
    {
        //tile prefab to render
        [SerializeField][Tooltip("Sprites must be refenced and the spritesheet must be set to 16 pixels per unit")]
        private Sprite[] _sprites;

        // Start is called before the first frame update
        void Start()
        {
            // Grid size picked from camera size and aspect.
            CreateGrid();
        }

        /// <summary>
        /// Generates a Grid with bounds to the screen limits.
        /// </summary>
        private void CreateGrid()
        {
            for (int x = 0; x < Utils.colums; x++)
                for (int y = 0; y < Utils.rows; y++)
                    SpawnTile(new Vector2(x, y));
        }

        /// <summary>
        /// GridWorldPosition returns a vector3 with the realworld position of a tile's grid.
        /// <list><em>
        /// <param name="position">position is the tile position given by a vector2.</param>
        /// </em></list>
        /// <returns name="position"><strong>Returns tile's world position with position 0 set 
        /// at botton left corner of the screen.</strong></returns>
        /// </summary>
        private Vector3 GridWorldPosition(Vector2 position) 
        {
            position.x  = position.x - Utils.colums / 2;
            position.y  = position.y + 0.5f - Utils.rows / 2;
            return position;
        }

        /// <summary>
        /// SpawnTile instantiates a new Tile.
        /// <list><em>
        /// <para name="position">position: sets position of the tile.</para>
        /// </em></list>
        /// </summary>
        private void SpawnTile(Vector2 position) 
        {
            // Instantiate tile with name.
            GameObject tile = new GameObject("x: " + position.x + ", y: " + position.y);

            // Adding render by index from corners and limits of the map. 
            SpriteRenderer sRender = tile.AddComponent<SpriteRenderer>();
            sRender.sprite         = _sprites[GetTileByPosition(position)];

            // Adding the half side of the screen offset.
            position = GridWorldPosition(position);
            tile.transform.position = position;
        }

        /// <summary>
        /// GetTileByPosition returns int as index of _sprites Array. Coded by the sides of the map limits.
        /// <list><em>
        /// <param name="pos">vector2 position: pass the tile's position in world map.</param>
        /// </em></list>
        /// <returns><strong>returns int between 0 and _sprites.Lenght relative to position in map.
        /// </strong></returns>
        /// </summary>
        private int GetTileByPosition(Vector2 pos) 
        {
            if (pos.x == 0 && pos.y == 0) return 6;                                  // bottom left
            else if (pos.x == Utils.colums - 1 && pos.y == Utils.rows - 1) return 2; // top right
            else if (pos.x == Utils.colums - 1 && pos.y == 0) return 8;              // top left
            else if (pos.x == 0 && pos.y == Utils.rows - 1) return 0;                // bottom right
            else if (pos.x == 0) return 3;                                           // left line
            else if (pos.x == Utils.colums - 1) return 5;                            // right line
            else if (pos.y == 0) return 7;                                           // bottom line
            else if (pos.y == Utils.rows - 1) return 1;                              // top line
            return 4;                                                                // center
        }

    }
}