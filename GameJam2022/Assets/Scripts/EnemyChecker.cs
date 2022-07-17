using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{

    bool aliveEnemy = true;
    int counter = 0;

    private void Update()
    {
        counter++;
        if(counter > 500)
        {
            counter = 0;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies == null || enemies.Length <= 0)
            {
                GameObject.FindWithTag("Player").GetComponent<CharacterController2D>().chamberEnd();
                Destroy(gameObject);
            }
            else
            {
                enemies = null;
            }
        }
    }
}
