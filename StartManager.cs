using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject ContinueGame;
    public TextMeshProUGUI FirstNameLastNameSubText;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("GameExists") == "no")
        {
            ContinueGame.SetActive(false);
        } else
        {
            if(PlayerPrefs.HasKey("FirstName"))
            {
                FirstNameLastNameSubText.text = PlayerPrefs.GetString("FirstName") + " " + PlayerPrefs.GetString("LastName");
            } else
            {
                if (PlayerPrefs.GetString("Gender") == "Masculin")
                {
                    FirstNameLastNameSubText.text = PlayerPrefs.GetString("RandomFirstBoyName") + " " + PlayerPrefs.GetString("RandomLastBoyName");
                } else
                {
                    FirstNameLastNameSubText.text = PlayerPrefs.GetString("RandomFirstGirlName") + " " + PlayerPrefs.GetString("RandomLastGirlName");
                }
                

            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
