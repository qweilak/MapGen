using UnityEngine;

namespace MapGenerator
{
    public class GridManager : MonoBehaviour
    {
        //tile prefab to render
        [SerializeField]
        [Tooltip("This white sprite must be refenced and set to 32 pixels per unit")]
        private Sprite _sprite;
        // Rows and colums of the grid
        private int _colums, _rows;

        // Start is called before the first frame update
        void Start()
        {
            // Grid size picked from camera size and aspect.
            _rows   = (int) Camera.main.orthographicSize * 2 + 1;
            _colums = (int) (_rows * Camera.main.aspect);

            // New grid 
            for (int x = 0; x < _colums; x++)
                for (int y = 0; y < _rows; y++)
                { 
                    float greyRandomValue = Random.Range(0.0f, 1.0f);
                    SpawnTile(new Vector2(x, y), greyRandomValue);
                }
        }

        /// <summary>
        /// SpawnTile instantiates a new Tile related to the bottom left screen's corner.
        /// <para name="position">• vector3 position: sets position of the tile.</para>
        /// <para name="value">• float value: set the grey scale from 0 to 1.</para>
        /// </summary>

        private void SpawnTile(Vector2 position, float value) 
        {
            //Move each tile from screen's center to bottom left.
            position.x -= _colums/2;
            position.y -= _rows  / 2;
            
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