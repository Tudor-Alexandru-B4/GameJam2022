using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepAlive : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
