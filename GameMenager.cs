using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static GameMenager;
using UnityEngine.Analytics;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System.Globalization;

public class GameMenager : MonoBehaviour
{
    public delegate void SendUpdateUI();
    public static event SendUpdateUI OnSendUpdateUI;

    public delegate void SendSetupEvent();
    public static event SendSetupEvent OnSendSetupEvent;    
    int Food;
    int Money;
    int Age;
    int MaxHealth = 100;
    int MaxFood = 200;
    int MaxHappiness = 100;
    int MaxLooks = 100;
    int MaxSmarts = 100;
    float Health;
    float HappinessDefault;
    float HealthDefault;
    float SmartsDefault;
    float LooksDefault;

    public TextMeshProUGUI HappinessText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI SmartsText;
    public TextMeshProUGUI LooksText;
    public TextMeshProUGUI AgeText;
    public TextMeshProUGUI AgeTextDead;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI ResidenceTextDead;
    public TextMeshProUGUI MessageTextDead;
    public Slider HappinessSlider;
    public Slider HealthSlider;
    public Slider SmartsSlider;
    public Slider LooksSlider;

    public TextMeshProUGUI FirstLastNameText;
    public TextMeshProUGUI FirstLastNameTextDead;
    public static string FLN;
    public static string FLNTD;
    public GameObject MessagePanel;
    public TextMeshProUGUI MessageText;

    public GameObject DeathPanel;

    public Image iconImage;
    public Sprite BabyIcon;
    public Sprite BoyIcon;
    public Sprite GirlIcon;
    public Sprite ManIcon;
    public Sprite WomanIcon;
    public Sprite oldManIcon;
    public Sprite oldWomanIcon;
    public Sprite veryOldManIcon;
    public Sprite veryOldWomanIcon;

    public Image iconHappiness;
    public Image iconHealth;
    public Image iconSmarts;
    public Image iconLooks;

    public Image ChangeableIcon;

    public Sprite InfantIcon;
    public Sprite KindergartenIcon;
    public Sprite PrimaryschoolIcon;
    public Sprite SecondaryschoolIcon;
    public Sprite HighschoolIcon;
    public Sprite OccupationIcon;
    public Sprite UniversityIcon;
    public Sprite JobIcon;
    public Sprite RetireIcon;

    public TextMeshProUGUI ChangeableText;

    public Sprite iconHappy;
    public Sprite iconSad;
    public Sprite iconCry;

    public Sprite iconHealthy;
    public Sprite iconSick;
    public Sprite iconDie;

    public Sprite iconSmart;
    public Sprite iconThink;
    public Sprite iconDumb;

    public Sprite iconHot;
    public Sprite iconCool;
    public Sprite iconUgly;
    //public Transform PanelParent;
    public ScrollRect scrollRect;

    public TextMeshProUGUI FirstLastNameChildText;
    public TextMeshProUGUI GenderChildText;
    public TextMeshProUGUI AgeChildText;
    public TextMeshProUGUI ResidenceChildText;

    public TextMeshProUGUI HappinessChildText;
    public TextMeshProUGUI HealthChildText;
    public TextMeshProUGUI SmartsChildText;
    public TextMeshProUGUI LooksChildText;

    public Slider HappinessChildSlider;
    public Slider HealthChildSlider;
    public Slider SmartsChildSlider;
    public Slider LooksChildSlider;

    public Image iconChildHappiness;
    public Image iconChildHealth;
    public Image iconChildSmarts;
    public Image iconChildLooks;
    public Sprite iconChildHappy;
    public Sprite iconChildSad;
    public Sprite iconChildCry;

    public Sprite iconChildHealthy;
    public Sprite iconChildSick;
    public Sprite iconChildDie;

    public Sprite iconChildSmart;
    public Sprite iconChildThink;
    public Sprite iconChildDumb;

    public Sprite iconChildHot;
    public Sprite iconChildCool;
    public Sprite iconChildUgly;

    public Image ImageInfo;
    public TextMeshProUGUI InfoText;
    public Sprite iconChildInfo;

    public Image imageAssets;
    public Button buttonAssets;
    private ColorBlock defaultColors;

