using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName ="New Theme",menuName ="Data/Theme")]
public class ScriptableTheme : ScriptableObject
{
    //All sprites needed for generate the map with this theme.
    public Sprite topLeft, top, topRight;
    public Sprite left, center, right;
    public Sprite bottomLeft, bottom, bottomRight;
}
