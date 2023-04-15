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

    public void Initialize(Item item, System.Action<Item> onClicked)
    {
        this.item = item;
        this.onClicked = onClicked;

        iconImage.sprite = item.Icon;
        priceText.text = "$" + item.Price.ToString();
        removeButton.onClick.AddListener(() =>
        {
            onClicked?.Invoke(item);
            ShopManager shopManager = FindObjectOfType<ShopManager>();
            shopManager.RemoveItemFromBasket(item);
            Destroy(gameObject);

        });
    }
    public void OnItemClicked()
    {
        if (onClicked != null)
        {
            onClicked(item);
        }
    }
    public void OnRemoveButtonClicked()
    {
        onClicked?.Invoke(item);
        Destroy(gameObject);
    }
}
