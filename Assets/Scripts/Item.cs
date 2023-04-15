using UnityEngine;



[CreateAssetMenu(fileName = "NewItem", menuName = "Shop/Item")]
public class Item : ScriptableObject
{
    public int Id;
    public int Price;
    public Sprite Icon;
    public Sprite PelvisArmor, Torso, ArmL, ForearmL, ArmR, ForearmR, Helmet, LegL, ShinL, LegR, ShinR;
}
