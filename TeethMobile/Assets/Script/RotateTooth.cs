using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTooth : MonoBehaviour
{
    float speedRotation = 5.0f;
    Quaternion rotation;
    void Update()
    {
        if(Input.touchCount > 0){
            Touch parmak = Input.GetTouch(0);//Tek dokunuş
            if(parmak.phase == TouchPhase.Moved){
                rotation = Quaternion.Euler(parmak.deltaPosition.y / speedRotation, - parmak.deltaPosition.x / speedRotation, 0f);
                transform.rotation = rotation * transform.rotation;
            }
        }
    }
}
