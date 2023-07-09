using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWordManager : MonoBehaviour
{
    private static PlayerWordManager _instance;
    private List<string> _playerNouns;
    private List<string> _playerVerbs;
    private List<string> _playerAdjs;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerNouns = new List<string>();
        _playerAdjs = new List<string>();
        _playerVerbs = new List<string>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SaveNounSelections()
    {
        var nounBankObject = GameObject.FindGameObjectWithTag("NounBank");
        if (nounBankObject != null)
        {
            var children = nounBankObject.GetComponentsInChildren<WordBankItem>();
            _playerNouns.Clear();

            foreach (var child in children)
            {
                _playerNouns.Add(child.Word);
            }
        }

        foreach (var word in _playerNouns)
        {
            Debug.Log("Noun " + word);
        }
    }

    private void SaveVerbSelections()
    {
        var verbBankObject = GameObject.FindGameObjectWithTag("VerbBank");
        if (verbBankObject != null)
        {
            var children = verbBankObject.GetComponentsInChildren<WordBankItem>();
            _playerVerbs.Clear();

            foreach (var child in children)
            {
                _playerVerbs.Add(child.Word);
            }
        }

        foreach (var word in _playerVerbs)
        {
            Debug.Log("Verb " + word);
        }
    }

    private void SaveAdjSelections()
    {
        var adjBankObject = GameObject.FindGameObjectWithTag("AdjBank");
        if (adjBankObject != null)
        {
            var children = adjBankObject.GetComponentsInChildren<WordBankItem>();
            _playerAdjs.Clear();

            foreach (var child in children)
            {
                _playerAdjs.Add(child.Word);
            }
        }

        foreach (var word in _playerAdjs)
        {
            Debug.Log("Adj: " + word);
        }
    }

    public void SubmitWordBankSelection()
    {
        SaveNounSelections();
        SaveVerbSelections();
        SaveAdjSelections();
    }
}
