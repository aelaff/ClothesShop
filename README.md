# ClothesShop
 This is a Unity project for a clothes shop in a simulation game, similar to 'The Sims' and 'Stardew Valley'. The clothes shop allows players to interact with the shopkeeper, purchase and sell items, view item icons and prices, and equip outfits that are visible on the character.

## Getting Started
To run the project, you need to have Unity installed. Clone the repository and open it in Unity.

## Prerequisites
Unity 2021.3.2f1 or later
Visual Studio or another IDE for editing scripts

## Features
1. Player Character: The system includes a player character that can walk and interact with the game world.
2. Clothes Shop: The clothes shop is a functional shop where the player can buy and sell clothes. It includes a shopkeeper character that the player can talk to, The player can buy clothes from the shop by selecting the item and clicking the buy button. The player can sell clothes by selecting the item from their wardrobe and clicking the sell button.
4. Equipping Clothes: The player can equip the clothes they have bought by selecting the item from their wardrobe and clicking the equip button. The equipped clothes will be visible on the player character.
5. Wardrobe: The player's wardrobe is a list of all the clothes they have bought. They can select an item to see more information about it and to sell or equip it.

Overall, the clothes shop system is designed to allow the player to buy and sell clothes and to equip the clothes they have bought. The system includes a player character that can walk and interact with the game world, and a functional clothes shop where the player can buy and sell clothes. The UI allows the player to easily navigate the clothes shop and wardrobe, and to equip and sell clothes.

## Scripting Files
The clothes shop system consists of several classes that work together to provide the necessary features. The player character is controlled by the CharacterController class, which allows them to move and interact with the game world. The EquippingManager is responsible for managing the player's equipped items and updating the character's appearance accordingly.

The GameManager class is a singleton that keeps track of the game state, including the player's inventory and equipped items. Items are represented by the Item class, which is a ScriptableObject that stores the item's name, icon, price, and other relevant information. The ItemUI class is responsible for displaying items in the shop and the player's inventory.

The PopupManager class handles the display of pop-up messages, such as confirmation dialogs when buying items. The ShopManager class is responsible for managing the shop inventory, including buying and selling items, and updating the UI accordingly. The UIManager class handles the overall user interface, including the main menu, shop, and wardrobe screens.

The WardrobeItemUI class displays items in the player's wardrobe and allows them to equip or unequip them. The WardrobeManager class handles the player's wardrobe inventory and updates the EquippingManager accordingly.



## Built With
1. Unity - game engine
2. C# - programming language
3. Photoshop - for UI design

## Authors
Ahmed Alaff - Initial work

## Acknowledgments
* Unity Documentation for helpful resources and tutorials
* Blue Gravity Studio for providing the interview task and guidance



