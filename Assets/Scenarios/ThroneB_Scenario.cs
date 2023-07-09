using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroneB_Scenario : Scenario
{
   void Awake()
    {
        NarratorText = "After a long, very long and perilous journey, Our hero finally made it to the kingdom."
        + " Citizens in hiding welcomed the hero and followed our hero to the castle (from a safe distance of course.)." +
        " Inside the castle walls our hero comes face to face with the Evil Overlord. \"So you think you can stop me,\" the Overlord taunts."
        + " The Hero Charges towards the Overlord. The clash is legendary. So much headache, so many difficulties. And it was all worth it."
        + " With a mighty swing of their sword the Overlord is slain. Peace is restored to the kingdom. The hero basks in the glory and the admiration of the kingdom."
        + " Their quest is complete.";

        AnnoyedResponse = "";

        MildAnnoyedResponse = "";

        NonAnnoyedResponse = "";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
       NarratorText = "After a long, very long and perilous journey, Our hero finally made it to the kingdom."
        + " Citizens in hiding welcomed the hero and followed our hero to the castle (from a safe distance of course.)." +
        " Inside the castle walls our hero comes face to face with the Evil Overlord. \"So you think you can stop me,\" the Overlord taunts."
        + " The Hero Charges towards the Overlord. The clash is legendary. So much headache, so many difficulties. And it was all worth it."
        + " With a mighty swing of their sword the Overlord is slain. Peace is restored to the kingdom. The hero basks in the glory and the admiration of the kingdom."
        + " Their quest is complete.";
    }
}
