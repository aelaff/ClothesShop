// This scriptable object represents an item in the shop that players can purchase and equip
// It includes an Id, a price, and multiple sprites for different parts of the player's character

using UnityEngine;
// The CreateAssetMenu attribute allows us to create instances of this ScriptableObject from the Unity Editor's context menu
[CreateAssetMenu(fileName = "NewItem", menuName = "Shop/Item")]
public class Item : ScriptableObject
{
    public int Id;// The unique identifier for the item
    public int Price;// The price of the item in the shop
    public Sprite Icon;// The icon representing the item in the shop
    public Sprite PelvisArmor, Torso, ArmL, ForearmL, ArmR, ForearmR, Helmet, LegL, ShinL, LegR, ShinR;// Sprites for different parts of the player's character
}
