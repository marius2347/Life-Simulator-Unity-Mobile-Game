using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResetFirstLastName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResetFirstLastNameGenerator(TextAsset textAsset)
    {
        if (textAsset != null)
        {
            string[] lines = textAsset.text.Split('\n');
            if (lines.Length > 0)
            {
                //int randomIndex = UnityEngine.Random.Range(0, lines.Length);

                //string randomLine = lines[randomIndex];

                //randomLine = randomLine.Replace("\r", "").Replace("\n", "");


                if (PlayerPrefs.GetString("Gender") == "Masculin")
                {
                    if (textAsset.name == "RandomFirstBoyName")
                    {
                        PlayerPrefs.SetString("RandomFirstBoyName", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));
                    }
                    if (textAsset.name == "RandomLastBoyName")
                    {
                        PlayerPrefs.SetString("RandomLastBoyName", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));
                    }
                        

                }
                if (PlayerPrefs.GetString("Gender") == "Feminin")
                {
                    if(textAsset.name == "RandomFirstGirlName")
                    {
                        PlayerPrefs.SetString("RandomFirstGirlName", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));
                    }
                    if (textAsset.name == "RandomLastGirlName")
                    {
                        PlayerPrefs.SetString("RandomLastGirlName", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));
                    }
                        

                }
                
                
                //Debug.Log(textAsset.name);


            }
            else
            {
                //Debug.LogError("The text file is empty.");
            }
        }
        else
        {
            //Debug.LogError("Please assign a TextAsset containing your text file.");
        }
    }
}
