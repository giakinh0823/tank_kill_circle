using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject circlePrefab;
    [SerializeField]
    public List<GameObject> circles;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
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
                string[] strs = line.Split(',', 3);
                float x = float.Parse(strs[0]);
                float y = float.Parse(strs[1]);
                Color color = Random.ColorHSV();
                if (strs.Length > 2)
                {
                    // Nếu có thông tin về màu sắc trong dữ liệu, sử dụng nó
                    string colorString = strs[2];
                    colorString = colorString.Replace("RGBA(", "").Replace(")", "");
                    string[] rgbaArray = colorString.Split(',');
                    float red = float.Parse(rgbaArray[0]);
                    float green = float.Parse(rgbaArray[1]);
                    float blue = float.Parse(rgbaArray[2]);
                    float alpha = float.Parse(rgbaArray[3]);
                    color = new Color(red, green, blue, alpha);
                }
                Spawn(x, y, color);
                Debug.Log("Dòng trong file: " + line);
            }
        }
        else
        {
            Debug.Log("Không tìm thấy file.");
        }
    }

    public void OnButtonClick()
    {
        Debug.Log("Button clicked!");
        LoadDataFromFile();
    }

    public void Spawn(float x, float y, Color color)
    {
        GameObject circle = Instantiate(circlePrefab, new Vector3(x, y, 0f), Quaternion.identity);
        circle.GetComponent<Renderer>().material.color = color;
        circles.Add(circle);
        SpawnCircle.circles.Add(circle);
    }
}
