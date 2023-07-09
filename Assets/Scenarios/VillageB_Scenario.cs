using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageB_Scenario : Scenario
{
    void Awake()
    {
        NarratorText = "Slimes have a nasty habit of harassing the outlying villages of the kingdom. Especially (Adjective) slimes who have a taste for causing chaos for poor innocent villagers."
        + " Subjecting them to all kinds of heinous deeds, like (Verb)ing them.\n"
        + " Not to be turned away from a challenge our Hero, thinking they have the right tools for the job, pulls out their trusty (Noun) so they can (Verb) these devilish slimes."
        + " It was at that moment the Hero realized they had never seen a slime before, with their (Adjective) legs that really made the hero feel some type of way.";

        AnnoyedResponse = "There are moments when you have to ask yourself: is battling grotesque slimes with human proportioned legs worth it? The Hero didn't seem to think and left the village to the Slime's devices and with their dignity in shambles.";

        MildAnnoyedResponse = "The sight of walking slimes aside, the battle proved relatively simple. Our hero found themselves at  the end of more kicks than they could've ever expected. A win's a win though right? Right?";

        NonAnnoyedResponse = "Nothing sways our hero away from their quest. Nothing! Not even slimes with oddly human legs!";

        _inputs = new List<string>();
    }

    public override void ProcessOutputText ()
    {
        NarratorText = "Slimes have a nasty habit of harassing the outlying villages of the kingdom. Especially " 
        + Inputs[0] + " slimes who have a taste for causing chaos for poor innocent villagers."
        + " Subjecting them to all kinds of heinous deeds, like " + Inputs[1] + "ing them.\n"
        + " Not to be turned away from a challenge our Hero, thinking they have the right tools for the job, pulls out their trusty " + Inputs[2] 
        + " so they can " + Inputs[3] + " these devilish."
        + " It was at that moment the Hero realized they had never seen a slime before, with their " + Inputs[4]+ " legs that really made the hero feel some type of way.";
    }
}
