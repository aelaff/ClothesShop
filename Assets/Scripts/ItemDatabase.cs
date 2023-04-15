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

    public List<Item> ItemList
    {
        get { return itemList; }
    }
}
