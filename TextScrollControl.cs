using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScrollControl : MonoBehaviour
{
    public GameObject scrollLimitObject;
    public ScrollRect scrollRect;
    // Start is called before the first frame update
    void Start()
    {
        if (scrollLimitObject != null && scrollRect != null)
        {
            RectTransform contentRectTransform = scrollRect.content.GetComponent<RectTransform>();
            RectTransform limitRectTransform = scrollLimitObject.GetComponent<RectTransform>();

            Vector2 scrollToPosition = new Vector2(0, -(limitRectTransform.anchoredPosition.y + limitRectTransform.sizeDelta.y));

            contentRectTransform.anchoredPosition = scrollToPosition;
        }
    }

    
}
