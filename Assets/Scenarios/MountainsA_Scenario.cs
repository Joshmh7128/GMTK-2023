using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainsA_Scenario : Scenario
{
   void Awake()
    {
        NarratorText = "Nearing the end of their quest, our hero summits the perilous Waka-Gloria Mountains, the remnants of continents clashing."
        + " Trying to stay warm our hero searches for a the helm of (Noun): A helmet said to grant the wearer the ability to (Verb).\n"
        + " Believed to be housed in a shrine on the tallest peak, our hero must make every effort to stay warm."
        + " Conjuring a genius plan to stay warm, the hero begins (Verb)ing. They can practically taste the helmet.";

        AnnoyedResponse = "Surely reaching a metaphorical limit,the disgruntled hero tosses the impractical helmet over the side of the mountain.";

        MildAnnoyedResponse = "Letting the hype get to them, the hero is disappointed to see the helmet is not in fact all that. False promises and what have you.";

        NonAnnoyedResponse = "Adding yet another trophy to their arsenal, and so proud of their accomplishment to thwart any attempts to derail this quest, Our hero prances back down the mountain. Final destination: The Castle!";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
        NarratorText = "Nearing the end of their quest, our hero summits the perilous Waka-Gloria Mountains, the remnants of continents clashing."
        + " Trying to stay warm our hero searches for a the helm of " +  Inputs[0] + ": A helmet said to grant the wearer the ability to" + Inputs[1] + "\n"
        + " Believed to be housed in a shrine on the tallest peak, our hero must make every effort to stay warm."
        + " Conjuring a genius plan to stay warm, the hero begins " + Inputs[2] + "ing. They can practically taste the helmet.";
    }
}
