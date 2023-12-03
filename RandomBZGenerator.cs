using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class RandomBZGenerator : MonoBehaviour
{
    DateTime startDate = new DateTime(1900, 1, 1);
    DateTime endDate = new DateTime(2023, 12, 31);
    TimeSpan timeSpan;
    int randomDays;
    DateTime startDateAddDays;
    string formattedBirthday;
    string zodiacSign;
    // Start is called before the first frame update
    void Start()
    {
        timeSpan = endDate - startDate;
        randomDays = UnityEngine.Random.Range(0, (int)timeSpan.TotalDays);
        startDateAddDays = startDate.AddDays(randomDays);
        formattedBirthday = FormatBirthday(startDateAddDays, "ro-RO");
        zodiacSign = GetZodiacSign(startDateAddDays.Month, startDateAddDays.Day);
        PlayerPrefs.SetString("formattedBirthday", formattedBirthday);
        PlayerPrefs.SetString("zodiacSign", zodiacSign);
    }
    public string FormatBirthday(DateTime birthday, string cultureCode)
    {
        CultureInfo cultureInfo = new CultureInfo(cultureCode);
        string formattedDay = birthday.Day.ToString(cultureInfo);
        string formattedMonth = birthday.ToString("MMMM", cultureInfo);
        return formattedDay + " " + char.ToUpper(formattedMonth[0]) + formattedMonth.Substring(1);
    }
    public string GetZodiacSign(int month, int day)
    {
        if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            return "Berbec";
        else if ((month == 4 && day >= 21) || (month == 5 && day <= 20))
            return "Taur";
        else if ((month == 5 && day >= 21) || (month == 6 && day <= 21))
            return "Gemeni";
        else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
            return "Rac";
        else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            return "Leu";
        else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            return "Fecioara";
        else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            return "Balanta";
        else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            return "Scorpion";
        else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            return "Sagetator";
        else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            return "Capricorn";
        else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            return "Varsator";
        else
            return "Pesti";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
