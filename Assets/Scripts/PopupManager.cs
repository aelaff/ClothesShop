using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI popupTitle,popupBody;


    public void ShowPopup(string title,string message)
    {
        popupTitle.text = title;
        popupBody.text = message;
        popupPanel.SetActive(true);
    }



}
