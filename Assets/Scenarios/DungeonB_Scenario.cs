using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonB_Scenario : Scenario
{
    void Awake()
    {
        NarratorText = "Despite warnings from the local population, our hero, who apparently knows no fear, makes their way into the old dungeon of an ancient necromancer."
        + " A necromancer so powerful in its ability to churn the dead that in another time might have served as the antagonist to our Hero." +
        " Unfortunately, this is not that story. But the ancient necromancer will still prove formidable, able to imbue their skeletal army with the ability to (Verb).\n"
        + "Why is the hero nonchalantly wandering into someone else's property you might ask? Why to commit robbery of course!"
        + " The Ancient Necromancer wears pants that would allow our hero to (Verb). A skill necessary to save the kingdom!";

        AnnoyedResponse = "Though they took the ring. The hero couldn't even muster the enthusiasm to put it on and try the spectacular power that came with it. Talk about being ungrateful.";

        MildAnnoyedResponse = "Not wanting to admit defeat, the hero begrudgingly takes the pants off the necromancer, disregarding any hygiene, and puts them on. Because our hero really deserved this.";

        NonAnnoyedResponse = "Commoners would describe the battle as legendary. Though in reality it was like a petulant slap fight between a so-called hero and a powerful being too caught off guard to really do anything. Ring in hand our hero excitedly rushes onward in their quest.";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
        NarratorText = "Despite warnings from the local population, our hero, who apparently knows no fear, makes their way into the old dungeon of an ancient necromancer."
        + "A necromancer so powerful in its ability to churn the dead that in another time might have served as the antagonist to our Hero." +
        " Unfortunately, this is not that story. But the ancient necromancer will still prove formidable, able to imbue their skeletal army with the ability to " + Inputs[0]
        + ".\n Why is the hero nonchalantly wandering into someone else's property you might ask? Why to commit robbery of course!"
        + "The Ancient Necromancer wears pants that would allow our hero to " + Inputs[1] + ". A skill necessary to save the kingdom!";
    }
}