    private int motherRelation;
    private int fatherRelation;
    private int brotherRelation;
    private int sisterRelation;
    //public void AddToHealth(int value) {
    //Health += value;
    //if(Health > MaxHealth) 
    // Health = MaxHealth;
    //}
    public void AddToFood(int value) {
        Food += value;
        if(Food > MaxFood) 
            Food = MaxFood;
    }
    public bool BuyItem(int value) {
        if (Money + value < 0) {
            DisplayMessage("Nu ai destui bani!");
            return false;
        }
            
        Money += value;
        return true;
    }
    public void DisplayMessage(string value) {
        MessageText.text = value;
        MessagePanel.SetActive(true);
        Invoke(nameof(HideMessage), 1);
    }
    public void HideMessage()
    {
        MessagePanel.SetActive(false);
    }
    // Start is called before the first frame update
    //public static TextMeshProUGUI go { get; set; }
    void Start()
    {
        
        PlayerPrefs.SetString("GameExists", "yes");
        //go = GameObject.Instantiate(AgeText);
        //go.transform.position = transform.position;
        //go.transform.parent = PanelParent.transform;
        //go.transform.SetParent(PanelParent, false);
        //AgeText.transform.SetParent(PanelParent);
       
        DeathPanel.SetActive(false);
        if (PlayerPrefs.GetString("CityName") == "Niciunul")
        {
            ResidenceChildText.text = PlayerPrefs.GetString("County");
        }
        else
        {
            ResidenceChildText.text = PlayerPrefs.GetString("CityName") + ", " + PlayerPrefs.GetString("County");
        }
        if (PlayerPrefs.HasKey("TextNewAge"))
        {
            AgeText.text = PlayerPrefs.GetString("TextNewAge");
        }
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
        checkChangeableIcon();
        defaultColors = buttonAssets.colors;
        SetupGame();
        
    }
        public void UpdateUI() {
        
        if(OnSendUpdateUI != null)
            OnSendUpdateUI();
        HappinessText.text = $"{PlayerPrefs.GetFloat("Happiness")}%";
        HealthText.text = $"{PlayerPrefs.GetFloat("Health")}%";
        SmartsText.text = $"{PlayerPrefs.GetFloat("Smarts")}%";
        LooksText.text = $"{PlayerPrefs.GetFloat("Looks")}%";
        HappinessChildText.text = $"{PlayerPrefs.GetFloat("Happiness")}%";
        HealthChildText.text = $"{PlayerPrefs.GetFloat("Health")}%";
        SmartsChildText.text = $"{PlayerPrefs.GetFloat("Smarts")}%";
        LooksChildText.text = $"{PlayerPrefs.GetFloat("Looks")}%";

        MoneyText.text = $"{Money} lei";
        HappinessSlider.value = PlayerPrefs.GetFloat("Happiness");
        HealthSlider.value = PlayerPrefs.GetFloat("Health");
        SmartsSlider.value = PlayerPrefs.GetFloat("Smarts");
        LooksSlider.value = PlayerPrefs.GetFloat("Looks");
        HappinessChildSlider.value = PlayerPrefs.GetFloat("Happiness");
        HealthChildSlider.value = PlayerPrefs.GetFloat("Health");
        SmartsChildSlider.value = PlayerPrefs.GetFloat("Smarts");
        LooksChildSlider.value = PlayerPrefs.GetFloat("Looks");

        AgeChildText.text = PlayerPrefs.GetInt("Age") + " ani";

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("FirstName")))
        {
            if(PlayerPrefs.GetString("Gender") == "Masculin")
            {
                FirstLastNameText.text = PlayerPrefs.GetString("RandomFirstBoyName") + " " + PlayerPrefs.GetString("RandomLastBoyName");
                FLN = FirstLastNameText.text;
                FirstLastNameChildText.text = FLN;
                PlayerPrefs.SetString("Firstname", PlayerPrefs.GetString("RandomFirstBoyName"));
                PlayerPrefs.SetString("LastName", PlayerPrefs.GetString("RandomLastBoyName"));
            } else if(PlayerPrefs.GetString("Gender") == "Feminin")
            {
                FirstLastNameText.text = PlayerPrefs.GetString("RandomFirstGirlName") + " " + PlayerPrefs.GetString("RandomLastGirlName");
                FLN = FirstLastNameText.text;
                FirstLastNameChildText.text = FLN;
                PlayerPrefs.SetString("Firstname", PlayerPrefs.GetString("RandomFirstGirlName"));
                PlayerPrefs.SetString("LastName", PlayerPrefs.GetString("RandomLastGirlName"));
            }
           
            
        }
        else
        {
            FirstLastNameText.text = PlayerPrefs.GetString("FirstName") + " " + PlayerPrefs.GetString("LastName");
            FLN = FirstLastNameText.text;
            FirstLastNameChildText.text = FLN;
        }
            
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("County")))
            PlayerPrefs.SetString("County", "Alba");
        
        if (PlayerPrefs.GetInt("Age")== -1)
            CreateNewText();
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("Gender")))
        {
            PlayerPrefs.GetString("Gender", "Masculin");
            iconImage.sprite = BabyIcon;
        }

        AgeIcon();
        CheckForHungerAndDeath();
        checkInformationPanelIcons();
        changeAlphaToImage();

    }
    public void CheckForHungerAndDeath() {
        
        if (Food <= 0)
        {
            Health = PlayerPrefs.GetFloat("Health") - 1;
            PlayerPrefs.SetFloat("Health", Health);
        }
            
        else
            Food -= 10;
        if (PlayerPrefs.GetFloat("Health") < 0)
            YouDied();
    }


    public void YouDied() {
        DeathPanel.SetActive(true);
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("FirstName")))
        {
            FirstLastNameTextDead.text = FLN;
            FLNTD = FirstLastNameTextDead.text;
        }
        else
        {
            FirstLastNameTextDead.text = PlayerPrefs.GetString("FirstName") + " " + PlayerPrefs.GetString("LastName");
            FLNTD = FirstLastNameTextDead.text;
        }
        AgeTextDead.text = $"{PlayerPrefs.GetInt("Age")} ANI";
        if(PlayerPrefs.GetString("CityName") != "Niciunul") {
            ResidenceTextDead.text = $"Resedinta: {PlayerPrefs.GetString("CityName")}, {PlayerPrefs.GetString("County")}";
        } else {
            ResidenceTextDead.text = $"Resedinta: {PlayerPrefs.GetString("County")}";
        }
        MessageTextDead.text = $"{FLNTD} a murit la varsta de {PlayerPrefs.GetInt("Age")} ani.";
    }

    public void SetupGame()
    {
        DeathPanel.SetActive(false);
        FirstLastNameChildText.text = PlayerPrefs.GetString("FirstName") + " " + PlayerPrefs.GetString("LastName");
        GenderChildText.text = PlayerPrefs.GetString("Gender");
        AgeChildText.text = PlayerPrefs.GetInt("Age") + " ani";
        if (!PlayerPrefs.HasKey("motherRelationStatus"))
        {
            motherRelation = Random.Range(0, 100);
            PlayerPrefs.SetInt("motherRelationStatus", motherRelation);
        }
        if(!PlayerPrefs.HasKey("fatherRelationStatus"))
        {
            fatherRelation = Random.Range(0, 100);
            PlayerPrefs.SetInt("fatherRelationStatus", fatherRelation);
        }
        if (!PlayerPrefs.HasKey("brotherRelationStatus"))
        {
            brotherRelation = Random.Range(0, 100);
            PlayerPrefs.SetInt("brotherRelationStatus", brotherRelation);
        }
        if (!PlayerPrefs.HasKey("sisterRelationStatus"))
        {
            sisterRelation = Random.Range(0, 100);
            PlayerPrefs.SetInt("sisterRelationStatus", sisterRelation);
        }
        if (PlayerPrefs.GetString("CityName") == "Niciunul")
        {
            ResidenceChildText.text = PlayerPrefs.GetString("County");
        }
        else
        {
            ResidenceChildText.text = PlayerPrefs.GetString("CityName") + ", " + PlayerPrefs.GetString("County");
        }
        if (!PlayerPrefs.HasKey("Health"))
        {
           PlayerPrefs.SetFloat("Health", 100);
        }
        if (PlayerPrefs.GetFloat("Health") <= 0)
        {
            if(!PlayerPrefs.HasKey("HealthDefault")) {
                PlayerPrefs.SetFloat("Health", 100);
            } else {
                HealthDefault = PlayerPrefs.GetFloat("HealthDefault");
                PlayerPrefs.SetFloat("Health", HealthDefault);
            }
            
        }

        if (!PlayerPrefs.HasKey("Happiness"))
        {
            PlayerPrefs.SetFloat("Happiness", 100);
        }

        if (!PlayerPrefs.HasKey("Smarts"))
        {
            PlayerPrefs.SetFloat("Smarts", 100);
        }

        if (!PlayerPrefs.HasKey("Looks"))
        {
            PlayerPrefs.SetFloat("Looks", 100);
        }

        HappinessSlider.maxValue = MaxHappiness;
        HealthSlider.maxValue = MaxHealth;
        SmartsSlider.maxValue = MaxSmarts;
        LooksSlider.maxValue = MaxLooks;
        HappinessChildSlider.maxValue = MaxHappiness;
        HealthChildSlider.maxValue = MaxHealth;
        SmartsChildSlider.maxValue = MaxSmarts;
        LooksChildSlider.maxValue = MaxLooks;
        Food = MaxFood;
        if(!PlayerPrefs.HasKey("TextNewAge"))
        {
            PlayerPrefs.SetInt("Age", -1);
        }
        
        Money = 0;
        MessagePanel.SetActive(false);
        if (OnSendSetupEvent != null)
            OnSendSetupEvent();
        checkInformationPanelIcons();
        changeAlphaToImage();
        UpdateUI();
        


    }
    public void AgeIcon()
    {
        if (PlayerPrefs.GetInt("Age") <= 2)
        {
            PlayerPrefs.SetString("BabyIcon", "yes");
            iconImage.sprite = BabyIcon;
        }
        if (PlayerPrefs.GetString("Gender") == "Masculin")
        {

            if (PlayerPrefs.GetInt("Age") <= 18 && PlayerPrefs.GetInt("Age") > 2)
            {
                PlayerPrefs.SetString("BoyIcon", "yes");
                iconImage.sprite = BoyIcon;
            }
            else if (PlayerPrefs.GetInt("Age") <= 50 && PlayerPrefs.GetInt("Age") > 18)
            {
                PlayerPrefs.SetString("ManIcon", "yes");
                iconImage.sprite = ManIcon;
            }
            else if (PlayerPrefs.GetInt("Age") <= 70 && PlayerPrefs.GetInt("Age") > 50)
            {
                PlayerPrefs.SetString("oldManIcon", "yes");
                iconImage.sprite = oldManIcon;
            }
            else if (PlayerPrefs.GetInt("Age") > 70)
            {
                PlayerPrefs.SetString("veryOldManIcon", "yes");
                iconImage.sprite = veryOldManIcon;
            }
        }
        else if (PlayerPrefs.GetString("Gender") == "Feminin")
        {
            if (PlayerPrefs.GetInt("Age") <= 18 && PlayerPrefs.GetInt("Age") > 2)
            {
                PlayerPrefs.SetString("GirlIcon", "yes");
                iconImage.sprite = GirlIcon;
            }
            else if (PlayerPrefs.GetInt("Age") <= 50 && PlayerPrefs.GetInt("Age") > 18)
            {
                PlayerPrefs.SetString("WomanIcon", "yes");
                iconImage.sprite = WomanIcon;
            }
            else if (PlayerPrefs.GetInt("Age") <= 70 && PlayerPrefs.GetInt("Age") > 50)
            {
                PlayerPrefs.SetString("oldWomanIcon", "yes");
                iconImage.sprite = oldWomanIcon;
            }
            else if (PlayerPrefs.GetInt("Age") > 70)
            {
                PlayerPrefs.SetString("veryOldWomanIcon", "yes");
                iconImage.sprite = veryOldWomanIcon;
            }
        }
    }
    public void CreateNewText()
    {
        checkInformationPanelIcons();
        Age = PlayerPrefs.GetInt("Age");
        Age++;
        PlayerPrefs.SetInt("Age", Age);
        AgeChildText.text = PlayerPrefs.GetInt("Age") + " ani";
        checkChangeableIcon();
        if (PlayerPrefs.GetFloat("Health") <= 50 && PlayerPrefs.GetFloat("Health") > 10)
        {
            HealthSlider.fillRect.GetComponent<Image>().color = new Color(221 / 255f, 106 / 255f, 11 / 255f);
            HealthChildSlider.fillRect.GetComponent<Image>().color = new Color(221 / 255f, 106 / 255f, 11 / 255f);
            iconHealth.sprite = iconSick;
            iconChildHealth.sprite = iconSick;
        }
        else if (PlayerPrefs.GetFloat("Health") <= 10)
        {
            HealthSlider.fillRect.GetComponent<Image>().color = Color.red;
            HealthChildSlider.fillRect.GetComponent<Image>().color = Color.red;
            iconHealth.sprite = iconDie;
            iconChildHealth.sprite = iconDie;
        }
        if (PlayerPrefs.GetInt("Age") == 0 && PlayerPrefs.GetString("Gender") == "Masculin")
        {
            
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("CityName")) && PlayerPrefs.GetString("CityName") != "Niciunul")
            {
                string textNewAge = $"<b>Varsta: {PlayerPrefs.GetInt("Age")} ani</b>\nM-am nascut ca barbat in " +
                    $"{PlayerPrefs.GetString("CityName")}, {PlayerPrefs.GetString("County")}." +
                    $" {PlayerPrefs.GetString("conceivedReason")}\n\nZiua mea de nastere este" +
                    $" {PlayerPrefs.GetString("formattedBirthday")}. Zodia mea este {PlayerPrefs.GetString("zodiacSign")}.\n\n" +
                    $"Ma numesc {FirstLastNameText.text}.\nMama mea este {PlayerPrefs.GetString("MotherFNText")} {PlayerPrefs.GetString("LastName")}, " +
                    $"lucreaza ca {PlayerPrefs.GetString("MotherJobsText")} ({PlayerPrefs.GetInt("MotherAge")} ani).\nTatal meu este {PlayerPrefs.GetString("FatherFNText")} {PlayerPrefs.GetString("LastName")}, " +
                    $"lucreaza ca {PlayerPrefs.GetString("FatherJobsText")} ({PlayerPrefs.GetInt("FatherAge")} ani).\n";
                if (PlayerPrefs.HasKey("RandomBrotherFNText") && PlayerPrefs.HasKey("RandomSisterFNText"))
                {
                    textNewAge += $"Am un frate mai mare numit {PlayerPrefs.GetString("RandomBrotherFNText")} ({PlayerPrefs.GetInt("BrotherAge")} ani) si o sora mai mare numita {PlayerPrefs.GetString("RandomSisterFNText")} ({PlayerPrefs.GetInt("SisterAge")} ani).";
                } else {
                    if (PlayerPrefs.HasKey("RandomBrotherFNText"))
                    {
                        textNewAge += $"Am un frate mai mare numit {PlayerPrefs.GetString("RandomBrotherFNText")} ({PlayerPrefs.GetInt("BrotherAge")} ani).";
                    }
                    if (PlayerPrefs.HasKey("RandomSisterFNText"))
                    {
                        textNewAge += $"Am o sora mai mare numita {PlayerPrefs.GetString("RandomSisterFNText")} ({PlayerPrefs.GetInt("SisterAge")} ani).";
                    }
                }
                
                PlayerPrefs.SetString("TextNewAge", textNewAge);
                AgeText.text = PlayerPrefs.GetString("TextNewAge");

            }
            else
            {

                string textNewAge = $"<b>Varsta: {PlayerPrefs.GetInt("Age")} ani</b>\nM-am nascut ca barbat in" +
                    $" {PlayerPrefs.GetString("County")}. {PlayerPrefs.GetString("conceivedReason")}\n\nZiua mea de nastere" +
                    $" este {PlayerPrefs.GetString("formattedBirthday")}. Zodia mea este {PlayerPrefs.GetString("zodiacSign")}." +
                    $"\n\nMa numesc {FirstLastNameText.text}.\nMama mea este {PlayerPrefs.GetString("MotherFNText")} {PlayerPrefs.GetString("LastName")}, " +
                    $"lucreaza ca {PlayerPrefs.GetString("MotherJobsText")} ({PlayerPrefs.GetInt("MotherAge")} ani).\nTatal meu este {PlayerPrefs.GetString("FatherFNText")} {PlayerPrefs.GetString("LastName")}, " +
                    $"lucreaza ca {PlayerPrefs.GetString("FatherJobsText")} ({PlayerPrefs.GetInt("FatherAge")} ani).\n";
                if (PlayerPrefs.HasKey("RandomBrotherFNText") && PlayerPrefs.HasKey("RandomSisterFNText"))
                {
                    textNewAge += $"Am un frate mai mare numit {PlayerPrefs.GetString("RandomBrotherFNText")} ({PlayerPrefs.GetInt("BrotherAge")} ani) si o sora mai mare numita {PlayerPrefs.GetString("RandomSisterFNText")} ({PlayerPrefs.GetInt("SisterAge")} ani).";
                } else {
                    if (PlayerPrefs.HasKey("RandomBrotherFNText"))
                    {
                        textNewAge += $"Am un frate mai mare numit {PlayerPrefs.GetString("RandomBrotherFNText")} ({PlayerPrefs.GetInt("BrotherAge")} ani).";
                    }
                    if (PlayerPrefs.HasKey("RandomSisterFNText"))
                    {
                        textNewAge += $"Am o sora mai mare numita {PlayerPrefs.GetString("RandomSisterFNText")} ({PlayerPrefs.GetInt("SisterAge")} ani).";
                    }
                }
                PlayerPrefs.SetString("TextNewAge", textNewAge);
                AgeText.text = PlayerPrefs.GetString("TextNewAge");

            }


        } 
        else if (PlayerPrefs.GetInt("Age") == 0 && PlayerPrefs.GetString("Gender") == "Feminin")
        {
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("CityName")) && PlayerPrefs.GetString("CityName") != "Niciunul")
            {
                string textNewAge = $"<b>Varsta: {PlayerPrefs.GetInt("Age")} ani</b>\nM-am nascut ca femeie in" +
                    $" {PlayerPrefs.GetString("CityName")}, {PlayerPrefs.GetString("County")}." +
                    $" {PlayerPrefs.GetString("conceivedReason")}\n\nZiua mea de nastere este" +
                    $" {PlayerPrefs.GetString("formattedBirthday")}. Zodia mea este" +
                    $" {PlayerPrefs.GetString("zodiacSign")}.\n\nMa numesc {FirstLastNameText.text}.\nMama mea este" +
                    $" {PlayerPrefs.GetString("MotherFNText")} {PlayerPrefs.GetString("LastName")}, lucreaza ca {PlayerPrefs.GetString("MotherJobsText")} ({PlayerPrefs.GetInt("MotherAge")} ani)." +
                    $" \nTatal meu este {PlayerPrefs.GetString("FatherFNText")} {PlayerPrefs.GetString("LastName")}, lucreaza ca" +
                    $" {PlayerPrefs.GetString("FatherJobsText")} ({PlayerPrefs.GetInt("FatherAge")} ani).\n";
                if (PlayerPrefs.HasKey("RandomBrotherFNText") && PlayerPrefs.HasKey("RandomSisterFNText"))
                {
                    textNewAge += $"Am un frate mai mare numit {PlayerPrefs.GetString("RandomBrotherFNText")} ({PlayerPrefs.GetInt("BrotherAge")} ani) si o sora mai mare numita {PlayerPrefs.GetString("RandomSisterFNText")} ({PlayerPrefs.GetInt("SisterAge")} ani).";
                } else {
                    if (PlayerPrefs.HasKey("RandomBrotherFNText"))
                    {
                        textNewAge += $"Am un frate mai mare numit {PlayerPrefs.GetString("RandomBrotherFNText")} ({PlayerPrefs.GetInt("BrotherAge")} ani).";
                    }
                    if (PlayerPrefs.HasKey("RandomSisterFNText"))
                    {
                        textNewAge += $"Am o sora mai mare numita {PlayerPrefs.GetString("RandomSisterFNText")} ({PlayerPrefs.GetInt("SisterAge")} ani).";
                    }
                }
                PlayerPrefs.SetString("TextNewAge", textNewAge);
                AgeText.text = PlayerPrefs.GetString("TextNewAge");
            }
            else
            {
                string textNewAge = $"<b>Varsta: {PlayerPrefs.GetInt("Age")} ani</b>\nM-am nascut ca femeie in" +
                    $" {PlayerPrefs.GetString("County")}. {PlayerPrefs.GetString("conceivedReason")}\n\nZiua mea" +
                    $" de nastere este {PlayerPrefs.GetString("formattedBirthday")}. Zodia mea este" +
                    $" {PlayerPrefs.GetString("zodiacSign")}.\n\nMa numesc {FirstLastNameText.text}.\nMama mea este" +
                    $" {PlayerPrefs.GetString("MotherFNText")} {PlayerPrefs.GetString("LastName")}, lucreaza ca {PlayerPrefs.GetString("MotherJobsText")} ({PlayerPrefs.GetInt("MotherAge")} ani).\nTatal" +
                    $" meu este {PlayerPrefs.GetString("FatherFNText")} {PlayerPrefs.GetString("LastName")}, lucreaza ca {PlayerPrefs.GetString("FatherJobsText")} ({PlayerPrefs.GetInt("FatherAge")} ani).\n";
                if (PlayerPrefs.HasKey("RandomBrotherFNText") && PlayerPrefs.HasKey("RandomSisterFNText"))
                {
                    textNewAge += $"Am un frate mai mare numit {PlayerPrefs.GetString("RandomBrotherFNText")} ({PlayerPrefs.GetInt("BrotherAge")} ani) si o sora mai mare numita {PlayerPrefs.GetString("RandomSisterFNText")} ({PlayerPrefs.GetInt("SisterAge")} ani).";
                } else {
                    if (PlayerPrefs.HasKey("RandomBrotherFNText"))
                    {
                        textNewAge += $"Am un frate mai mare numit {PlayerPrefs.GetString("RandomBrotherFNText")} ({PlayerPrefs.GetInt("BrotherAge")} ani).";
                    }
                    if (PlayerPrefs.HasKey("RandomSisterFNText"))
                    {
                        textNewAge += $"Am o sora mai mare numita {PlayerPrefs.GetString("RandomSisterFNText")} ({PlayerPrefs.GetInt("SisterAge")} ani).";
                    }
                }
                PlayerPrefs.SetString("TextNewAge", textNewAge);
                AgeText.text = PlayerPrefs.GetString("TextNewAge");
            }
        }
        else
        {
            string textNewAge = $"\n<b>Varsta: {Age} ani<b>\n";
            string textOldAge = PlayerPrefs.GetString("TextNewAge");
            PlayerPrefs.SetString("TextNewAge", textOldAge + textNewAge);
            AgeText.text = PlayerPrefs.GetString("TextNewAge");
        }
        
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        PlayerPrefs.DeleteKey("TextNewAge");
        PlayerPrefs.SetFloat("Health", HealthDefault);
    }

    //public void AutoScroll()
    //{
    //scrollRect.normalizedPosition = new Vector2(0, 0);
    //}
    public void ScrollToBottom()
    {
        // Set the vertical scrollbar value to the maximum (1.0)
        scrollRect.verticalScrollbar.value = 0;
    }

    public void checkInformationPanelIcons()
    {
        if (PlayerPrefs.GetFloat("Happiness") <= 50 && PlayerPrefs.GetFloat("Happiness") > 10)
        {
            HappinessSlider.fillRect.GetComponent<Image>().color = new Color(221 / 255f, 106 / 255f, 11 / 255f);
            HappinessChildSlider.fillRect.GetComponent<Image>().color = new Color(221 / 255f, 106 / 255f, 11 / 255f);
            iconHappiness.sprite = iconSad;
            iconChildHappiness.sprite = iconSad;
        } else if (PlayerPrefs.GetFloat("Happiness") <= 10)
        {
            HappinessSlider.fillRect.GetComponent<Image>().color = Color.red;
            HappinessChildSlider.fillRect.GetComponent<Image>().color = Color.red;
            iconHappiness.sprite = iconCry;
            iconChildHappiness.sprite = iconCry;
        }

        if (PlayerPrefs.GetFloat("Health") <= 50 && PlayerPrefs.GetFloat("Health") > 10)
        {
            HealthSlider.fillRect.GetComponent<Image>().color = new Color(221 / 255f, 106 / 255f, 11 / 255f);
            HealthChildSlider.fillRect.GetComponent<Image>().color = new Color(221 / 255f, 106 / 255f, 11 / 255f);
            iconHealth.sprite = iconSick;
            iconChildHealth.sprite = iconSick;
        }
        else if (PlayerPrefs.GetFloat("Health") <= 10)
        {
            HealthSlider.fillRect.GetComponent<Image>().color = Color.red;
            HealthChildSlider.fillRect.GetComponent<Image>().color = Color.red;
            iconHealth.sprite = iconDie;
            iconChildHealth.sprite = iconDie;
        }

        if (PlayerPrefs.GetFloat("Smarts") <= 50 && PlayerPrefs.GetFloat("Smarts") > 10)
        {
            SmartsSlider.fillRect.GetComponent<Image>().color = new Color(221 / 255f, 106 / 255f, 11 / 255f);
            SmartsChildSlider.fillRect.GetComponent<Image>().color = new Color(221 / 255f, 106 / 255f, 11 / 255f);
            iconSmarts.sprite = iconThink;
            iconChildSmarts.sprite = iconThink;
        }
        else if (PlayerPrefs.GetFloat("Smarts") <= 10)
        {
            SmartsSlider.fillRect.GetComponent<Image>().color = Color.red;
            SmartsChildSlider.fillRect.GetComponent<Image>().color = Color.red;
            iconSmarts.sprite = iconDumb;
            iconChildSmarts.sprite = iconDumb;
        }

        if (PlayerPrefs.GetFloat("Looks") <= 50 && PlayerPrefs.GetFloat("Looks") > 10)
        {
            LooksSlider.fillRect.GetComponent<Image>().color = new Color(221 / 255f, 106 / 255f, 11 / 255f);
            LooksChildSlider.fillRect.GetComponent<Image>().color = new Color(221 / 255f, 106 / 255f, 11 / 255f);
            iconLooks.sprite = iconCool;
            iconChildLooks.sprite = iconCool;
        }
        else if (PlayerPrefs.GetFloat("Looks") <= 10)
        {
            LooksSlider.fillRect.GetComponent<Image>().color = Color.red;
            LooksChildSlider.fillRect.GetComponent<Image>().color = Color.red;
            iconLooks.sprite = iconUgly;
            iconChildLooks.sprite = iconUgly;
        }


    }

    public void checkChangeableIcon()
    {
        if(PlayerPrefs.GetInt("Age") < 3) {
            ChangeableIcon.sprite = InfantIcon;
            ChangeableText.text = "Bebe";
            InfoText.text = "Bebe";
            ImageInfo.sprite = iconChildInfo;
        } else if (PlayerPrefs.GetInt("Age") >= 3 && PlayerPrefs.GetInt("Age") < 6) {
            ChangeableIcon.sprite = KindergartenIcon;
            ChangeableText.text = "Gradinita";
            InfoText.text = "Gradinita";
            ImageInfo.sprite = KindergartenIcon;
        } else if(PlayerPrefs.GetInt("Age") >= 6 && PlayerPrefs.GetInt("Age") < 11) {
            ChangeableIcon.sprite = PrimaryschoolIcon;
            ChangeableText.text = "Primara";
            InfoText.text = "Primara";
            ImageInfo.sprite = PrimaryschoolIcon;
        } else if(PlayerPrefs.GetInt("Age") >= 11 && PlayerPrefs.GetInt("Age") < 15) {
            ChangeableIcon.sprite = SecondaryschoolIcon;
            ChangeableText.text = "Gimnaziala";
            InfoText.text = "Gimnaziala";
            ImageInfo.sprite = SecondaryschoolIcon;
        } else if(PlayerPrefs.GetInt("Age") >= 15 && PlayerPrefs.GetInt("Age") < 19) {
            ChangeableIcon.sprite = HighschoolIcon;
            ChangeableText.text = "Liceu";
            InfoText.text = "Liceu";
            ImageInfo.sprite = HighschoolIcon;
        } else if(PlayerPrefs.GetInt("Age") >= 19 && PlayerPrefs.GetInt("Age") < 24) {
            ChangeableIcon.sprite = UniversityIcon;
            ChangeableText.text = "Facultate";
            InfoText.text = "Facultate";
            ImageInfo.sprite = UniversityIcon;
        } else if(PlayerPrefs.GetInt("Age") >= 24) {
           if(PlayerPrefs.GetString("Gender") == "Feminin")
            {
                if(PlayerPrefs.GetInt("Age") < 63) {
                    ChangeableIcon.sprite = JobIcon;
                    ChangeableText.text = "Job";
                    InfoText.text = "Job";
                    ImageInfo.sprite = JobIcon;
                } else {
                    ChangeableIcon.sprite = RetireIcon;
                    ChangeableText.text = "Pensie";
                    InfoText.text = "Pensie";
                    ImageInfo.sprite = RetireIcon;
                }
            } else if (PlayerPrefs.GetString("Gender") == "Masculin") {
                if (PlayerPrefs.GetInt("Age") < 65) {
                    ChangeableIcon.sprite = JobIcon;
                    ChangeableText.text = "Job";
                    InfoText.text = "Job";
                    ImageInfo.sprite = JobIcon;
                }
                else {
                    ChangeableIcon.sprite = RetireIcon;
                    ChangeableText.text = "Pensie";
                    InfoText.text = "Pensie";
                    ImageInfo.sprite = RetireIcon;
                }
            }
        }
    }

    public void changeAlphaToImage()
    {
        if (PlayerPrefs.GetInt("Age") < 17)
        {
            Color newColor = Color.gray;
            imageAssets.color = newColor;
            ColorBlock colors = buttonAssets.colors;
            colors.normalColor = newColor;
            colors.highlightedColor = newColor;
            colors.selectedColor = newColor;
            buttonAssets.colors = colors;
        } else
        {
            buttonAssets.colors = defaultColors;

        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
