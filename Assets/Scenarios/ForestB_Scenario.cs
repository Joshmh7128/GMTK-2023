using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestB_Scenario : Scenario
{
    void Awake()
    {
        NarratorText = "In any quest, the adventurer must eventually encounter their first goblin horde."
        + " Thinking themselves exempt from this rule, our hero haphazardly journeys into the serene forest."
        + " Without a care in the world they (Verb) along the forest path. Everything was going swimmingly, until our (Adjective) Hero stumbled right into a goblin ambush.\n"
        + "Back against the wall, the gullible hero pulls out spell tome, allowing them to (Verb) the goblins.";

        AnnoyedResponse = "Our hero learned a valuable lesson in picking your battles. Maybe now this troublesome do-gooder will finally abandon their quest.";

        MildAnnoyedResponse = "Our hero underestimated how tedious a battle with a goblin horde would be. Maybe if they hadn't embarked on this quest in the first place they would have avoided this all together.";

        NonAnnoyedResponse = "Thinking themselves better than their goblin foes, Our hero makes quick work to get past the goblin ambush.";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
        NarratorText = "In any quest, the adventurer must eventually encounter their first goblin horde."
        + " Thinking themselves exempt from this rule, our hero haphazardly journeys into the serene forest."
        + " Without a care in the world they " + Inputs[0] + " along the forest path. Everything was going swimmingly, until our " + Inputs[1] + 
        "Hero stumbled right into a goblin ambush.\n"
        + "Back against the wall, the gullible hero pulls out spell tome, allowing them to " +  Inputs[2] + " the goblins.";
    }
}
