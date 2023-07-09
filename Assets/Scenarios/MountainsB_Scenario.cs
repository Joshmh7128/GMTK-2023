using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainsB_Scenario : Scenario
{
   void Awake()
    {
        NarratorText = "Resisting the temptation to curl into a small pathetic ball and keep warm, our dedicated hero heads onward through the mountain pass.\n"
        + "\"The cold is only temporary,\" the Hero says. \"The glory will be forever.\" Oh how vain.\n"
        + " Rounding the path, the Hero can see the castle in the horizon, perhaps one more days travel."
        + " Suddenly, a Troll jumps erupts in a puff a smoke, blocking the hero's pass.\n"
        + "Not to be dismayed by a troll, our hero pulls out his trusty (Noun)! With it the Hero (Verb)s the troll.";

        AnnoyedResponse = "The Hero will try to deny that the Troll was too cumbersome to defeat, but the hero is not the one telling this story, so everyone will know.";

        MildAnnoyedResponse = "Not wanting to admit the challenge of the battle, the Hero quickly leaves the scene with more bruises than anticipated.";

        NonAnnoyedResponse = "With the troll taken care of, Our hero prances down the mountain towards their final destination: The Castle!";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
        NarratorText = "Resisting the temptation to curl into a small pathetic ball and keep warm, our dedicated hero heads onward through the mountain pass.\n"
        + " \"The cold is only temporary,\" the Hero says. \"The glory will be forever.\" Oh how vain.\n"
        + " Rounding the path, the Hero can see the castle in the horizon, perhaps one more days travel. "
        + "Suddenly, a Troll jumps erupts in a puff a smoke, blocking the hero's pass.\n"
        + "Not to be dismayed by a troll, our hero pulls out his trusty " + Inputs[0] + "! With it the Hero " + Inputs[0] + "s the troll.";
    }
}
