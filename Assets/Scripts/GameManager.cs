// The GameManager class controls the game's state and behavior, including player money, inventory, and equipped items.

using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // The GameManager is a singleton, meaning there is only one instance of the class throughout the game.
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

    // Player's current money amount.
    private int money;
    // List of items that the player has purchased.
    private List<Item> purchasedItems;
    // List of items that the player has equipped.
    private List<Item> equippedItems;
    // List of items that are available to purchase in the store.
    public List<Item> storeItems;
    // Getter methods to access private variables.
    public int Money { get { return money; } }
    public List<Item> PurchasedItems { get { return purchasedItems; } }
    public List<Item> EquippedItems { get { return equippedItems; } }
    // Event handler for when the player's money changes.
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

    // Adds money to the player's current money amount.
    public void AddMoney(int amount)
    {
        money += amount;
        MoneyChanged?.Invoke(money);

    }

    // Subtracts money from the player's current money amount.
    // Returns true if the player has enough money to make the purchase, false otherwise.
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

    // Adds an item to the list of items that the player has purchased.
    public void RemovePurchasedItem(Item item)
    {
        purchasedItems.Remove(item);
    }

    // Removes an item from the list of items that the player has purchased.
    public void AddEquippedItem(Item item)
    {
        equippedItems.Add(item);
    }

    // Removes an item from the list of items that the player has equipped.
    public void RemoveEquippedItem(Item item)
    {
        equippedItems.Remove(item);
    }
}
