using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SetNameManager : MonoBehaviour
{
    public GameObject FirstNameInput;
    public GameObject LastNameInput;
    private GameObject FLNameInput;
    public string FirstName;
    public string LastName;
    public GameObject FirstNameText;
    public GameObject LastNameText;

    private InputField inputField;
    private string defaultValueF;
    private string defaultValueL;
    public static bool initDone = false;

    public void StoreName()
    {
        FirstName = FirstNameInput.GetComponent<TMP_InputField>().text;
        LastName = LastNameInput.GetComponent<TMP_InputField>().text;
        PlayerPrefs.SetString("FirstName", FirstName);
        PlayerPrefs.SetString("LastName", LastName);


    }

    public void Start()
    {

        if (PlayerPrefs.GetString("boolEnterM") == "True")
        {

            PlayerPrefs.SetString("boolEnterM", "False");
            FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstBoyName");
            LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastBoyName");
            PlayerPrefs.SetString("FirstName", FirstNameInput.GetComponent<TMP_InputField>().text);
            PlayerPrefs.SetString("LastName", LastNameInput.GetComponent<TMP_InputField>().text);
        }
        else if (PlayerPrefs.GetString("boolEnterF") == "True")
        {

            PlayerPrefs.SetString("boolEnterF", "False");
            FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstGirlName");
            LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastGirlName");
            PlayerPrefs.SetString("FirstName", FirstNameInput.GetComponent<TMP_InputField>().text);
            PlayerPrefs.SetString("LastName", LastNameInput.GetComponent<TMP_InputField>().text);
        }
        //else
        //{
        //    Debug.Log(PlayerPrefs.GetString("RandomFirstBoyName"));
        //    PlayerPrefs.SetString("boolEnterM", "False");
        //    FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstBoyName");
        //    LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastBoyName");
        //    PlayerPrefs.SetString("FirstName", FirstNameInput.GetComponent<TMP_InputField>().text);
        //    PlayerPrefs.SetString("LastName", LastNameInput.GetComponent<TMP_InputField>().text);
        //}

        if (initDone == false)
        {
            initDone = true;
            if (PlayerPrefs.GetString("Gender") == "Masculin")
            {
                FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstBoyName");
                LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastBoyName");
            }
            else if (PlayerPrefs.GetString("Gender") == "Feminin")
            {
                FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstGirlName");
                LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastGirlName");
            }

            //Do your stuff once here and it should only happen once in a game.
            FirstName = FirstNameInput.GetComponent<TMP_InputField>().text;
            PlayerPrefs.SetString("FirstName", FirstName);
            defaultValueF = PlayerPrefs.GetString("FirstName"); // Store the default value at the start.
            PlayerPrefs.SetString("defaultValueF", defaultValueF);
            LastName = LastNameInput.GetComponent<TMP_InputField>().text;
            PlayerPrefs.SetString("LastName", LastName);
            defaultValueL = PlayerPrefs.GetString("LastName"); // Store the default value at the start.
            PlayerPrefs.SetString("defaultValueL", defaultValueL);


        }
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("FirstName")))
        {

            FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("FirstName");
            PlayerPrefs.SetString("FirstName", FirstNameInput.GetComponent<TMP_InputField>().text);
        }
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("LastName")))
        {
            LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("LastName");
            PlayerPrefs.SetString("LastName", LastNameInput.GetComponent<TMP_InputField>().text);
        }

    }

    public void changeNameNow()
    {
        Debug.Log("da");
        if (PlayerPrefs.GetString("boolEnterM") == "True")
        {

            Debug.Log(PlayerPrefs.GetString("RandomFirstBoyName"));
            PlayerPrefs.SetString("boolEnterM", "False");
            FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstBoyName");
            LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastBoyName");
            PlayerPrefs.SetString("FirstName", FirstNameInput.GetComponent<TMP_InputField>().text);
            PlayerPrefs.SetString("LastName", LastNameInput.GetComponent<TMP_InputField>().text);
        }
        else if (PlayerPrefs.GetString("boolEnterF") == "True")
        {

            Debug.Log(PlayerPrefs.GetString("RandomFirstGirlName"));
            PlayerPrefs.SetString("boolEnterF", "False");
            FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstGirlName");
            LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastGirlName");
            PlayerPrefs.SetString("FirstName", FirstNameInput.GetComponent<TMP_InputField>().text);
            PlayerPrefs.SetString("LastName", LastNameInput.GetComponent<TMP_InputField>().text);
        }
        else if (!PlayerPrefs.HasKey("FirstName"))
        {

            PlayerPrefs.SetString("boolEnterM", "False");
            FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstBoyName");
            LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastBoyName");
            PlayerPrefs.SetString("FirstName", FirstNameInput.GetComponent<TMP_InputField>().text);
            PlayerPrefs.SetString("LastName", LastNameInput.GetComponent<TMP_InputField>().text);
        }

        if (initDone == false)
        {
            initDone = true;
            if (PlayerPrefs.GetString("Gender") == "Masculin")
            {
                FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstBoyName");
                LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastBoyName");
            }
            else if (PlayerPrefs.GetString("Gender") == "Feminin")
            {
                FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstGirlName");
                LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastGirlName");
            }

            //Do your stuff once here and it should only happen once in a game.
            FirstName = FirstNameInput.GetComponent<TMP_InputField>().text;
            PlayerPrefs.SetString("FirstName", FirstName);
            defaultValueF = PlayerPrefs.GetString("FirstName"); // Store the default value at the start.
            PlayerPrefs.SetString("defaultValueF", defaultValueF);
            LastName = LastNameInput.GetComponent<TMP_InputField>().text;
            PlayerPrefs.SetString("LastName", LastName);
            defaultValueL = PlayerPrefs.GetString("LastName"); // Store the default value at the start.
            PlayerPrefs.SetString("defaultValueL", defaultValueL);


        }
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("FirstName")))
        {

            FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("FirstName");
            PlayerPrefs.SetString("FirstName", FirstNameInput.GetComponent<TMP_InputField>().text);
        }
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("LastName")))
        {
            LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("LastName");
            PlayerPrefs.SetString("LastName", LastNameInput.GetComponent<TMP_InputField>().text);
        }
    }
    public void OnInputValueChanged()
    {
        if (string.IsNullOrEmpty(FirstNameInput.GetComponent<TMP_InputField>().text))
        {
            // If the input is cleared, reset it to the default value.
            if (PlayerPrefs.GetString("Gender") == "Masculin")
            {
                FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstBoyName");
            }
            else if (PlayerPrefs.GetString("Gender") == "Feminin")
            {
                FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstGirlName");
            }
        }
        if (string.IsNullOrEmpty(LastNameInput.GetComponent<TMP_InputField>().text))
        {
            // If the input is cleared, reset it to the default value.
            if (PlayerPrefs.GetString("Gender") == "Masculin")
            {
                LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastBoyName");
            } else if (PlayerPrefs.GetString("Gender") == "Feminin")
            {
                LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastGirlName");
            }


        }
    }
    public void ResetFirstLastNameButton()
    {
        if (PlayerPrefs.GetString("Gender") == "Masculin")
        {
            FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstBoyName");
            LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastBoyName");
        }
        if (PlayerPrefs.GetString("Gender") == "Feminin")
        {
            FirstNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomFirstGirlName");
            LastNameInput.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("RandomLastGirlName");
        }
    }




}
