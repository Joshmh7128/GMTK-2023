using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBankManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _wordBankItemPrefab;

    [SerializeField]
    private Transform _wordBankTransform;

    [SerializeField]
    private bool _prepopulateWordBank = false;

    [SerializeField]
    private bool _requiresPrepopulation = false;

    [SerializeField]
    private List<string> _initialWordBankWords = new List<string>();

    private PlayerWordManager _playerWordManager;
    // Start is called before the first frame update
    void Start()
    {
        if (_prepopulateWordBank)
        {
            InitializeWordBank(_initialWordBankWords);
        }
        else if (_requiresPrepopulation)
        {
            try
            {
                _playerWordManager = GameObject.FindWithTag("PlayerWordBank").GetComponent<PlayerWordManager>();
            } catch { Debug.LogWarning("No Word Bank Found!"); }
            var tag = _wordBankTransform.gameObject.tag;

            var playerWords = _playerWordManager.GetWordsByTag(tag);
            InitializeWordBank(playerWords);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeWordBank(List<string> words)
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

    public List<string> GetCurrentWords()
    {
        var currentWords = new List<string>();
        
        return currentWords;
    }
}
