using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointTureta : MonoBehaviour
{
    public Transform turret;
    bool gunFacingRight = true;  

    // Update is called once per frame
    void Update()
    {
        if (turret.rotation.z < -90 && turret.rotation.z > -270 && !gunFacingRight)
        {
            transform.Rotate(0f, 0f, 90f);
            gunFacingRight = true;
        }
        if (turret.rotation.z < -270 && turret.rotation.z > -450 && gunFacingRight)
        {
            transform.Rotate(0f, 0f, 90f);
            gunFacingRight = false;
        }
    }
}
