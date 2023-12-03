using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    GameMenager _GameManager;
    public int AddToFood;
    public int AddToHealth;
    public int AddToMoney;
    public bool Purchased;
    public bool OneTimePurchase;
    public string ItemDescription;

    public int RentalDays;
    int RentalDaysRemaining;


    public TextMeshProUGUI ItemDescriptionText;
    public TextMeshProUGUI ItemCostText;

    private string RequirementString;

    public List<Item> Requirements;

    private void OnEnable()
    {
        GameMenager.OnSendUpdateUI += UpdateItem;
        GameMenager.OnSendSetupEvent += SetupItem;
    }
    private void OnDisable()
    {
        GameMenager.OnSendUpdateUI -= UpdateItem;
        GameMenager.OnSendSetupEvent -= SetupItem;
    }
    // Start is called before the first frame update
    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameMenager>();
        ItemDescriptionText.text = ItemDescription;
        ItemCostText.text = AddToMoney.ToString();
    }
    
    void SetupItem()
    {
        Purchased = false;
    }
    void UpdateItem()
    {

        if(RentalDays > 0 && Purchased)
        {
            RentalDaysRemaining--;

            if (RentalDaysRemaining == 0)
                Purchased = false;
        }

    }
    public bool CheckRequirements() {
        bool PassedRequirements = true;
        RequirementString = "Conditii: ";
        string Comma = "";
        foreach(Item CurrentItem in Requirements) {
            if(!CurrentItem.Purchased) {
                PassedRequirements = false;
                RequirementString += Comma + CurrentItem.ItemDescription;
                Comma = ", ";
            }
                
        }
        return PassedRequirements;
    }
    public void ProcessItem() {
        if(OneTimePurchase && Purchased) {
            _GameManager.DisplayMessage("Deja l-ai cumparat.");
            return;
        }
        if(!CheckRequirements()) {
            _GameManager.DisplayMessage($"Nu indeplinesti conditiile. {RequirementString}.");
            return;
        }
        if(_GameManager.BuyItem(AddToMoney)) {
            //_GameManager.AddToHealth(AddToHealth);
            _GameManager.AddToFood(AddToFood);
            Purchased = true;
            if (RentalDays > 0)
                RentalDaysRemaining = RentalDays;
            _GameManager.UpdateUI();
        }
        
    }


}
