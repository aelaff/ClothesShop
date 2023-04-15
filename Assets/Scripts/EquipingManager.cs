// A script for managing the equipping of items on a character

using UnityEngine;

public class EquipingManager : MonoBehaviour
{
    // References to the sprite renderers for each equipped item
    public SpriteRenderer pelvisArmorRenderer;
    public SpriteRenderer torsoRenderer;
    public SpriteRenderer armLRenderer;
    public SpriteRenderer forearmLRenderer;
    public SpriteRenderer armRRenderer;
    public SpriteRenderer forearmRRenderer;
    public SpriteRenderer helmetRenderer;
    public SpriteRenderer legLRenderer;
    public SpriteRenderer shinLRenderer;
    public SpriteRenderer legRRenderer;
    public SpriteRenderer shinRRenderer;

    // The default sprite for each equipped item
    private Sprite defaultPelvisArmorSprite;
    private Sprite defaultTorsoSprite;
    private Sprite defaultArmLSprite;
    private Sprite defaultForearmLSprite;
    private Sprite defaultArmRSprite;
    private Sprite defaultForearmRSprite;
    private Sprite defaultHelmetSprite;
    private Sprite defaultLegLSprite;
    private Sprite defaultShinLSprite;
    private Sprite defaultLegRSprite;
    private Sprite defaultShinRSprite;

    // A static property to get the instance of the EquipingManager
    private static EquipingManager instance;
    public static EquipingManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EquipingManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "EquipingManager";
                    instance = obj.AddComponent<EquipingManager>();
                }
            }
            return instance;
        }
    }
    private void Start()
    {
        // Save the default sprites
        defaultPelvisArmorSprite = pelvisArmorRenderer.sprite;
        defaultTorsoSprite = torsoRenderer.sprite;
        defaultArmLSprite = armLRenderer.sprite;
        defaultForearmLSprite = forearmLRenderer.sprite;
        defaultArmRSprite = armRRenderer.sprite;
        defaultForearmRSprite = forearmRRenderer.sprite;
        defaultHelmetSprite = helmetRenderer.sprite;
        defaultLegLSprite = legLRenderer.sprite;
        defaultShinLSprite = shinLRenderer.sprite;
        defaultLegRSprite = legRRenderer.sprite;
        defaultShinRSprite = shinRRenderer.sprite;
    }

    // A function to equip an item onto the character
    public void EquipItem(Item item)
    {

        // Set the sprite of each equipped item to the corresponding sprite of the item, or the default sprite if the item sprite is null
        pelvisArmorRenderer.sprite = item.PelvisArmor ?? defaultPelvisArmorSprite;
        torsoRenderer.sprite = item.Torso ?? defaultTorsoSprite;
        armLRenderer.sprite = item.ArmL ?? defaultArmLSprite;
        forearmLRenderer.sprite = item.ForearmL ?? defaultForearmLSprite;
        armRRenderer.sprite = item.ArmR ?? defaultArmRSprite;
        forearmRRenderer.sprite = item.ForearmR ?? defaultForearmRSprite;
        helmetRenderer.sprite = item.Helmet ?? defaultHelmetSprite;
        legLRenderer.sprite = item.LegL ?? defaultLegLSprite;
        shinLRenderer.sprite = item.ShinL ?? defaultShinLSprite;
        legRRenderer.sprite = item.LegR ?? defaultLegRSprite;
        shinRRenderer.sprite = item.ShinR ?? defaultShinRSprite;
    }

    // A function to unequip all items from the character and set all equipped item sprites to their default sprites
    public void UnequipItem()
    {
        pelvisArmorRenderer.sprite = defaultPelvisArmorSprite;
        torsoRenderer.sprite = defaultTorsoSprite;
        armLRenderer.sprite = defaultArmLSprite;
        forearmLRenderer.sprite = defaultForearmLSprite;
        armRRenderer.sprite = defaultArmRSprite;
        forearmRRenderer.sprite = defaultForearmRSprite;
        helmetRenderer.sprite = defaultHelmetSprite;
        legLRenderer.sprite = defaultLegLSprite;
        shinLRenderer.sprite = defaultShinLSprite;
        legRRenderer.sprite = defaultLegRSprite;
        shinRRenderer.sprite = defaultShinRSprite;
    }
}
