using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class DraggableObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    [SerializeField] private Transform _returnTransform;
    private int _currentSibilingIndex;
    private GameObject _placeHolderObject = null;

    [SerializeField] private GameObject _clonePrefab;

    public Transform ReturnTransform
    {
        get => _returnTransform;
        set
        {
            _returnTransform = value;
        }
    }


    public int CurrentSiblingIndex
    {
        get => _currentSibilingIndex;
        set
        {
            _currentSibilingIndex = value;
        }
    }

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

        _placeHolderObject = Instantiate(_clonePrefab, _rectTransform.position, _rectTransform.rotation);
        _placeHolderObject.transform.SetParent(_rectTransform.parent);

        ReturnTransform = _placeHolderObject.GetComponent<RectTransform>();
        // DummyTransform = transform.parent;
        // CurrentSiblingIndex = transform.GetSiblingIndex();
    }

    public void OnDrag(PointerEventData eventData)
    {
       // _rectTransform.anchoredPosition += eventData.delta / _renderCanvas.scaleFactor;
       _rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Exit Drag hit");
        _canvasGroup.alpha = 1.0f;
        _canvasGroup.blocksRaycasts = true;

        _rectTransform.position = ReturnTransform.position;
        Destroy(_placeHolderObject);

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
