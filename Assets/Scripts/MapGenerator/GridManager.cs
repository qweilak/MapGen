using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapGenerator
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField]
        private int _colums, _rows;
        // Start is called before the first frame update
        void Start()
        {
            //grid size picked from camera size and aspect.
            _rows   = (int) Camera.main.orthographicSize * 2 + 1;
            _colums = (int) (_rows * Camera.main.aspect);

            //new grid 
            for (int x = 0; x < _colums; x++)
                for (int y = 0; y < _rows; y++)
                { 
                    SpawnTile(new Vector2(x, y));
                    
                }

            //We need to move the camera to the center of the grid. z set as default
            Camera.main.transform.position = new Vector3(_colums /2 , _rows / 2, -10);
        }

        /// <summary>
        /// SpawnTile instantiates a new Quad at parameter's position.
        /// </summary>
        /// <param name="position"></param>
        private void SpawnTile(Vector2 position) 
        {
            //Based on Quads.
            GameObject quad         = GameObject.CreatePrimitive(PrimitiveType.Quad);
            quad.transform.position = position;
            quad.name = "x: " + position.x + ", y: " + position.y;
        }
    }
}