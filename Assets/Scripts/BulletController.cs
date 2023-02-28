using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 10f;
    public Vector2 initialDirection; // Lưu hướng ban đầu của viên đạn
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject explosionPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialDirection = transform.up; // Lưu hướng ban đầu của viên đạn
        rb.AddForce(initialDirection * speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        // kiểm tra xem đạn có ra khỏi màn hình hay không
        if (!GetComponent<Renderer>().isVisible)
        {
            // nếu đạn ra khỏi màn hình, thì hủy đối tượng đạn
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
