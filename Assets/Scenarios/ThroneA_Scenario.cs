using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroneA_Scenario : Scenario
{
   void Awake()
    {
        NarratorText = "After a long, very long and perilous journey, Our hero finally made it to the kingdom."
        + " Citizens in hiding welcomed the hero and followed our hero to the castle (from a safe distance of course.)." +
        " Inside the castle walls our hero comes face to face with the Evil Overlord. \"So you think you can stop me,\" the Overlord taunts."
        + "But the hero remains silent. \"A man of few words?  Perfect we can get right to it,\" The Overlord says, raising their arms calling their henchman to the throne room."
        + " Our hero surveys the room, each monster sizing them up, waiting to pounce. But the Hero does not attack. Instead, with a deep sigh, the Hero takes off their armor and sword, dropping to the floor, and leaves."
        + " The Evil Overlord tries to speak but doesn't know what to say. The hero has given up. Off to return from whence they came. Evil has prevailed, the journey...was simply too annoying.";

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
        + "But the hero remains silent. \"A man of few words?  Perfect we can get right to it,\" The Overlord says, raising their arms calling their henchman to the throne room."
        + " Our hero surveys the room, each monster sizing them up, waiting to pounce. But the Hero does not attack. Instead, with a deep sigh, the Hero takes off their armor and sword, dropping to the floor, and leaves."
        + " The Evil Overlord tries to speak but doesn't know what to say. The hero has given up. Off to return from whence they came. Evil has prevailed, the journey...was simply too annoying.";
    }
}
