using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InitializeWordBank : MonoBehaviour
{
    [SerializeField]
    private List<string> allWordBankWords;

    [SerializeField]
    private Transform _wordBankTransform;

    [SerializeField]
    private GameObject _wordBankItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        CreateWordItems(allWordBankWords);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateWordItems(List<string> words)
    {
        var wordBank = _wordBankTransform.gameObject.GetComponent<WordBankContainer>();
        foreach (var word in words)
        {
            var wordObject = Instantiate(_wordBankItemPrefab, _wordBankTransform.position, Quaternion.identity);
            var drag = wordObject.GetComponent<DraggableObject>();
            drag.SetCanvas(wordBank.GetRenderCanvas());

            var wordBankItem = wordObject.GetComponent<WordBankItem>();
            wordBankItem.Word = word;

            var originalScale = wordBankItem.transform.localScale;

            wordBankItem.transform.SetParent(_wordBankTransform);
            wordBankItem.transform.localScale = originalScale;
        }
    }
}
