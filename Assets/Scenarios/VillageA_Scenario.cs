using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageA_Scenario : Scenario
{
    void Awake()
    {
        NarratorText = "Our hero would not be a hero if they weren't able to protect the innocent. Fortunately for them their chance to prove themselves is nigh at hand!"
        + " The (Adjective) village: Tora Town, just left of middle of nowhere and just right of the sticks." 
        + " With the kingdom preoccupied they've come under the harassment of a party of slimes. Slimes who (Verb) any human they see.\n"
        + " \"There's only way to defeat these slimes,\" an elder of the village tells the Hero. \"You must take this (Noun) and use it to (Verb) the slimes.\""
        + " When the Hero questioned why the villagers could not do this, the elder had to leave citing \"I left my keys back at my hut.\"";

        AnnoyedResponse = "Things to not have on a Hero resume: Lost or gave up to a group of slimes. Our hero is truly making themselves out to be the greatest ever!";

        MildAnnoyedResponse = "Though the battle was one, the villagers of Tora Town were treated to quite a sticky show which can describe as a fish flopping in a bucket of syrup. Words truly don't do the spectacle justice.";

        NonAnnoyedResponse = "Because our hero is boring and stupid and boring and no fun, the battle was over in a matter of moments. Depriving the denizens of Tora Town any semblance of a show.";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
        NarratorText = "Our hero would not be a hero if they weren't able to protect the innocent. Fortunately for them their chance to prove themselves is nigh at hand!"
        + "The " + Inputs[0] + " village: Tora Town, just left of middle of nowhere and just right of the sticks." 
        + " With the kingdom preoccupied they've come under the harassment of a party of slimes. Slimes who " + Inputs[1] + " any human they see.\n"
        + " \"There's only way to defeat these slimes,\" an elder of the village tells the Hero. \"You must take this " + Inputs[2] + " and use it to " + Inputs[3] + " the slimes.\""
        + " When the Hero questioned why the villagers could not do this, the elder had to leave citing \"I left my keys back at my hut.\"";
    }
}
