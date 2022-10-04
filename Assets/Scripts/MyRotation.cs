using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRotation : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 0.5f)] float _angularSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = Vector3.zero;
        rotation.y= _angularSpeed;

        transform.Rotate(rotation);
    }
}
