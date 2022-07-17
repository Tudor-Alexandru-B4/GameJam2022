using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    Transform t;

    private void Start()
    {
        t = GetComponent<Transform>();
        Instantiate(DiceDataBase.Instance.currentGun.getPrefab(), t.position, t.rotation);
    }
}
