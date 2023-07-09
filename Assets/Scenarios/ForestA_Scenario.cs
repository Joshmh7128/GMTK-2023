using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestA_Scenario : Scenario
{
    void Awake()
    {
        NarratorText = "The serene forest. So peaceful. So elegant. What quest is complete without the inaugural journey into the mystical forest.\n"
        + "Deep in an isolated grotto, lies a secret order of (Adjective) fairies awaiting for a call."
        + " Our hero also seems to think their call is the one the order is waiting for. Powerful in their ways of magic, they would prove powerful allies to our hero."
        + " But the order requires convincing. A trail, of (Adjective) proportions. Our hero must (Verb) the strongest fairy warrior.";

        AnnoyedResponse = "Rather than indulging in an unruly trial. Our hero shows their true colors: a lazy oaf who isn't cut out for the hero business. They will simply have to find allies elsewhere.";

        MildAnnoyedResponse = "In the future the Hero will be asked how they overcame the fairies' trial. The Hero wont answer, simply staring off into the distance. The memory clearly to much to remember.";

        NonAnnoyedResponse = "Proving maddenling stubborn in their resolve, our hero collects the legendary blade. Leaving the halls of the crypt lined with the shattered bones of the skeletal masses.Oh the horror.";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
        NarratorText = "The serene forest. So peaceful. So elegant. What quest is complete without the inaugural journey into the mystical forest.\n"
        + "Deep in an isolated grotto, lies a secret order of " + Inputs[0] + " fairies awaiting for a call."
        + " Our hero also seems to think their call is the one the order is waiting for. Powerful in their ways of magic, they would prove powerful allies to our hero."
        + " But the order requires convincing. A trail, of " + Inputs[1] + " proportions. Our hero must " + Inputs[2] + " the strongest fairy warrior.";
    }
}
