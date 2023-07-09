using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroItemManager : MonoBehaviour
{
    [SerializeField] GameObject helmetObj, chestPlateObj, swordObj; // our objects to turn on and off
    [SerializeField] List<GameObject> pants; // our pants objects

    public enum Items
    {
        none, helmet, chestPlate, sword, pants
    }

    public Items testItem;

    private void FixedUpdate()
    {
        if (testItem != Items.none)
            EnableItem(testItem);
    }

    public void EnableItem(Items item)
    {
        switch ((int)item)
        {
            case (int)Items.helmet:
                helmetObj.SetActive(true);
                break;

            case (int)Items.chestPlate:
                chestPlateObj.SetActive(true);
                break;

            case (int)Items.sword:
                swordObj.SetActive(true);
                break;

            case (int)Items.pants:
                foreach (GameObject pant in pants)
                    pant.SetActive(true);
                break;
        }
    }
}
