using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SetAttributesManager : MonoBehaviour
{
    public TextMeshProUGUI PercentageDisciplineTextSlider;
    public TextMeshProUGUI PercentageFertilityTextSlider;
    public TextMeshProUGUI PercentageHappinessTextSlider;
    public TextMeshProUGUI PercentageHealthTextSlider;
    public TextMeshProUGUI PercentageKarmaTextSlider;
    public TextMeshProUGUI PercentageLooksTextSlider;
    public TextMeshProUGUI PercentageSexualityTextSlider;
    public TextMeshProUGUI PercentageSmartsTextSlider;
    public TextMeshProUGUI PercentageWillpowerTextSlider;
    public Slider PercentageDisciplineSlider;
    public Slider PercentageFertilitySlider;
    public Slider PercentageHappinessSlider;
    public Slider PercentageHealthSlider;
    public Slider PercentageKarmaSlider;
    public Slider PercentageLooksSlider;
    public Slider PercentageSexualitySlider;
    public Slider PercentageSmartsSlider;
    public Slider PercentageWillpowerSlider;
    string sliderMessage = "100%";
    // Start is called before the first frame update
    void Start()
    {
        PercentageDisciplineTextSlider.text = sliderMessage;
        PercentageFertilityTextSlider.text = sliderMessage;
        PercentageHappinessTextSlider.text = sliderMessage;
        PercentageHealthTextSlider.text = sliderMessage;
        PercentageKarmaTextSlider.text = sliderMessage;
        PercentageLooksTextSlider.text = sliderMessage;
        PercentageSexualityTextSlider.text = "Heterosexual";
        PercentageSmartsTextSlider.text = sliderMessage;
        PercentageWillpowerTextSlider.text = sliderMessage;
        
        if (!PlayerPrefs.HasKey("Discipline")) {
            PlayerPrefs.SetFloat("Discipline", 100);
            PercentageDisciplineSlider.value = 100;
        }
        else {
            PercentageDisciplineSlider.value = PlayerPrefs.GetFloat("Discipline");
        }
        if (!PlayerPrefs.HasKey("Fertility")) {
            PlayerPrefs.SetFloat("Fertility", 100);
            PercentageFertilitySlider.value = 100;
        } else {
            PercentageFertilitySlider.value = PlayerPrefs.GetFloat("Fertility");
        }
        if (!PlayerPrefs.HasKey("Happiness")) {
            PlayerPrefs.SetFloat("Happiness", 100);
            PercentageHappinessSlider.value = 100;
        } else {
            PercentageHappinessSlider.value = PlayerPrefs.GetFloat("Happiness");
        }
        if (!PlayerPrefs.HasKey("Health")) {
            PlayerPrefs.SetFloat("Health", 100);
            PercentageHealthSlider.value = 100;
        } else {
            PercentageHealthSlider.value = PlayerPrefs.GetFloat("Health");
        }
        if (!PlayerPrefs.HasKey("Karma")) {
            PlayerPrefs.SetFloat("Karma", 100);
            PercentageKarmaSlider.value = 100;
        } else {
            PercentageKarmaSlider.value = PlayerPrefs.GetFloat("Karma");
        }
        if (!PlayerPrefs.HasKey("Looks")) {
            PlayerPrefs.SetFloat("Looks", 100);
            PercentageLooksSlider.value = 100;
        } else {
            PercentageLooksSlider.value = PlayerPrefs.GetFloat("Looks");
        }
        if (!PlayerPrefs.HasKey("SexualityAt")) {
            PlayerPrefs.SetFloat("SexualityAt", 10);
            PercentageSexualitySlider.value = 10;

        } else {
            PercentageSexualitySlider.value = PlayerPrefs.GetFloat("SexualityAt");
        }
        if (!PlayerPrefs.HasKey("Smarts")) {
            PlayerPrefs.SetFloat("Smarts", 100);
            PercentageSmartsSlider.value = 100;
        } else {
            PercentageSmartsSlider.value = PlayerPrefs.GetFloat("Smarts");
        }
        if (!PlayerPrefs.HasKey("Willpower")) {
            PlayerPrefs.SetFloat("Willpower", 100);
            PercentageWillpowerSlider.value = 100;
        } else {
            PercentageWillpowerSlider.value = PlayerPrefs.GetFloat("Willpower");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowDisciplineSliderValue()
    {
       
        sliderMessage = $"{PercentageDisciplineSlider.value}%";
        PercentageDisciplineTextSlider.text = sliderMessage;
    }
    public void ShowFertilitySliderValue()
    {
        sliderMessage = $"{PercentageFertilitySlider.value}%";
        PercentageFertilityTextSlider.text = sliderMessage;
    }

    public void ShowHappinessSliderValue()
    {
        sliderMessage = $"{PercentageHappinessSlider.value}%";
        PercentageHappinessTextSlider.text = sliderMessage;
    }

    public void ShowHealthSliderValue()
    {
        sliderMessage = $"{PercentageHealthSlider.value}%";
        PercentageHealthTextSlider.text = sliderMessage;
    }

    public void ShowKarmaSliderValue()
    {
        sliderMessage = $"{PercentageKarmaSlider.value}%";
        PercentageKarmaTextSlider.text = sliderMessage;
    }

    public void ShowLooksliderValue()
    {
        sliderMessage = $"{PercentageLooksSlider.value}%";
        PercentageLooksTextSlider.text = sliderMessage;
    }
    public void ShowSexualityliderValue()
    {
        if (PercentageSexualitySlider.value <= 50)
        {
            sliderMessage = "Heterosexual";
        }
        else if (PercentageSexualitySlider.value > 50 && PercentageSexualitySlider.value <= 70)
        {
            sliderMessage = "Bisexual";
        }
        else
        {
            sliderMessage = "Homosexual";
        }

        PercentageSexualityTextSlider.text = sliderMessage;
    }

    public void ShowSmartsliderValue()
    {
        sliderMessage = $"{PercentageSmartsSlider.value}%";
        PercentageSmartsTextSlider.text = sliderMessage;
    }
    public void ShowWillpowerliderValue()
    {
        sliderMessage = $"{PercentageWillpowerSlider.value}%";
        PercentageWillpowerTextSlider.text = sliderMessage;
    }

    public void StoreAttributes()
    {
        float Discipline = PercentageDisciplineSlider.value;
        float Fertility = PercentageFertilitySlider.value;
        float Happiness = PercentageHappinessSlider.value;
        float Health = PercentageHealthSlider.value;
        float Karma = PercentageKarmaSlider.value;
        float Looks = PercentageLooksSlider.value;
        float SexualityAt = PercentageSexualitySlider.value;
        float Smarts = PercentageSmartsSlider.value;
        float Willpower = PercentageWillpowerSlider.value;
        PlayerPrefs.SetFloat("Discipline", Discipline);
        PlayerPrefs.SetFloat("Fertility", Fertility);
        PlayerPrefs.SetFloat("Happiness", Happiness);
        PlayerPrefs.SetFloat("Health", Health);
        PlayerPrefs.SetFloat("Karma", Karma);
        PlayerPrefs.SetFloat("Looks", Looks);
        PlayerPrefs.SetFloat("SexualityAt", SexualityAt);
        PlayerPrefs.SetFloat("Smarts", Smarts);
        PlayerPrefs.SetFloat("Willpower", Willpower);
        PlayerPrefs.SetFloat("HappinessDefault", Happiness);
        PlayerPrefs.SetFloat("HealthDefault", Health);
        PlayerPrefs.SetFloat("SmartsDefault", Smarts);
        PlayerPrefs.SetFloat("LooksDefault", Looks);
    }
}
