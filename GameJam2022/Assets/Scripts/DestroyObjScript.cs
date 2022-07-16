using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(0.15f);
        Destroy(gameObject);
    }

    
}
