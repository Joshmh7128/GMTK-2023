using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField]
    public List<Scenario> SceneScenarios;
    
    private HashSet<string> AnnoyingTerms;
    private HashSet<string> MildAnnoyingTerms;
    private HashSet<string> NonAnnoyingTerms;

    [SerializeField]
    private GameObject _wordDropPrefab;

    private GameManager _gameManager;

    private Scenario _currentScenario;

    private string verbLiteral = "(Verb)";
    private string nounLiteral = "(Noun)";
    private string adjLiteral = "(Adjective)";


    private const float ANNOYING_SCORE = -1f;
    private const float MILD_SCORE = 0.5f;
    private const float GOOD_SCORE = 1.0f;

    [SerializeField]
    private TMP_Text _responseText;
    [SerializeField]
    private GameObject _responsePanel;

    [SerializeField]
    private GameObject _wordBankUI;

    private PlayerWordManager _playerManager;

    void Awake()
    {
        AnnoyingTerms = new HashSet<string>
        {
            "Jar o' Piss",
            "Wedgie",
            "Pocket Sand",
            "Banjo",
            "Sink",
            "Caress",
            "Stink",
            "Tickle",
            "Woo",
            "Finagle",
            "Kinky",
            "Rambunctious",
            "Sassy",
            "Vile",
            "Macabre"
        };

        MildAnnoyingTerms = new HashSet<string>
        {
            "Finger Gun",
            "Dog Collar",
            "Wheel",
            "Feather Duster",
            "Jar o’ Slime",
            "Insult",
            "tinkle",
            "gobble",
            "inflate",
            "Slander",
            "Messy",
            "Phallic",
            "Funky",
            "Stinky",
            "Unremarkable"
        };

        NonAnnoyingTerms = new HashSet<string>
        {
            "Chalice",
            "Bucket",
            "Shield",
            "Flute",
            "Barrel",
            "Lubricate",
            "Slay",
            "Rob",
            "Knock - Out",
            "Insult",
            "Striking",
            "Crooked",
            "Fleeting",
            "Romantic",
            "Tidy"
        };        
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerManager = GameObject.FindGameObjectWithTag("PlayerWordBank").GetComponent<PlayerWordManager>();
        var currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName.Equals("Throne"))
        {
            var playerAnnoyed = _playerManager.GetFinalPlayerAnnoyedLevel();
            var scenarioIndex = playerAnnoyed ? 0 : 1;
            _currentScenario = SceneScenarios[scenarioIndex];
        }
        else
        {
            var rand = new System.Random();
            var scenarioIndex = rand.Next(0, 2);
            _currentScenario = SceneScenarios[scenarioIndex];
        }
       
        InstantiateScenarioUI(_currentScenario);
    }


    public void SubmitPlayerChoices()
    {
        if (SceneManager.GetActiveScene().name.Equals("Throne"))
        {
           ContinueScenario();
        }
        else
        {
            var dropZoneObject= GameObject.FindWithTag("WordDropZone");
            var chosenWords = dropZoneObject.GetComponentsInChildren<WordBankItem>();
            var playerInputs = new List<string>();

            foreach (var word in chosenWords)
            {
                var playerWord = word.Word;
                playerInputs.Add(playerWord);
            }

            _currentScenario.UpdateInputs(playerInputs);
            _currentScenario.ProcessOutputText();

            var scenarioText = GameObject.FindWithTag("ScenarioText").GetComponent<TMP_Text>();
            scenarioText.text = _currentScenario.NarratorText.Replace("\n","");

            var annoyingScore = CalculateAnnoyingScore(playerInputs);

            var heroResponse = DetermineResponse(annoyingScore);

            _playerManager.UpdateAnnoyanceLevel(annoyingScore);

            _responsePanel.SetActive(true);
            _wordBankUI.SetActive(false);
            _responseText.text = heroResponse;
        }
    }

    public void ContinueScenario()
    {
       var currentIndex = SceneManager.GetActiveScene().buildIndex;
       if (currentIndex < SceneManager.sceneCountInBuildSettings - 1)
       {
            currentIndex++;
            SceneManager.LoadScene(currentIndex, LoadSceneMode.Single);
       }
       else
       {
            SceneManager.LoadScene("EndGame");
       }
    }

    public float CalculateAnnoyingScore(List<string> chosenWords)
    {
        var annoyingCount = 0;
        var mildCount = 0;
        var nonAnnoyCount = 0;

        foreach (var playerWord in chosenWords)
        {
            if (AnnoyingTerms.Contains(playerWord))
            {
                Debug.Log("Annoying word: " + playerWord);
                annoyingCount += 1;
            }
            else if (MildAnnoyingTerms.Contains(playerWord))
            {
                Debug.Log("MildAnnoyingTerms: " + playerWord);
                mildCount += 1;
            }
            else if (NonAnnoyingTerms.Contains(playerWord))
            {
                Debug.Log("NonAnnoyingTerms " + playerWord);
                nonAnnoyCount += 1;
            }
        }

        float annoyingScore = (-1f * annoyingCount) + (-0.5f * mildCount) + (nonAnnoyCount);
        Debug.Log("Annoying Score: " + annoyingScore);

        return annoyingScore;
    }

    private void InstantiateScenarioUI(Scenario gameScenario)
    {
        var scenarioText = GameObject.FindWithTag("ScenarioText").GetComponent<TMP_Text>();
        scenarioText.text = gameScenario.NarratorText.Replace("\n","");

        if (SceneManager.GetActiveScene().name.Equals("Throne"))
        {
            _wordBankUI.SetActive(false);
        }
        else
        {
            int literalCount = 0;
        
            var verbCount = Regex.Matches(gameScenario.NarratorText, verbLiteral).Cast<Match>().Count();
            var nounCount = Regex.Matches(gameScenario.NarratorText, nounLiteral).Cast<Match>().Count();
            var adjCount = Regex.Matches(gameScenario.NarratorText, adjLiteral).Cast<Match>().Count();

            literalCount += (verbCount + nounCount + adjCount);
            Debug.Log("Literal Count: " + literalCount);

            var dropZoneTransform = GameObject.FindWithTag("WordDropZone").transform;
            for (int i = 0; i < literalCount; i++)
            {
                var dropAreaObject = Instantiate(_wordDropPrefab, dropZoneTransform.position, Quaternion.identity);
                var originalScale = dropAreaObject.transform.localScale;

                dropAreaObject.transform.SetParent(dropZoneTransform.transform);
                dropAreaObject.transform.localScale = originalScale;
            }
        }
    }

    private string DetermineResponse(float annoyingScore)
    {
        var responseText = "";
        if (annoyingScore < 0) // -1
        {
            responseText = _currentScenario.AnnoyedResponse;
        }
        else if (annoyingScore > 0 && annoyingScore <= MILD_SCORE)
        {
            responseText = _currentScenario.MildAnnoyedResponse;
        }
        else if (annoyingScore > MILD_SCORE)
        {
            responseText = _currentScenario.NonAnnoyedResponse;
        }

        Debug.Log("Response: " + responseText);
        return responseText;
    }
}

[Serializable]
public class Scenario: MonoBehaviour
{
    protected List<string> _inputs;
    public List<string> Inputs { get => _inputs; }
    public string NarratorText { get; set; }
    public string AnnoyedResponse { get; set; }
    public string MildAnnoyedResponse { get; set; }
    public string NonAnnoyedResponse { get; set; }

    public bool IsLastScenarioInScene = false;

    public virtual void ProcessOutputText ()
    {
    }

    public virtual void UpdateInputs(List<string> inputs)
    {
        _inputs.Clear();
        foreach (var word in inputs)
        {
            _inputs.Add(word);
        }
    }
}
