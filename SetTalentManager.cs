using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
public class SetTalentManager : MonoBehaviour
{
    public string Talent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetTalent(Button button)
    {
        string buttonText = button.GetComponentInChildren<TextMeshProUGUI>().text;
        Talent = buttonText;
        PlayerPrefs.SetString("Talent", Talent);

    }
}
