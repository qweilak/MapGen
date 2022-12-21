using UnityEngine;

namespace MapGenerator
{
    public class GridManager : MonoBehaviour
    {

        //tile prefab to render
        [SerializeField][Tooltip("Sprites must be refenced in each scriptable theme and the spritesheet must be set to 16 pixels per unit")]
        private ScriptableTheme[] _themes;
        [SerializeField][Tooltip("Forest, 0; Sand & Soil, 1")]
        private int _currentTheme;
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
            sRender.sprite         = Utils.GetTileByPosition(_themes[_currentTheme],position);

            // Adding the half side of the screen offset.
            position = GridWorldPosition(position);
            tile.transform.position = position;
        }
    }
}