using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnCircle;
    [SerializeField]
    private Button buttonPlay;
    [SerializeField]
    private Button buttonLoadData;

    private void Start()
    {
        buttonPlay.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        spawnCircle.SetActive(true);
        buttonPlay.gameObject.SetActive(false);
        buttonLoadData.gameObject.SetActive(false);
        if (spawnCircle.activeSelf && LoadData.circles != null)
        {
            foreach(GameObject circle in LoadData.circles)
            {
                SpawnCircle.circles.Add(circle);
            }
        }
    }
}
    