using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _wordBankItemPrefab;
    [SerializeField]
    private Transform _wordBank;
    // Start is called before the first frame update
    void Start()
    {
        // InitializeWordBank(new List<string> { "Test", "Test", "Test", "Test","Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test"});
        InitializeWordBank(new List<string> { "Test"});
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    public void InitializeWordBank(List<string> words)
    {
        var wordBank = _wordBank.gameObject.GetComponent<WordBankContainer>();
        foreach (var word in words)
        {
            var wordBankItem = Instantiate(_wordBankItemPrefab, _wordBank.position, Quaternion.identity);
            var drag = wordBankItem.GetComponent<DraggableObject>();
            drag.SetCanvas(wordBank.GetRenderCanvas());

            var originalScale = wordBankItem.transform.localScale;

            wordBankItem.transform.SetParent(_wordBank);
            wordBankItem.transform.localScale = originalScale;
        }
    }
}
