using UnityEngine;

public class EquipingManager : MonoBehaviour
{
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

    public void EquipItem(Item item)
    {

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
