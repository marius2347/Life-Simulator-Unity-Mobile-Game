using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RandomMotherFLNText : MonoBehaviour
{
    public TextAsset textAsset;
    void Start()
    {
        if (textAsset != null)
        {
            string[] lines = textAsset.text.Split('\n');
            if (lines.Length > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, lines.Length);

                string randomLine = lines[randomIndex];


                if (!PlayerPrefs.HasKey("MotherFLNText"))
                {
                    PlayerPrefs.SetString("MotherFLNText", randomLine);
                }
                Debug.Log(randomIndex);


            }
            else
            {
                Debug.LogError("The text file is empty.");
            }
        }
        else
        {
            Debug.LogError("Please assign a TextAsset containing your text file.");
        }
    }

    
}
