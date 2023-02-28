using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float speed = 2f;
    float xDirection;
    int angel = 0;
    public GameObject bulletPrefab;

    void Update()
    {

        xDirection = Input.GetAxisRaw("Horizontal");
        if (xDirection == -1 && angel < 90)
        {
            angel += 1;
        }
        else if (xDirection == 1 && angel > -90)
        {
            angel -= 1;
        }

        Quaternion lookRotation = Quaternion.AngleAxis(angel, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
    }
}
