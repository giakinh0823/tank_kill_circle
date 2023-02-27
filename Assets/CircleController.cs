using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private int health = 5;
    [SerializeField]
    private GameObject explosionPrefab;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.transform.localScale = new Vector3(health, health, 1f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            if (health <= 0)
            {
                Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spriteRenderer.transform.localScale = new Vector3(health, health, 1f);
        }
    }
}
