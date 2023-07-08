using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppableArea : MonoBehaviour, IDropHandler
{
    private RectTransform _rectTransform;

    private void Awake() 
    {
        _rectTransform = GetComponent<RectTransform>();
    }
   
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
             var drag = eventData.pointerDrag.GetComponent<DraggableObject>();
           
            drag.ReturnTransform = _rectTransform;
            var dragTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            dragTransform.SetParent(_rectTransform);
        }   
    }
    

}
