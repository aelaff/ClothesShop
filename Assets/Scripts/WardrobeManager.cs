// This script manages the wardrobe system in the game.
// It creates and initializes wardrobe items and updates them based on player's actions.
using System.Collections.Generic;
using UnityEngine;

public class WardrobeManager : MonoBehaviour
{
    public GameObject wardrobeItemPrefab;
    public Transform wardrobeListParent;

    private List<Item> purchasedItems;
    public EquipingManager equipingManager;
    private List<WardrobeItemUI> wardrobeItemUIs;
    // Singleton pattern implementation to ensure only one instance of the script exists in the game

    private static WardrobeManager instance;
    public static WardrobeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<WardrobeManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "WardrobeManager";
                    instance = obj.AddComponent<WardrobeManager>();
                }
            }
            return instance;
        }
    }
    void OnEnable()
    {
        // Initialize the purchased items and wardrobe item UIs
        purchasedItems = GameManager.Instance.PurchasedItems;
        wardrobeItemUIs = new List<WardrobeItemUI>();
        DestroyChildren(wardrobeListParent);
        // Create and initialize the wardrobe items
        for (int i = 0; i < purchasedItems.Count; i++)
        {
            GameObject newItem = Instantiate(wardrobeItemPrefab, wardrobeListParent);
            WardrobeItemUI wardrobeItem = newItem.GetComponent<WardrobeItemUI>();
            bool isEquipped = GameManager.Instance.EquippedItems.Contains(purchasedItems[i]);
            wardrobeItem.Initialize(purchasedItems[i], isEquipped);
            wardrobeItemUIs.Add(wardrobeItem);

        }
    }

    // Equips an item and updates the wardrobe item UIs
    public void EquipItem(WardrobeItemUI wardrobeItem)
    {
        EquipingManager.Instance.EquipItem(wardrobeItem.GetItem());
        GameManager.Instance.AddEquippedItem(wardrobeItem.GetItem());
        // Set the equipped status of the wardrobe item based on whether it is the currently equipped item
        foreach (WardrobeItemUI wardrobeItemUI in wardrobeItemUIs)
        {
            if (wardrobeItemUI.GetItem() == wardrobeItem.GetItem())
            {
                wardrobeItemUI.SetEquipped(true);
            }
            else
            {
                wardrobeItemUI.SetEquipped(false);
            }
        }
    }
    // Unequips an item and updates the wardrobe item UIs
    public void UnequipItem(WardrobeItemUI wardrobeItem)
    {
        EquipingManager.Instance.UnequipItem();
        GameManager.Instance.RemoveEquippedItem(wardrobeItem.GetItem());
        // Set the equipped status of the wardrobe item to false
        foreach (WardrobeItemUI wardrobeItemUI2 in wardrobeItemUIs)
        {
            if (wardrobeItemUI2.GetItem() == wardrobeItem.GetItem())
            {
                wardrobeItemUI2.SetEquipped(false);
            }
        }
    }
    // Updates the wardrobe item UIs by destroying and recreating them based on the current purchased items
    public void UpdateWardrobeList()
    {
        // Clear the current wardrobe item UIs.
        foreach (WardrobeItemUI wardrobeItemUI in wardrobeItemUIs)
        {
            Destroy(wardrobeItemUI.gameObject);
        }
        wardrobeItemUIs.Clear();

        // Rebuild the wardrobe item UIs.
        purchasedItems = GameManager.Instance.PurchasedItems;
        for (int i = 0; i < purchasedItems.Count; i++)
        {
            GameObject newItem = Instantiate(wardrobeItemPrefab, wardrobeListParent);
            WardrobeItemUI wardrobeItem = newItem.GetComponent<WardrobeItemUI>();
            bool isEquipped = GameManager.Instance.EquippedItems.Contains(purchasedItems[i]);
            wardrobeItem.Initialize(purchasedItems[i], isEquipped);
            wardrobeItemUIs.Add(wardrobeItem);
        }


    }
    
    // Destroy any existing wardrobe items in the wardrobe list
    public void DestroyChildren(Transform transform)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
