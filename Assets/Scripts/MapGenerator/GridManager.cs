using UnityEngine;

namespace MapGenerator
{
    public class GridManager : MonoBehaviour
    {
        //tile prefab to render
        [SerializeField][Tooltip("This white sprite must be refenced and set to 32 pixels per unit")]
        private Sprite _sprite;
        // Rows and colums of the grid
        private int _colums, _rows;

        // Start is called before the first frame update
        void Start()
        {
            // Grid size picked from camera size and aspect.
            _rows   = (int) Camera.main.orthographicSize * 2 + 1;
            _colums = (int) (_rows * Camera.main.aspect) + 1;

            // New grid 
            for (int x = 0; x < _colums; x++)
                for (int y = 0; y < _rows; y++)
                { 
                    float greyRandomValue = Random.Range(0.0f, 1.0f);
                    SpawnTile(new Vector2(x, y), greyRandomValue);
                }
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
        /// <para name="value">value: set the grey scale from 0 to 1.</para>
        /// </em></list>
        /// </summary>
        private void SpawnTile(Vector2 position, float value) 
        {
            position = GridWorldPosition(position);
            // Instantiate tile with name.
            GameObject tile = new GameObject("x: " + position.x + ", y: " + position.y);
            //and set position 
            tile.transform.position = position;

            // Adding render and color
            SpriteRenderer sRender = tile.AddComponent<SpriteRenderer>();
            sRender.sprite = _sprite;
            sRender.color = new Color(value,value,value, 1);
        }

    }
}