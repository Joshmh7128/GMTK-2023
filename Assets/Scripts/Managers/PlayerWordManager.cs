using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWordManager : MonoBehaviour
{
    private static PlayerWordManager _instance;
    [SerializeField] private List<string> _playerNouns;
    [SerializeField] private List<string> _playerVerbs;
    [SerializeField] private List<string> _playerAdjs;

    [SerializeField] private float _annoyanceLevel;

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

        _annoyanceLevel = 0f;
        
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
    }

    public void SubmitWordBankSelection()
    {
        SaveNounSelections();
        SaveVerbSelections();
        SaveAdjSelections();

        SceneManager.LoadScene("Village", LoadSceneMode.Single);
    }

    public List<string> GetWordsByTag (string tag)
    {
        var words = new List<string>();
        switch(tag)
        {
            case "NounBank":
                words = _playerNouns;
                break;
            case "VerbBank":
                words = _playerVerbs;
                break;
            case "AdjBank":
                words = _playerAdjs;
                break;
            default:
                break;
        }

        return words;
    }

    public void UpdateAnnoyanceLevel (float annoyingScore)
    {
        if (annoyingScore < 0) // -1
        {
            _annoyanceLevel += 1;
        }
        else if (annoyingScore >= 0 && annoyingScore <= 0.5)
        {
            _annoyanceLevel += 1;
        }

        Debug.Log("Player annoyed level: " + _annoyanceLevel);
    }

    public bool GetFinalPlayerAnnoyedLevel()
    {
        return _annoyanceLevel >= 4;
    }
}
