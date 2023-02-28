using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    [SerializeField]
    private Button buttonLoadData;
    [SerializeField]
    private Button buttonPlay;


    [SerializeField]
    private GameObject spawnCircle;
    [SerializeField]
    private GameObject circlePrefab;
    [SerializeField]
    public static List<GameObject> circles;

    void Start()
    {
        circles = new List<GameObject>();
        buttonLoadData.onClick.AddListener(OnButtonClick);
    }

    private void LoadDataFromFile()
    {
        string path = Application.dataPath + "/Store/data.txt";

        if (File.Exists(path))
        {
            // Đọc nội dung của file
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string[] strs = line.Split(',', 4);
                    float x = float.Parse(strs[0]);
                    float y = float.Parse(strs[1]);
                    float health = float.Parse(strs[2]);
                    Color color = Random.ColorHSV();
                    if (strs.Length > 2)
                    {
                        // Nếu có thông tin về màu sắc trong dữ liệu, sử dụng nó
                        string colorString = strs[3];
                        colorString = colorString.Replace("RGBA(", "").Replace(")", "");
                        string[] rgbaArray = colorString.Split(',');
                        float red = float.Parse(rgbaArray[0]);
                        float green = float.Parse(rgbaArray[1]);
                        float blue = float.Parse(rgbaArray[2]);
                        float alpha = float.Parse(rgbaArray[3]);
                        color = new Color(red, green, blue, alpha);
                    }
                    Spawn(x, y, health, color);
                    Debug.Log("Dòng trong file: " + line);
                }
            }
        }
        else
        {
            Debug.Log("Không tìm thấy file.");
        }

        buttonPlay.gameObject.SetActive(false);
        buttonLoadData.gameObject.SetActive(false);
        spawnCircle.gameObject.SetActive(true);
    }

    public void OnButtonClick()
    {
        LoadDataFromFile();
    }

    public void Spawn(float x, float y, float health, Color color)
    {
        GameObject circle = Instantiate(circlePrefab, new Vector3(x, y, 0f), Quaternion.identity);
        circle.GetComponent<CircleController>().health = int.Parse(health+"");
        circle.transform.localScale = new Vector3(health, health, 1f);
        circle.GetComponent<Renderer>().material.color = color;
        circles.Add(circle);
        if (spawnCircle.activeSelf)
        {
            SpawnCircle.circles.Add(circle);
        }
    }
}
