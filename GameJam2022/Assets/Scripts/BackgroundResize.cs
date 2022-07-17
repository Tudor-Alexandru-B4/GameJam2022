using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundResize : MonoBehaviour
{

    Transform tr;
    Transform cameraTr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        cameraTr = GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<Transform>();
        tr.localScale = cameraTr.localScale * 50;
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = new Vector3(cameraTr.position.x, cameraTr.position.y, 0);
    }
}
