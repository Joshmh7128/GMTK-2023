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
    private HashSet<string> AnnoyingTerms;
    private HashSet<string> MildAnnoyingTerms;
    private HashSet<string> NonAnnoyingTerms;

    private static ScenarioManager _instance = null;

    [SerializeField]
    private GameObject _wordDropPrefab;

    private GameManager _gameManager;

    private Scenario _currentScenario;


    private string verbLiteral = "(Verb)";
    private string nounLiteral = "(Noun)";
    private string adjLiteral = "(Adjective)";

    private Dictionary<string, Scenario> _scenarioMap = new Dictionary<string, Scenario>();

    private const float ANNOYING_SCORE = -1f;
    private const float MILD_SCORE = 0.5f;
    private const float GOOD_SCORE = 1.0f;

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
        SceneManager.activeSceneChanged += HandleActiveSceneChanged;
        
        /* _scenarioMap["Necromancer"] = new Scenario
        {
            NarratorText = @"Despite warnings from the local population, our hero, who apparently knows no fear, makes their way into the old dungeon of an ancient necromancer 
                            A necromancer so powerful in its ability to churn the dead that in another time might have served as the antagonist to our Hero. 
                            Unfortunately, this is not that story. But the ancient necromancer will still prove formidable, able to imbue their skeletal army with the ability to (Verb). 
                            Why is the hero nonchalantly wandering into someone else's property you might ask? Why to commit robbery of course! 
                            The Ancient Necromancer wears pants that would allow our hero to (Verb) A skill necessary to save the kingdom!"
        };*/

        var sceneName = SceneManager.GetActiveScene().name;

        InstantiateScenarioUI(_scenarioMap[_currentScenario]);
    }

    public void SubmitPlayerChoices()
    {
        var dropZoneObject= GameObject.FindWithTag("WordDropZone");
        var chosenWords = dropZoneObject.GetComponentsInChildren<WordBankItem>();

        var annoyingCount = 0;
        var mildCount = 0;
        var nonAnnoyCount = 0;

        foreach (var word in chosenWords)
        {
            var playerWord = word.Word;
            if (AnnoyingTerms.Contains(playerWord))
            {
                Debug.Log("Annoying word: " + word.Word);
                annoyingCount += 1;
            }
            else if (MildAnnoyingTerms.Contains(playerWord))
            {
                Debug.Log("MildAnnoyingTerms: " + word.Word);
                mildCount += 1;
            }
            else if (NonAnnoyingTerms.Contains(playerWord))
            {
                Debug.Log("NonAnnoyingTerms " + word.Word);
                nonAnnoyCount += 1;
            }
        }

        float annoyingScore = (-1f * annoyingCount) + (-0.5f * mildCount) + (nonAnnoyCount);
        Debug.Log("Annoying Score: " + annoyingScore);

        DetermineResponse(annoyingScore);

    }

    private void HandleActiveSceneChanged(Scene current, Scene next)
    {
        string nextSceneName = next.name;
        
        var nextScenario = GetScenarioFromScene(nextSceneName);

        InstantiateScenarioUI(nextScenario);
    }

    private Scenario GetScenarioFromScene(string sceneName)
    {
        return new Scenario
        {
            NarratorText = @"Despite warnings from the local population, our hero, who apparently knows no fear, makes their way into the old dungeon of an ancient necromancer. A necromancer so powerful in its ability to churn the dead that in another time might have served as the antagonist to our Hero. Unfortunately, this is not that story. But the ancient necromancer will still prove formidable, able to imbue their skeletal army with the ability to (Verb). Why is the hero nonchalantly wandering into someone else's property you might ask? Why to commit robbery of course! The Ancient Necromancer wears pants that would allow our hero to (Verb) A skill necessary to save the kingdom!"
        };
    }

    private void InstantiateScenarioUI(Scenario gameScenario)
    {
        var scenarioText = GameObject.FindWithTag("ScenarioText").GetComponent<TMP_Text>();
        scenarioText.text = gameScenario.NarratorText.Replace("\n","");

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

    private void DetermineResponse(float annoyingScore)
    {
        var responseText = "";
        if (annoyingScore < 0) // -1
        {
            responseText = _scenarioMap[_currentScenario].AnnoyedResponse;
        }
        else if (annoyingScore > 0 && annoyingScore <= MILD_SCORE)
        {
            responseText = _scenarioMap[_currentScenario].MildAnnoyedResponse;
        }
        else if (annoyingScore > MILD_SCORE)
        {
            responseText = _scenarioMap[_currentScenario].NonAnnoyedResponse;
        }

        Debug.Log("Response: " + responseText);
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
