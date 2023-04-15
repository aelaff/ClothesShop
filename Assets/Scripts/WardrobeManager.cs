using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeManager : MonoBehaviour
{
    public GameObject wardrobeItemPrefab;
    public Transform wardrobeListParent;

    private List<Item> purchasedItems;
    public EquipingManager equipingManager;
    private List<WardrobeItemUI> wardrobeItemUIs;
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
        purchasedItems = GameManager.Instance.PurchasedItems;
        wardrobeItemUIs = new List<WardrobeItemUI>();
        DestroyChildren(wardrobeListParent);
        for (int i = 0; i < purchasedItems.Count; i++)
        {
            GameObject newItem = Instantiate(wardrobeItemPrefab, wardrobeListParent);
            WardrobeItemUI wardrobeItem = newItem.GetComponent<WardrobeItemUI>();
            bool isEquipped = GameManager.Instance.EquippedItems.Contains(purchasedItems[i]);
            wardrobeItem.Initialize(purchasedItems[i], isEquipped);
            wardrobeItemUIs.Add(wardrobeItem);

        }
    }
   
    public void EquipItem(WardrobeItemUI wardrobeItem)
    {
        EquipingManager.Instance.EquipItem(wardrobeItem.GetItem());
        GameManager.Instance.AddEquippedItem(wardrobeItem.GetItem());
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
    public void UnequipItem(WardrobeItemUI wardrobeItem)
    {
        EquipingManager.Instance.UnequipItem();
        GameManager.Instance.RemoveEquippedItem(wardrobeItem.GetItem());
        foreach (WardrobeItemUI wardrobeItemUI2 in wardrobeItemUIs)
        {
            if (wardrobeItemUI2.GetItem() == wardrobeItem.GetItem())
            {
                wardrobeItemUI2.SetEquipped(false);
            }
        }
    }
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
    public void RemoveItemFromUI(Item item)
    {
        WardrobeItemUI wardrobeItemToRemove = null;
        foreach (WardrobeItemUI wardrobeItemUI in wardrobeItemUIs)
        {
            if (wardrobeItemUI.GetItem() == item)
            {
                wardrobeItemToRemove = wardrobeItemUI;
                break;
            }
        }
        if (wardrobeItemToRemove != null)
        {
            wardrobeItemUIs.Remove(wardrobeItemToRemove);
            Destroy(wardrobeItemToRemove.gameObject);
        }
    }
    public void DestroyChildren(Transform transform)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
