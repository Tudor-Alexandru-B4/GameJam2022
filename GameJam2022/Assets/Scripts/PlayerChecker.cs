using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChecker : MonoBehaviour
{
    bool aliveEnemy = true;
    int counter = 0;

    private void Update()
    {
        counter++;
        if (counter > 500)
        {
            counter = 0;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");
            if (enemies == null || enemies.Length <= 0)
            {
                SceneManager.LoadScene(1);
                Destroy(gameObject);
            }
            else
            {
                enemies = null;
            }
        }
    }
}
