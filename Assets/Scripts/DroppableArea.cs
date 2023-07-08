using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppableArea : MonoBehaviour, IDropHandler // s, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;

    private void Awake() 
    {
        
    }
   
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            _rectTransform = GetComponent<RectTransform>();
             var drag = eventData.pointerDrag.GetComponent<DraggableObject>();
            var ogReturn = drag.ReturnTransform;
           
            drag.ReturnTransform = _rectTransform;
            var dragTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            dragTransform.SetParent(_rectTransform);

            /* var ;
            dragTransform.position = _rectTransform.position;*/
        }   
    }
    

}
