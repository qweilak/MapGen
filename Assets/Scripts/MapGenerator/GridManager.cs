using UnityEngine;

namespace MapGenerator
{
    public class GridManager : MonoBehaviour
    {
        //tile prefab to render
        [SerializeField][Tooltip("Sprites must be refenced and the spritesheet must be set to 16 pixels per unit")]
        private Sprite[] _sprites;
        // Rows and colums of the grid
        private int _colums, _rows;

        // Start is called before the first frame update
        void Start()
        {
            // Grid size picked from camera size and aspect.
            _rows   = (int) Camera.main.orthographicSize * 2 - 1;
            _colums = (int) (_rows * Camera.main.aspect) + 1;

            // New grid 
            for (int x = 0; x < _colums; x++)
                for (int y = 0; y < _rows; y++)
                    SpawnTile(new Vector2(x, y));
        }

        /// <summary>
        /// GridWorldPosition returns a vector3 with the realworld position of a tile's grid.
        /// <list><em>
        /// <param name="position">position is the grid position given by a vector2.</param>
        /// </em></list>
        /// <returns name="position"><strong>Returns tile's world position with position 0 set 
        /// at botton left corner of the screen.</strong></returns>
        /// </summary>
        private Vector3 GridWorldPosition(Vector2 position) 
        {
            //each tile will have a relative position to the screen's left bottom corner.
            position.x -= _colums / 2;
            position.y -= _rows / 2;
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
            int index = GetTyleType(position);

            position = GridWorldPosition(position);
            // Instantiate tile with name.
            GameObject tile = new GameObject("x: " + position.x + ", y: " + position.y);
            //and set position 
            tile.transform.position = position;

            // Adding render
            SpriteRenderer sRender = tile.AddComponent<SpriteRenderer>();
            sRender.sprite = _sprites[index];
        }

        /// <summary>
        /// GetTyleType returns int as index of _sprites Array. Coded by the sides of the ends.
        /// <list><em>
        /// <param name="pos">vector2 position: pass the tile's position in world map.</param>
        /// </em></list>
        /// <returns><strong>returns int between 0 and _sprites.Lenght.</strong></returns>
        /// </summary>
        private int GetTyleType(Vector2 pos) 
        {
            if (pos.x == 0 && pos.y == 0) return 6;                        // bottom left
            else if (pos.x == _colums - 1 && pos.y == _rows - 1) return 2; // top right
            else if (pos.x == _colums - 1 && pos.y == 0) return 8;         // top left
            else if (pos.x == 0 && pos.y == _rows - 1) return 0;           // bottom right
            else if (pos.x == 0) return 3;                                 // left line
            else if (pos.x == _colums - 1) return 5;                       // right line
            else if (pos.y == 0) return 7;                                 // bottom line
            else if (pos.y == _rows - 1) return 1;                         // top line
            return 4;                                                      // center
        }

    }
}