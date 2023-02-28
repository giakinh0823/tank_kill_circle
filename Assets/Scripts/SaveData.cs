using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    [SerializeField]
    private Button button;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }


    public void Save(List<GameObject> circles)
    {
        string path = Application.dataPath + "/Store/data.txt";
        File.WriteAllLines(path,
               circles.Select(item => item.transform.position.x + "," +
               item.transform.position.y + "," +
               item.GetComponent<CircleController>().health + "," +
               item.GetComponent<Renderer>().material.color.ToString()));

    }

    public void OnButtonClick()
    {
        Save(SpawnCircle.circles);
    }
}
