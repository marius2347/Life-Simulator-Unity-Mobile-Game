using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetCityManager : MonoBehaviour
{
    public GameObject CityNameInput;
    public GameObject CityNameText;
    private InputField inputField;
    public string CityName;
    public static bool initDone = false;
    private string defaultValue;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("CityName")))
        {
            CityNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("CityName");
        }
        
    }
    public void StoreCityName()
    {
        CityName = CityNameInput.GetComponent<TMP_InputField>().text;
        PlayerPrefs.SetString("CityName", CityName);
    }
    

    
}
