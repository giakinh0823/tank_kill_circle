using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    [SerializeField]
    public GameObject circlePrefab;

    public static List<GameObject> circles;

    protected float spawnTimer = 0f;
    protected float spawnDelay = 2f;

    int number = 0;

    void Start()
    {
        circles = new List<GameObject>();
    }


    void Update()
    {
        Spawn();
        checkDead();
    }

    private void Spawn()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer < spawnDelay) return;
        spawnTimer = 0;

        Vector3 target = RandomTarget(Camera.main);
        GameObject circle = Instantiate(this.circlePrefab) as GameObject;
        int health = Random.Range(1, 4);
        circle.GetComponent<CircleController>().health = health;
        circle.transform.localScale = new Vector3(health, health, 1f);
        circle.name = "circle #" + ++number;
        circle.transform.position = target;
        circle.GetComponent<Renderer>().material.color = Random.ColorHSV();
        circles.Add(circle);
    }

    void checkDead()
    {
        circles = circles.FindAll(circle => circle != null);
    }

    private Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(camera.transform.position, new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }

    private Vector3 RandomTarget(Camera camera)
    {
        Bounds bounds = OrthographicBounds(camera);
        return new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), -Camera.main.transform.position.z);
    }
}
