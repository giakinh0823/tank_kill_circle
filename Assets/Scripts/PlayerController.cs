using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletPoint;
    public float fireRate = 0.01f;
    private float nextFire = 0f;

    private void Update()
    {
        
        // Fire bullet
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        }

    }

}
