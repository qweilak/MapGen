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
            _rows = (int) Camera.main.orthographicSize * 2 + 1;
            _colums = (int) (_rows * Camera.main.aspect);

            for (int x = 0; x < _colums; x++)
            {
                for (int y = 0; y < _rows; y++)
                    SpawnTile(new Vector2(x, y));
            }
        }

        private void SpawnTile(Vector2 position) 
        {
            GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
            
            position.x = position.x - _colums / 2;
            position.y = position.y - _rows / 2;

            quad.transform.position = position;
        }
    }
}