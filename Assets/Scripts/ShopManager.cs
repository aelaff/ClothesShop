using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public Button purchaseBtn;
    public Transform itemListParent,basketListParent;
    public TextMeshProUGUI totalPriceText;

    private List<Item> availableItems;
    private List<Item> basketItems;
    private int totalPrice;
    

    private void Awake()
    {
        availableItems = new List<Item>();
        basketItems = new List<Item>();
    }

    private void OnEnable()
    {
        availableItems.Clear();
        basketItems.Clear();
        DestroyChildren(basketListParent);
        DestroyChildren(itemListParent);
        foreach (Item item in ItemDatabase.Instance.ItemList)
        {
            availableItems.Add(item);
            GameObject obj = Instantiate(itemPrefab, itemListParent);
            obj.GetComponent<ItemUI>().Initialize(item, OnItemClicked);
            obj.GetComponent<ItemUI>().removeButton.gameObject.SetActive(false);
        }
        purchaseBtn.interactable = false;
        UpdateTotalPrice();
    }

    private void OnItemClicked(Item item)
    {
        if (!basketItems.Contains(item))
        {

            basketItems.Add(item);
            GameObject obj = Instantiate(itemPrefab, basketListParent);
            obj.GetComponent<ItemUI>().Initialize(item, OnItemClicked);
            obj.GetComponent<Button>().interactable = false;
            purchaseBtn.interactable = true;

        }
        UpdateTotalPrice();
    }

    private void UpdateTotalPrice()
    {
        totalPrice = 0;
        foreach (Item item in basketItems)
        {
            totalPrice += item.Price;
        }
        totalPriceText.text = "$" + totalPrice.ToString();
    }

    public void OnPurchaseButtonClicked()
    {
        bool allPurchased = true;
        foreach (Item item in basketItems)
        {
            if (!GameManager.Instance.PurchasedItems.Contains(item))
            {
                allPurchased = false;
                if (GameManager.Instance.SpendMoney(item.Price))
                {
                    GameManager.Instance.AddPurchasedItem(item);
                }
                else
                {
                    UIManager.Instance.popUp.ShowPopup("Money", "You do not have enough money to buy these items ! ");
                    break;
                }
            }
        }
        if (allPurchased)
        {
            UIManager.Instance.popUp.ShowPopup("Purchased", "All items are already purchased!");
        }

        basketItems.Clear();
        UpdateTotalPrice();
        DestroyChildren(basketListParent);
        purchaseBtn.interactable = false;
    }
    public void RemoveItemFromBasket(Item item)
    {
        basketItems.Remove(item);
        if(basketItems.Count==0)
            purchaseBtn.interactable = false;

        UpdateTotalPrice();
    }
    public void DestroyChildren(Transform transform)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
