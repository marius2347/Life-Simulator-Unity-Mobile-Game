using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameMenager;

public class LoadSceneManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject MainGame;
    public GameObject NewGame;
    public GameObject SetName;
    public GameObject SetGender;
    public GameObject SetCounty;
    public GameObject SetCity;
    public GameObject SetTalent;
    public GameObject SetAttributes;
    public GameObject SetCountyBGColor;
    public GameObject SetTalentBGColor;
    public GameObject SetAttributesBGColor;
    public GameObject NewGameManager;
    public GameObject SetNameManager;
    public GameObject SetGenderManager;
    public GameObject SetCountyManager;
    public GameObject SetCityManager;
    public GameObject SetTalentManager;
    public GameObject SetAttributesManager;
    public GameObject RandomConceivedTextManager;
    public CanvasGroup MainGameCanvas;
    public CanvasGroup NewGameCanvas;
    public CanvasGroup SetNameCanvas;
    public CanvasGroup SetGenderCanvas;
    public CanvasGroup SetCountyCanvas;
    public CanvasGroup SetCityCanvas;
    public CanvasGroup SetTalentCanvas;
    public CanvasGroup SetAttributesCanvas;


    private void Start()
    {
        NewGame.SetActive(false);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadSceneOverlapping(string sceneName)
    {
        GameObject gameObjectToHide = GameObject.Find("CanvasMainGame");
        gameObjectToHide.SetActive(false);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        
    }
    
    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
        MainGame.SetActive(false);
    }

    public void OpenMainGame()
    {
        MainMenu.SetActive(false);
        MainGame.SetActive(true);
    }
    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("GameExists", "no");
    }
    public void OpenNewGame()
    {
        MainMenu.SetActive(false);
        MainGame.SetActive(true);
        NewGame.SetActive(true);
        SetName.SetActive(false);
        SetGender.SetActive(false);
        SetCounty.SetActive(false);
        SetCity.SetActive(false);
        SetTalent.SetActive(false);
        SetAttributes.SetActive(false);
        SetCountyBGColor.SetActive(false);
        SetTalentBGColor.SetActive(false);
        SetAttributesBGColor.SetActive(false);
        SetNameManager.SetActive(false);
        NewGameManager.SetActive(true);
        SetGenderManager.SetActive(true);
        SetCountyManager.SetActive(true);
        SetCityManager.SetActive(true);
        SetTalentManager.SetActive(true);
        SetAttributesManager.SetActive(true);
        RandomConceivedTextManager.SetActive(true);
        MainGameCanvas.interactable = false;
        MainGameCanvas.blocksRaycasts = false;
        MainGameCanvas.alpha = 0.1F;
        NewGameCanvas.interactable = true;
        NewGameCanvas.blocksRaycasts = true;
    }
    public void OpenSetName()
    {
        MainGame.SetActive(true);
        NewGame.SetActive(false);
        SetName.SetActive(true);
        SetNameManager.SetActive(true);
        MainGameCanvas.interactable = false;
        MainGameCanvas.blocksRaycasts = false;
        MainGameCanvas.alpha = 0.1F;
        SetNameCanvas.interactable = true;
        SetNameCanvas.blocksRaycasts = true;
    }
    public void OpenSetGender()
    {
        MainGame.SetActive(true);
        NewGame.SetActive(false);
        SetGender.SetActive(true);
        MainGameCanvas.interactable = false;
        MainGameCanvas.blocksRaycasts = false;
        MainGameCanvas.alpha = 0.1F;
        SetGenderCanvas.interactable = true;
        SetGenderCanvas.blocksRaycasts = true;
    }
    public void OpenSetCounty()
    {
        MainGame.SetActive(true);
        NewGame.SetActive(false);
        SetCounty.SetActive(true);
        SetCountyBGColor.SetActive(true);
        MainGameCanvas.interactable = false;
        MainGameCanvas.blocksRaycasts = false;
        MainGameCanvas.alpha = 0.1F;
        SetCountyCanvas.interactable = true;
        SetCountyCanvas.blocksRaycasts = true;
    }

    public void OpenSetCity()
    {
        MainGame.SetActive(true);
        NewGame.SetActive(false);
        SetCity.SetActive(true);
        MainGameCanvas.interactable = false;
        MainGameCanvas.blocksRaycasts = false;
        MainGameCanvas.alpha = 0.1F;
        SetCityCanvas.interactable = true;
        SetCityCanvas.blocksRaycasts = true;
    }

    public void OpenSetTalent()
    {
        MainGame.SetActive(true);
        NewGame.SetActive(false);
        SetTalent.SetActive(true);
        SetTalentBGColor.SetActive(true);
        MainGameCanvas.interactable = false;
        MainGameCanvas.blocksRaycasts = false;
        MainGameCanvas.alpha = 0.1F;
        SetTalentCanvas.interactable = true;
        SetTalentCanvas.blocksRaycasts = true;
    }

    public void OpenSetAttributes()
    {
        MainGame.SetActive(true);
        NewGame.SetActive(false);
        SetAttributes.SetActive(true);
        SetAttributesBGColor.SetActive(true);
        MainGameCanvas.interactable = false;
        MainGameCanvas.blocksRaycasts = false;
        MainGameCanvas.alpha = 0.1F;
        SetAttributesCanvas.interactable = true;
        SetAttributesCanvas.blocksRaycasts = true;
    }

    
}
