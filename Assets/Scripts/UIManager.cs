//The UIManager class is responsible for managing and displaying the UI elements on the screen.
//It includes functions to update the player's money, handle popups, and enable/disable shop buttons.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public PopupManager popUp;
    public GameObject shopButton;
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Called when the object is enabled
    private void OnEnable()
    {
        // Register the OnMoneyChanged function to the MoneyChanged event in the GameManager
        GameManager.Instance.MoneyChanged += OnMoneyChanged;
        // Update the money TextMeshProUGUI element with the current money amount
        moneyText.text = "$" + GameManager.Instance.Money;

    }

    // Called when the object is disabled
    private void OnDisable()
    {
        // Unregister the OnMoneyChanged function from the MoneyChanged event in the GameManager
        GameManager.Instance.MoneyChanged -= OnMoneyChanged;
    }

    // Called when the player's money amount has changed
    private void OnMoneyChanged(int newMoney)
    {
        // Update the money TextMeshProUGUI element with the new money amount
        moneyText.text = "$" + newMoney.ToString();
    }
}
