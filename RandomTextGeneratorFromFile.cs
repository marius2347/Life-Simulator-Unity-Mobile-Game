using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class RandomTextGeneratorFromFile : MonoBehaviour
{
    
    public void randomGeneratorText(TextAsset textAsset)
    {
        if (textAsset != null)
        {
            string[] lines = textAsset.text.Split('\n');
            if (lines.Length > 0)
            {
                //int randomIndex = UnityEngine.Random.Range(0, lines.Length);

                //string randomLine = lines[randomIndex];

                //randomLine = randomLine.Replace("\r", "").Replace("\n", "");

                if (!PlayerPrefs.HasKey("MotherFNText") && textAsset.name == "RandomMotherFNText") {
                    PlayerPrefs.SetString("MotherFNText", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));
                    PlayerPrefs.SetInt("MotherAge", UnityEngine.Random.Range(18, 50));
                }
                if (!PlayerPrefs.HasKey("FatherFNText") && textAsset.name == "RandomFatherFNText") {

                    PlayerPrefs.SetString("FatherFNText", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));
                    PlayerPrefs.SetInt("FatherAge", UnityEngine.Random.Range(18, 70));
                }
                if (!PlayerPrefs.HasKey("JobsText") && textAsset.name == "RandomJobsText") {
                    PlayerPrefs.SetString("FatherJobsText", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));
                    PlayerPrefs.SetString("MotherJobsText", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));
                }
                if(!PlayerPrefs.HasKey("RandomFirstBoyName") && textAsset.name == "RandomFirstBoyName") {
                    PlayerPrefs.SetString("RandomFirstBoyName", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));

                }
                if (!PlayerPrefs.HasKey("RandomLastBoyName") && textAsset.name == "RandomLastBoyName")
                {
                    PlayerPrefs.SetString("RandomLastBoyName", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));

                }
                if (!PlayerPrefs.HasKey("RandomFirstGirlName") && textAsset.name == "RandomFirstGirlName")
                {
                    PlayerPrefs.SetString("RandomFirstGirlName", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));                    
                }
                if (!PlayerPrefs.HasKey("RandomLastGirlName") && textAsset.name == "RandomLastGirlName")
                {
                    PlayerPrefs.SetString("RandomLastGirlName", lines[UnityEngine.Random.Range(0, lines.Length)].Replace("\r", "").Replace("\n", ""));

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
