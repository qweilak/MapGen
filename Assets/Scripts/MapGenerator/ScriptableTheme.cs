using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName ="New Theme",menuName ="Data/Theme")]
public class ScriptableTheme : ScriptableObject
{
    [Tooltip("Spawn percent fo this theme. This value goes between 0 and 1")]
    [Range(0.0f,1.0f)] public float spawnRate = 1.0f;
    [Space(5)]
    //All sprites needed for generate the map with this theme.
    public Sprite topLeft, top, topRight;
    public Sprite left, center, right;
    public Sprite bottomLeft, bottom, bottomRight;
}
