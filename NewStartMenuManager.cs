using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using System.Numerics;
using UnityEngine.UI;
public class NewStartMenuManager : MonoBehaviour
{
    public TextMeshProUGUI StartSubGameText;
    public TextMeshProUGUI NameSubText;
    public TextMeshProUGUI GenderSubText;
    public TextMeshProUGUI CountySubText;
    public TextMeshProUGUI CitySubText;
    public TextMeshProUGUI TalentSubText;
    public UnityEngine.UI.Image GenderIc;
    public UnityEngine.UI.Image CountyIc;
    public UnityEngine.UI.Image TalentIc;
    public UnityEngine.UI.Image AttributesIc;
    public Sprite femaleIcon;
    public Sprite maleIcon;
    public Sprite RomaniaIcon;
    public Sprite ActingIcon;
    public Sprite CrimeIcon;
    public Sprite MusicIcon;
    public Sprite NoneIcon;
    public Sprite SportIcon;
    public Sprite AttributesIcon;

    public TextMeshProUGUI ResidenceChildText;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SetBrotherOrSisterOrNone()
    {
        PlayerPrefs.SetInt("Sister", UnityEngine.Random.Range(0, 2));
        PlayerPrefs.SetInt("Brother", UnityEngine.Random.Range(0, 2));
    }
    private void Start()
    {
        if (PlayerPrefs.GetString("CityName") == "Niciunul")
        {
            ResidenceChildText.text = PlayerPrefs.GetString("County");
        }
        else
        {
            ResidenceChildText.text = PlayerPrefs.GetString("CityName") + ", " + PlayerPrefs.GetString("County");
        }
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("FirstName")))
        {

            if (PlayerPrefs.GetString("boolEnterM") == "True")
            {
                
                StartSubGameText.text = $"ca {PlayerPrefs.GetString("RandomFirstBoyName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("RandomFirstBoyName")} {PlayerPrefs.GetString("RandomLastBoyName")}";
            }
            else if (PlayerPrefs.GetString("boolEnterF") == "True")
            {
                
                StartSubGameText.text = $"ca {PlayerPrefs.GetString("RandomFirstGirlName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("RandomFirstGirlName")} {PlayerPrefs.GetString("RandomLastGirlName")}";
            }
            else
            {
                
                StartSubGameText.text = $"ca {PlayerPrefs.GetString("RandomFirstBoyName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("RandomFirstBoyName")} {PlayerPrefs.GetString("RandomLastBoyName")}";
            }
        }
        else
        {

            if (PlayerPrefs.GetString("boolEnterM") == "True")
            {
                Debug.Log("boolenterm");
                StartSubGameText.text = $"ca {PlayerPrefs.GetString("RandomFirstBoyName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("RandomFirstBoyName")} {PlayerPrefs.GetString("RandomLastBoyName")}";
            }
            else if (PlayerPrefs.GetString("boolEnterF") == "True")
            {
                Debug.Log("boolenterf");
                StartSubGameText.text = $"ca {PlayerPrefs.GetString("RandomFirstGirlName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("RandomFirstGirlName")} {PlayerPrefs.GetString("RandomLastGirlName")}";
            }
            else
            {
                Debug.Log("no");
                StartSubGameText.text = $"ca {PlayerPrefs.GetString("FirstName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("FirstName") + " " + PlayerPrefs.GetString("LastName")}";
            }

        }

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("Gender")))
        {
            GenderSubText.text = "Masculin";
            PlayerPrefs.SetString("Gender", "Masculin");
        }
        else
        {
            GenderSubText.text = $"{PlayerPrefs.GetString("Gender")}";
        }

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("County")))
        {
            CountySubText.text = "Alba";
            PlayerPrefs.SetString("County", "Alba");
        }
        else
        {
            CountySubText.text = $"{PlayerPrefs.GetString("County")}";
        }

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("CityName")))
        {
            CitySubText.text = "Niciunul";
            PlayerPrefs.SetString("CityName", "Niciunul");
        }
        else
        {
            CitySubText.text = $"{PlayerPrefs.GetString("CityName")}";
        }

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("Talent")))
        {
            TalentSubText.text = "Niciunul";
        }
        else
        {
            TalentSubText.text = $"{PlayerPrefs.GetString("Talent")}";
        }
        if (PlayerPrefs.GetString("Gender") == "Feminin")
        {
            GenderIc.sprite = femaleIcon;
        }
        else
        {
            GenderIc.sprite = maleIcon;
        }
        
        if (PlayerPrefs.GetString("Talent") == "Actor")
        {
            TalentIc.sprite = ActingIcon;
        }
        else if (PlayerPrefs.GetString("Talent") == "Muzica")
        {
            TalentIc.sprite = MusicIcon;
        }
        else if (PlayerPrefs.GetString("Talent") == "Sport")
        {
            TalentIc.sprite = SportIcon;
        }
        else if (PlayerPrefs.GetString("Talent") == "Niciunul")
        {
            TalentIc.sprite = NoneIcon;
        }
        else if (PlayerPrefs.GetString("Talent") == "Crima")
        {
            TalentIc.sprite = CrimeIcon;
        }
        else
        {
            TalentIc.sprite = NoneIcon;
        }
        AttributesIc.sprite = AttributesIcon;
    }
    public void SavePreferences()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("FirstName")))
        {

            if (PlayerPrefs.GetString("boolEnterM") == "True")
            {
                
                StartSubGameText.text = $"ca {PlayerPrefs.GetString("RandomFirstBoyName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("RandomFirstBoyName")} {PlayerPrefs.GetString("RandomLastBoyName")}";
            }
            else if (PlayerPrefs.GetString("boolEnterF") == "True")
            {
                
                StartSubGameText.text = $"ca {PlayerPrefs.GetString("RandomFirstGirlName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("RandomFirstGirlName")} {PlayerPrefs.GetString("RandomLastGirlName")}";
            }
            else
            {
                
                StartSubGameText.text = $"ca {PlayerPrefs.GetString("RandomFirstBoyName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("RandomFirstBoyName")} {PlayerPrefs.GetString("RandomLastBoyName")}";
            }
        }
        else
        {

            if (PlayerPrefs.GetString("boolEnterM") == "True")
            {

                StartSubGameText.text = $"ca {PlayerPrefs.GetString("RandomFirstBoyName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("RandomFirstBoyName")} {PlayerPrefs.GetString("RandomLastBoyName")}";
            }
            else if (PlayerPrefs.GetString("boolEnterF") == "True")
            {
                StartSubGameText.text = $"ca {PlayerPrefs.GetString("RandomFirstGirlName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("RandomFirstGirlName")} {PlayerPrefs.GetString("RandomLastGirlName")}";
            }
            else
            {

                StartSubGameText.text = $"ca {PlayerPrefs.GetString("FirstName")}";
                NameSubText.text = $"{PlayerPrefs.GetString("FirstName") + " " + PlayerPrefs.GetString("LastName")}";
            }

        }
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("Gender")))
        {
            GenderSubText.text = "Masculin";
            PlayerPrefs.SetString("Gender", "Masculin");
        }
        else
        {
            GenderSubText.text = $"{PlayerPrefs.GetString("Gender")}";
        }

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("County")))
        {
            CountySubText.text = "Alba";
        }
        else
        {
            CountySubText.text = $"{PlayerPrefs.GetString("County")}";
        }

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("CityName")))
        {
            CitySubText.text = "Niciunul";
        }
        else
        {
            CitySubText.text = $"{PlayerPrefs.GetString("CityName")}";
        }

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("Talent")))
        {
            TalentSubText.text = "Niciunul";
        }
        else
        {
            TalentSubText.text = $"{PlayerPrefs.GetString("Talent")}";
        }
        if (PlayerPrefs.GetString("Gender") == "Feminin")
        {
            GenderIc.sprite = femaleIcon;
        }
        else
        {
            GenderIc.sprite = maleIcon;
        }
        
        if (PlayerPrefs.GetString("Talent") == "Actor")
        {
            TalentIc.sprite = ActingIcon;
        }
        else if (PlayerPrefs.GetString("Talent") == "Muzica")
        {
            TalentIc.sprite = MusicIcon;
        }
        else if (PlayerPrefs.GetString("Talent") == "Sport")
        {
            TalentIc.sprite = SportIcon;
        }
        else if (PlayerPrefs.GetString("Talent") == "Niciunul")
        {
            TalentIc.sprite = NoneIcon;
        }
        else if (PlayerPrefs.GetString("Talent") == "Crima")
        {
            TalentIc.sprite = CrimeIcon;
        }
        else
        {
            TalentIc.sprite = NoneIcon;
        }
        AttributesIc.sprite = AttributesIcon;
    }

    public void onClickStart()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("CityName")))
        {
            PlayerPrefs.SetString("CityName", "Niciunul");
        }
    }
}
