//The ItemDatabase class is responsible for managing a list of items.
//It has a static instance to allow access to the database from anywhere in the game.

using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;

    [SerializeField] private List<Item> itemList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    //GetItem method returns an item based on the id provided. 
    public Item GetItem(int id)
    {
        foreach (Item item in itemList)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        return null;
    }
    //The ItemList property returns the list of items in the database.
    public List<Item> ItemList
    {
        get { return itemList; }
    }
}
