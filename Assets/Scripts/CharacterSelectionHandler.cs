using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionHandler : MonoBehaviour
{
    /// <summary>
    /// This script works by reading the current scenario in the scene, and then chooses the correct
    /// NPC to place in the game space
    /// </summary>

    [SerializeField] GameObject npcA, npcB; 

    public void CheckScenario(int dec)
    {
        npcA.SetActive(dec == 0);
        npcB.SetActive(dec == 1);
    }
}
