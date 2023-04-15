// This class represents an Item UI element in the shop

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI priceText;
    public Button removeButton;

    private Item item;
    private System.Action<Item> onClicked;

    // Initialize the item UI with the item data and the callback function
    public void Initialize(Item item, System.Action<Item> onClicked)
    {
        this.item = item;
        this.onClicked = onClicked;

        // Set the icon and price text based on the item data
        iconImage.sprite = item.Icon;
        priceText.text = "$" + item.Price.ToString();
        // Add a listener to the remove button to call the callback function and remove the item from the basket
        removeButton.onClick.AddListener(() =>
        {
            onClicked?.Invoke(item);
            ShopManager shopManager = FindObjectOfType<ShopManager>();
            shopManager.RemoveItemFromBasket(item);
            Destroy(gameObject);

        });
    }
    // Called when the item is clicked
    public void OnItemClicked()
    {
        if (onClicked != null)
        {
            onClicked(item);
        }
    }
    // Called when the remove button is clicked
    public void OnRemoveButtonClicked()
    {
        onClicked?.Invoke(item);
        Destroy(gameObject);
    }
}
