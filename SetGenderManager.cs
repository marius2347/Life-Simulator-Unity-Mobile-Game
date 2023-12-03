using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetGenderManager : MonoBehaviour
{
    public string Gender;
    // Start is called before the first frame update
    
    
    // Update is called once per frame
    void Update()
    {

    }

    public void GetGender(Button button)
    {
        string buttonText = button.GetComponentInChildren<TextMeshProUGUI>().text;
        Gender = buttonText;
        PlayerPrefs.SetString("Gender", Gender);
    }

    public void setGenderToM()
    {
        PlayerPrefs.DeleteKey("FirstName");
        PlayerPrefs.DeleteKey("LastName");
        PlayerPrefs.SetString("boolEnterM", "True");
        PlayerPrefs.SetString("boolEnterF", "False");
    } 
    public void setGenderToF() {
        PlayerPrefs.DeleteKey("FirstName");
        PlayerPrefs.DeleteKey("LastName");
        PlayerPrefs.SetString("boolEnterF", "True");
        PlayerPrefs.SetString("boolEnterM", "False");
    }
}
