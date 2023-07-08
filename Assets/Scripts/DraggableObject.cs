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

        _placeHolderObject = Instantiate(_clonePrefab, _rectTransform.position, _rectTransform.rotation);
        _placeHolderObject.transform.SetParent(_rectTransform.parent);

        ReturnTransform = _placeHolderObject.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
       _rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1.0f;
        _canvasGroup.blocksRaycasts = true;

        _rectTransform.position = ReturnTransform.position;
        Destroy(_placeHolderObject);

    }
}
