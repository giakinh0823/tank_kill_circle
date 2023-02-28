using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public int health;
    [SerializeField]
    private GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health = health - 1;
            transform.localScale = new Vector3(health, health, 1f);
            if (health <= 0)
            {
                Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
