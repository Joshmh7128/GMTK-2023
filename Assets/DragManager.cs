using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform _defaultLayer = null, _dragLayer = null;
    private Rect _boundingBox;
    private DraggableObject _currentDraggedObject = null;

    public DraggableObject CurrentDraggedObject
    {
        get => _currentDraggedObject;
    }

    void Awake()
    {
        SetBoundingBoxRect(_dragLayer);
    }

    public void RegisterDraggedObject(DraggableObject drag)
    {
        _currentDraggedObject = drag;
        drag.transform.SetParent(_dragLayer);
    }

    public void UnregisterDraggedObject(DraggableObject drag)
    {
        drag.transform.SetParent(_defaultLayer);
        _currentDraggedObject = null;
    }

    public bool IsWithinBounds(Vector2 position)
    {
        return _boundingBox.Contains(position);
    }

    private void SetBoundingBoxRect(RectTransform rect)
    {
        var corners = new Vector3[4];
        rect.GetWorldCorners(corners);
        var position = corners[0];

        Vector2 size = new Vector2(rect.lossyScale.x * rect.rect.size.x,
                                    rect.lossyScale.y * rect.rect.size.y);

        _boundingBox = new Rect(position, size);
    }
}
