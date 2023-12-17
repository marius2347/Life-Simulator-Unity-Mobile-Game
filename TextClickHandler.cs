using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(TMP_Text))]
public class TextClickHandler : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        TMP_Text pTextMeshPro = GetComponent<TMP_Text>();

        int linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position, Camera.main);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = pTextMeshPro.textInfo.linkInfo[linkIndex];
            if (linkInfo.GetLinkID() == "scene1")
            {
                SceneManager.LoadScene("MainGame");
            }
            else if (linkInfo.GetLinkID() == "scene2")
            {
                SceneManager.LoadScene("SetCity");
            }
        }
        else
        {
            Debug.Log("NO");
        }
    }
}

