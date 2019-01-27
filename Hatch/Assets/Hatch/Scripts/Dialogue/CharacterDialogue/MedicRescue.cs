﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicRescue : MonoBehaviour {

    public bool medicRescued = false;
    private DialogueManager manager;
    private DialogueObject[] objectiveDialogue;
    private DialogueObject completedDialogue;
    private int conversationCount;
    private MedicRescueDialogueEvent medicEvent;
    private bool conversationEnsues = false;

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        medicEvent = GameObject.Find("MedicRescueDialogue").GetComponent<MedicRescueDialogueEvent>();
        completedDialogue = new DialogueObject(DialogueTarget.Medic, "Thanks again, see you back at the train!", .04f, Emotions.Idle);
        objectiveDialogue = new DialogueObject[]
        {
            new DialogueObject(DialogueTarget.Medic, "OH MAN, THAT REALLY SMARTS!", .1f, Emotions.Angry),
            new DialogueObject(DialogueTarget.Medic, "I guess it's a good thing I went to med school after my daughter was born huh?", .04f, Emotions.Idle),
            new DialogueObject(DialogueTarget.You, "Yeah, I guess..", .1f, Emotions.Idle),
            new DialogueObject(DialogueTarget.Medic, "Well I really appreciate it, I can't let my baby lose her daddy that easily!", .04f, Emotions.Idle)
        };
        InteractEvent.StartDialogue += StartDialogue;
        GameController.NextDialogue += NextDialogue;
	}

    private void StartDialogue()
    {
        if (medicEvent.isActivated)
        {
            conversationEnsues = true;
            conversationCount = 0;
            if (!GameStates.States[GameStates.MEDIC])
            {
                manager.StartDialogue(objectiveDialogue[0]);
            }
            else
            {
                manager.StartDialogue(completedDialogue);
            }
        }
    }

    private void NextDialogue()
    {
        if (conversationEnsues)
        {
            if (!GameStates.States[GameStates.MEDIC])
            {
                if (conversationCount > 2)
                {
                    GameStates.States[GameStates.MEDIC] = true;
                    manager.EndDialogue();
                }
                else
                {
                    conversationCount++;
                    manager.DisplayNextSentence(objectiveDialogue[conversationCount]);
                }
            }
        }
    }
}
