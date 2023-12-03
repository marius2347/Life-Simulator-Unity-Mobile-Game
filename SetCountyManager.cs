using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
public class SetCountyManager : MonoBehaviour
{
    public string County;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCounty(Button button)
    {
        string buttonText = button.GetComponentInChildren<TextMeshProUGUI>().text;
        County = buttonText;
        PlayerPrefs.SetString("County", County);
        
    }
}
