using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppableArea : MonoBehaviour, IDropHandler
{
    private RectTransform _rectTransform;
    private bool _hasObject = false;
    private void Awake() 
    {
        
    }
   
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            _rectTransform = GetComponent<RectTransform>();
            Debug.Log("Anchor Position: " + _rectTransform.anchoredPosition);
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = _rectTransform.transform.position;

            eventData.pointerDrag.GetComponent<RectTransform>().transform.SetParent(transform);
            //_hasObject = true;
        }
    }
}
