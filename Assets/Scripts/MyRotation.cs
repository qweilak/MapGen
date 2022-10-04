using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRotation : MonoBehaviour
{
    //Variable de la velocidad de giro
    [SerializeField] [Range(0.1f, 0.5f)] float _angularSpeed;

    // Update is called once per frame
    void Update()
    {
        //Calculo rotacion
        Vector3 rotation = Vector3.zero;
        rotation.y= _angularSpeed;
        //Aplicar rotacion
        transform.Rotate(rotation);
    }
}
