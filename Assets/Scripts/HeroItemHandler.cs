using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroItemHandler : MonoBehaviour
{
    public List<bool> m_Items = new List<bool>();

    [SerializeField] string currentScene; // the scene we were in on the last frame

    private void Start()
    {
        DontDestroyOnLoad(this);

        // make our list long and full of falst
        for (int i = 0; i < (int)HeroItemManager.Items.max; i++)
            m_Items.Add(false);
    }

    public void GiveItem(HeroItemManager.Items item)
    {
        m_Items[(int)item] = true;

        RepopulateItems();
    }

    private void FixedUpdate()
    {
        // get our scene from this frame
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName != currentScene)
        {
            // set the new scene name
            currentScene = sceneName;
            // repopulate our items
            RepopulateItems();

        }
    }

    void RepopulateItems()
    {
        Debug.Log("Repopulate");

        for (int i = 0; i < m_Items.Count; i++)
        {
            if (m_Items[i])
                FindAnyObjectByType<HeroItemManager>().EnableItem((HeroItemManager.Items)i);
        }
    }
}
