using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "GameManager";
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private int money;
    private List<Item> purchasedItems;
    private List<Item> equippedItems;
    public List<Item> storeItems;

    public int Money { get { return money; } }
    public List<Item> PurchasedItems { get { return purchasedItems; } }
    public List<Item> EquippedItems { get { return equippedItems; } }
    public delegate void MoneyChangedEventHandler(int newMoney);
    public event MoneyChangedEventHandler MoneyChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        purchasedItems = new List<Item>();
        equippedItems = new List<Item>();
        money = 1000;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        MoneyChanged?.Invoke(money);

    }

    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            MoneyChanged?.Invoke(money);

            return true;
        }
        return false;
    }

    public void AddPurchasedItem(Item item)
    {
        purchasedItems.Add(item);
    }

    public void RemovePurchasedItem(Item item)
    {
        purchasedItems.Remove(item);
    }

    public void AddEquippedItem(Item item)
    {
        equippedItems.Add(item);
    }

    public void RemoveEquippedItem(Item item)
    {
        equippedItems.Remove(item);
    }
}
