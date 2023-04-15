// This script manages the popup UI panel and handles its display

using TMPro;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    // References to the UI elements
    public GameObject popupPanel;
    public TextMeshProUGUI popupTitle,popupBody;


    // Function to show the popup panel with the given title and message
    public void ShowPopup(string title,string message)
    {
        // Update the text elements with the given title and message
        popupTitle.text = title;
        popupBody.text = message;
        // Activate the popup panel to show it on the screen
        popupPanel.SetActive(true);
    }



}
