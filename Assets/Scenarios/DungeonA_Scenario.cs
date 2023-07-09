using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonA_Scenario : Scenario
{
    void Awake()
    {
        NarratorText = "Hearing rumors of a even more legendary sword which would hold the power to (Verb) its foes, Our hero enters an ancient crypt."
        + "Apparently the sword previously provided was not up to snuff. The crypt is filled with with countless skeletons, each frothing at the chance" +
        "to (Verb) any soul foolish enough to enter these decrepit halls. If there hero is to make it out alive, they must remain ever vigilant.";

        AnnoyedResponse = "Rather than wasting their oh-so valuable time. Our hero laments that they were in fact a foolish soul." +
        "Foolish enough to waste their time for a sword that might not have even been all that.";

        MildAnnoyedResponse = "Despite their best efforts, the skeletons could not dissuade our persistent hero." +
        "Our hero, surely relishing in the displeasure the powers at be must be feeling, collected the legendary sword and continued onward in their quest.";

        NonAnnoyedResponse = "Proving maddenling stubborn in their resolve, our hero collects the legendary blade. Leaving the halls of the crypt lined with the shattered bones of the skeletal masses.Oh the horror.";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
        NarratorText = "Hearing rumors of a even more legendary sword which would hold the power to"+ Inputs[0] + "its foes, Our hero enters an ancient crypt."
        + "Apparently the sword previously provided was not up to snuff. The crypt is filled with with countless skeletons, each frothing at the chance to"
        + Inputs[1] + "any soul foolish enough to enter these decrepit halls. If there hero is to make it out alive, they must remain ever vigilant.";
    }
}
