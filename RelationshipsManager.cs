using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RelationshipsManager : MonoBehaviour
{
    public TextMeshProUGUI RelationShipsTextButtons;

    void Start()
    {
        

        // Assuming you have the images stored in Resources folder
        string motherImage = "<sprite name=woman>";
        string fatherImage = "<sprite name=man>";
        string brotherImage = "<sprite name=boy>";
        string sisterImage = "<sprite name=girl>";

        string motherText = $"<b><size=15px><color=#4d8ef7><link=\"scene1\">{motherImage}{PlayerPrefs.GetString("MotherFNText")} {PlayerPrefs.GetString("LastName")} (Mama) >" + "</link></b>\n";
        string fatherText = $"<b><size=15px><color=#4d8ef7><link=\"scene1\">{fatherImage}{PlayerPrefs.GetString("FatherFNText")} {PlayerPrefs.GetString("LastName")} (Tata) >" + "</link></b>\n";
        string space = "<color=#192734>" + "──────────────────────────────────────────────\n\n";
        string relationMother = $"<b><indent=12%><size=10px><color=#4d8ef7><link=\"scene1\">Relatie: {PlayerPrefs.GetInt("motherRelationStatus")}%</link></indent></b>\n\n";
        string relationFather = $"<b><indent=12%><size=10px><color=#4d8ef7><link=\"scene1\">Relatie: {PlayerPrefs.GetInt("fatherRelationStatus")}%</link></indent></b>\n\n\n";
        string siblingsPanel = "";
        string brotherText = "";
        string sisterText = "";
        string spaceSiblings = "";
        string relationBrother = "";
        string relationSister = "";
        if (PlayerPrefs.HasKey("RandomBrotherFNText") && PlayerPrefs.HasKey("RandomSisterFNText"))
        {
            siblingsPanel = "<b><align=center><size=10px><color=white><mark=#19273450 padding=\"2000,2000,40,40\">Frati</mark></b></align>\n\n\n";
            brotherText = $"<b><size=15px><color=#4d8ef7><link=\"scene1\">{brotherImage}{PlayerPrefs.GetString("RandomBrotherFNText")} {PlayerPrefs.GetString("LastName")} (Frate) >" + "</link></b>\n";
            relationBrother = $"<b><indent=12%><size=10px><color=#4d8ef7><link=\"scene1\">Relatie: {PlayerPrefs.GetInt("brotherRelationStatus")}%</link></indent></b>\n\n";
            spaceSiblings = "<color=#192734>" + "──────────────────────────────────────────────\n\n";
            sisterText = $"<b><size=15px><color=#4d8ef7><link=\"scene1\">{sisterImage}{PlayerPrefs.GetString("RandomSisterFNText")} {PlayerPrefs.GetString("LastName")} (Sora) >" + "</link></b>\n";
            relationSister = $"<b><indent=12%><size=10px><color=#4d8ef7><link=\"scene1\">Relatie: {PlayerPrefs.GetInt("sisterRelationStatus")}%</link></indent></b>\n\n";
        }
        else
        {
            if (PlayerPrefs.HasKey("RandomBrotherFNText"))
            {
                siblingsPanel = "<b><align=center><size=10px><color=white><mark=#19273450 padding=\"2000,2000,40,40\">Frati</mark></b></align>\n\n\n";
                brotherText = $"<b><size=15px><color=#4d8ef7><link=\"scene1\">{brotherImage}{PlayerPrefs.GetString("RandomBrotherFNText")} {PlayerPrefs.GetString("LastName")} (Frate) >" + "</link></b>\n";
                relationBrother = $"<b><indent=12%><size=10px><color=#4d8ef7><link=\"scene1\">Relatie: {PlayerPrefs.GetInt("brotherRelationStatus")}%</link></indent></b>\n\n";
            }
            if (PlayerPrefs.HasKey("RandomSisterFNText"))
            {
                siblingsPanel = "<b><align=center><size=10px><color=white><mark=#19273450 padding=\"2000,2000,40,40\">Frati</mark></b></align>\n\n\n";
                sisterText = $"<b><size=15px><color=#4d8ef7><link=\"scene1\">{sisterImage}{PlayerPrefs.GetString("RandomSisterFNText")} {PlayerPrefs.GetString("LastName")} (Sora) >" + "</link></b>\n";
                relationSister = $"<b><indent=12%><size=10px><color=#4d8ef7><link=\"scene1\">Relatie: {PlayerPrefs.GetInt("SisterRelationStatus")}%</link></indent></b>\n\n";
            }
        }
        
        // Assign the final text to your RelationshipsTextButtons.text
        RelationShipsTextButtons.text = motherText + relationMother + space + fatherText + relationFather + siblingsPanel + sisterText + relationSister + spaceSiblings + brotherText + relationBrother;
        //RelationShipsTextButtons.fontSize = 20;

    }   

}

