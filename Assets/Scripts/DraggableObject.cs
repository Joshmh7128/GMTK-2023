using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class DraggableObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Transform _returnTransform;


    [SerializeField] private Canvas _renderCanvas;
    private void Awake() 
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetCanvas(Canvas renderCanvas)
    {
        _renderCanvas = renderCanvas;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
        Debug.Log("Begin Item position: " + _rectTransform.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
       _rectTransform.anchoredPosition += eventData.delta / _renderCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1.0f;
        _canvasGroup.blocksRaycasts = true;
        Debug.Log("End Item position: " + _rectTransform.anchoredPosition);
    }

    /* private DragManager _dragManager;
    private Vector2 _centerPoint;
    private Vector2 _worldCenterPoint => transform.TransformPoint(_centerPoint);

    private void Awake() 
    {
        _dragManager = GetComponentInParent<DragManager>();
        _centerPoint = (transform as RectTransform).rect.center;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragManager.RegisterDraggedObject(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_dragManager.IsWithinBounds(_worldCenterPoint + eventData.delta))
        {
            transform.Translate(eventData.delta);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragManager.UnregisterDraggedObject(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
