using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeB_Scenario : Scenario
{
   void Awake()
    {
        NarratorText = "From a distance, the mushrooms surrounding the lake are true sight to behold. The same can not be said for seeing them up close."
        + " They puff out spores with whimsical side effects, most notably they (Verb) anyone who breathe them in.\n"
        + " But the mushroom spores are the least of anyone traversing the lake's problems. Deep between the fungal growths (Adjective) slimes stroll, patrolling their territory. "
        + " With their round heads and long legs, they're quite the sight. Alas, Our Hero, encountering a group of slimes prepares to exterminate them."
        + " You might be wondering how do you exterminate a gelatinous mass with legs. Look to our hero and see how they try to (Verb) them with a (Noun)";

        AnnoyedResponse = "The sweet treat of seeing the pure unapologetic disappointment in our heros eyes will surely be remembered for eons in the future.";

        MildAnnoyedResponse = "A vendetta formed today. Though Our Hero prevailed, they'll remember the inconveniences of this battle for years to come. If they don't give up by then...";

        NonAnnoyedResponse = "Of course any hero worth their salt can handle a group of slimes. Our hero is unfortunately one such hero.";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
        NarratorText = "From a distance, the mushrooms surrounding the lake are true sight to behold. The same can not be said for seeing them up close."
        + " They puff out spores with whimsical side effects, most notably they " + Inputs[0] + " anyone who breathe them in.\n"
        + " But the mushroom spores are the least of anyone traversing the lake's problems. Deep between the fungal growths " +  Inputs[1] + " slimes stroll, patrolling their territory."
        + " With their round heads and long legs, they're quite the sight. Alas, Our Hero, encountering a group of slimes prepares to exterminate them."
        + " You might be wondering how do you exterminate a gelatinous mass with legs. Look to our hero and see how they try to" + Inputs[2] + " them with a " + Inputs[3] + ".";
    }
}
