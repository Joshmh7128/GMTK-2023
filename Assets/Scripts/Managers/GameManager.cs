using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    private

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
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadDraftScene()
    {
        LoadSceneManager.LoadScene("WordDraftScene");
    }

    public void Quit()
    {
        Debug.Log("Quit Game!");
        Application.Quit();        
    }
}
