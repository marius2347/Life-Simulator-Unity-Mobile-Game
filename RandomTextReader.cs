using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RandomTextReader : MonoBehaviour
{
    public TextAsset textAsset;
    // Start is called before the first frame update
    void Start()
    {
        if (textAsset != null)
        {
            string[] lines = textAsset.text.Split('\n');
            if (lines.Length > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, lines.Length);

                string randomLine = lines[randomIndex];


                if(!PlayerPrefs.HasKey("conceivedReason")) {
                    PlayerPrefs.SetString("conceivedReason", randomLine);
                }


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
