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
    private void OnEnable()
    {
        GameManager.Instance.MoneyChanged += OnMoneyChanged;
        moneyText.text = "$" + GameManager.Instance.Money;

    }

    private void OnDisable()
    {
        GameManager.Instance.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int newMoney)
    {
        moneyText.text = "$" + newMoney.ToString();
    }
}
