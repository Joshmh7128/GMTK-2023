using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario_DungeonA : Scenario
{
    // needs inputs, template, output
    // our default text block featuring the text in the form including ex: "(VERB)"
    private void Awake()
    {
        NarratorText = "Hearing rumors of a even more legendary sword which would hold the power to (Verb) its foes, " +
"Our hero enters an ancient crypt. Apparently the sword previously provided was not up to snuff. The crypt is filled with with countless skeletons, " +
"each frothing at the chance to (Verb) any soul foolish enough to enter these decrepit halls. If there hero is to make it out alive, they must remain ever vigilant. ";
    }
    // our text featuring our inputs, ex: "inputs[0]"
    // use this to return the correct output text
    public override string ProcessOutputText()
    {
        return "Hearing rumors of a even more legendary sword which would hold the power to" + inputs[0] + "its foes, " +
 "Our hero enters an ancient crypt. Apparently the sword previously provided was not up to snuff. The crypt is filled with with countless skeletons, " +
 "each frothing at the chance to " + inputs[1] + " any soul foolish enough to enter these decrepit halls. If there hero is to make it out alive, they must remain ever vigilant. ";
    }

}
