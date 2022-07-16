using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    public float fireRate = 0.35f;

    bool isPressed = false;
    bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isPressed = true;
        }

        if (isPressed & canShoot)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isPressed = false;
        }


    }

    IEnumerator Shoot()
    {
        canShoot = false;
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        yield return new WaitForSecondsRealtime(fireRate);
        canShoot = true;
    }
}


