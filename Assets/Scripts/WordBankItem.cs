using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordBankItem : MonoBehaviour
{
    private string _word;
    private TMP_Text _wordText;

    public string Word
    {
        get => _word;
        set
        {
           UpdateWord(value);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateWord(string value)
    {
        var tmpText = GetComponentInChildren<TMP_Text>();
        tmpText.text = value;
        _word = value;
    }
}
