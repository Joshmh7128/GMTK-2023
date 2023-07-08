using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WordBankContainer : MonoBehaviour
{
    [SerializeField]
    private Canvas _renderCanvas;

    void Awake()
    {
        _renderCanvas = GetComponentInParent<Canvas>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Canvas GetRenderCanvas()
    {
        return _renderCanvas;
    }
}
