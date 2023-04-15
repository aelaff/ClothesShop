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

    public void Initialize(Item item, bool isEquipped)
    {
        this.item = item;
        this.isEquipped = isEquipped;
        itemImage.sprite = item.Icon;
        itemPriceText.text = "$" + item.Price.ToString();

        SetEquipped(isEquipped);

        equipButton.onClick.AddListener(OnEquipButtonClicked);
        sellButton.onClick.AddListener(OnSellButtonClicked);
    }

    private void OnEquipButtonClicked()
    {
        // SetEquipped(!isEquipped);
        if (isEquipped)
        {
            WardrobeManager.Instance.UnequipItem(this);
        }
        else
        {
            WardrobeManager.Instance.EquipItem(this);
        }
    }
    public Item GetItem()
    {
        return item;
    }

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
    private void OnSellButtonClicked()
    {
        GameManager.Instance.AddMoney(item.Price);
        GameManager.Instance.RemovePurchasedItem(item);
        WardrobeManager.Instance.UnequipItem(this);
        WardrobeManager.Instance.UpdateWardrobeList(); 
        //WardrobeManager.Instance.RemoveItemFromUI(item);
        

        Destroy(gameObject);
    }
}
