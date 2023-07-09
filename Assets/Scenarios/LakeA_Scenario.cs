using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeA_Scenario : Scenario
{
    
    void Awake()
    {
        NarratorText = "From a distance, the mushrooms surrounding the lake are true sight to behold. The same can not be said for seeing them up close."
        + " They puff out spores with whimsical side effects, most notably they (Verb) anyone who breathe them in.\n"
        + " Fortunately, our bonehead hero is unaware of this, and so marches totally unaware through the mushrooms on their way to the lake. "
        + " Why go to the lake one might ask? A by the lake holds a (Adjective) piece of armor.\n"
        + "The Hero believes it will grant them a great strength on their quest. But in reality the piece of armor allows the wearer to summon a (Noun) that can exclusively (Verb).";

        AnnoyedResponse = "The sweet treat of seeing the pure unapologetic disappointment in our heros eyes will surely be remembered for eons in the future.";

        MildAnnoyedResponse = "Though the amor wasn't everything, the hero was able to find some meaningful purpose for the ";

        NonAnnoyedResponse = "Instead of a suite of armor that would have frustrated a sane person, our looney of a hero decided the armor had some use to it.  Oh the horror imagining what they might do with it.";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
        NarratorText = "From a distance, the mushrooms surrounding the lake are true sight to behold. The same can not be said for seeing them up close."
        + " They puff out spores with whimsical side effects, most notably they " + Inputs[0] + " anyone who breathe them in.\n"
        + "Fortunately, our bonehead hero is unaware of this, and so marches totally unaware through the mushrooms on their way to the lake.\n"
        + "Why go to the lake one might ask? A by the lake holds a " + Inputs[1] + " piece of armor."
        + " The Hero believes it will grant them a great strength on their quest. But in reality the piece of armor allows the wearer to summon a " + Inputs[2] + " that can exclusively " + Inputs[3] + ".";
    }
}
