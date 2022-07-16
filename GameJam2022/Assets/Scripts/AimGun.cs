using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        //Vector3 mouse = Input.mousePosition;
        //Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        //Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        //float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, angle);
        //Debug.Log(angle);



        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
