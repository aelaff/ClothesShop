// This script is attached to an item in the wardrobe menu, which contains a sprite, a price text, an equip button, and a sell button.
// The script manages the behavior of each item in the menu, such as equipping and selling the item.
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WardrobeItemUI : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI itemPriceText;
    public Button equipButton;
    public Button sellButton;

    private Item item;
    private bool isEquipped;

    // This function initializes the wardrobe item UI by setting its values and adding event listeners to buttons
    public void Initialize(Item item, bool isEquipped)
    {
        // Assign the item values passed in to the class variables
        this.item = item;
        this.isEquipped = isEquipped;
        itemImage.sprite = item.Icon;
        itemPriceText.text = "$" + item.Price.ToString();

        // Call the SetEquipped function to update the equip button text based on the isEquipped value
        SetEquipped(isEquipped);

        // Add event listeners to the equip and sell buttons
        equipButton.onClick.AddListener(OnEquipButtonClicked);
        sellButton.onClick.AddListener(OnSellButtonClicked);
    }

    // Called when the equip button is clicked.
    private void OnEquipButtonClicked()
    {
        if (isEquipped)
        {
            WardrobeManager.Instance.UnequipItem(this);
        }
        else
        {
            WardrobeManager.Instance.EquipItem(this);
        }
    }
    // Returns the associated item.
    public Item GetItem()
    {
        return item;
    }

    // Sets whether the item is equipped and updates the equip button's text accordingly.
    public void SetEquipped(bool equipped)
    {
        isEquipped = equipped;
        if (isEquipped)
        {
            equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unequip";
        }
        else
        {
            equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
        }
    }
    // Called when the sell button is clicked.
    private void OnSellButtonClicked()
    {
        // Adds the item's price to the player's money and removes the item from the player's inventory.
        GameManager.Instance.AddMoney(item.Price);
        GameManager.Instance.RemovePurchasedItem(item);
        // Unequips the item and updates the wardrobe list.
        WardrobeManager.Instance.UnequipItem(this);
        WardrobeManager.Instance.UpdateWardrobeList();


        // Destroys the wardrobe item in the menu.
        Destroy(gameObject);
    }
}
