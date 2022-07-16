using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointRotation : MonoBehaviour
{

    public CharacterController2D character;
    bool gunFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (character.facingRight && !gunFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            gunFacingRight = true;
        }
        if(!character.facingRight && gunFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            gunFacingRight = false;
        }
    }
}
