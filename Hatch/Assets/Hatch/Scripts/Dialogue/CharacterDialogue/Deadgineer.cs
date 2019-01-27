﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadgineer : MonoBehaviour
{
    public DialogueManager manager;
    private DialogueObject[] objectiveDialogue;
    private DialogueObject completedDialogue;
    private int conversationCount;
    private DeadgineerDialogue deadgineerEvent;
    private bool conversationEnsues = false;
    //private int conversationCount;

    // Use this for initialization
    void Start()
    {
        deadgineerEvent = GameObject.Find("DeadgineerDialogue").GetComponent<DeadgineerDialogue>();
        completedDialogue = new DialogueObject(DialogueTarget.Engineer, "...", 1.0f, Emotions.Idle);
        objectiveDialogue = new DialogueObject[]
        {
            new DialogueObject(DialogueTarget.Player, "...", 0.5f, Emotions.Idle),
            new DialogueObject(DialogueTarget.Engineer, "...", 1.0f, Emotions.Idle)/*,
            new DialogueObject(DialogueTarget.You, "Huh, looks like he has some sort of key card on him.", .1f, Emotions.Idle)*/
        };
        InteractEvent.StartDialogue += StartDialogue;
        GameController.NextDialogue += NextDialogue;
        GameController.CancelDialogue += EndDialogue;
    }

    private void StartDialogue()
    {
        if (deadgineerEvent.isActivated)
        {
            conversationEnsues = true;
            conversationCount = 0;
            //if (!GameStates.States[GameStates.CARD])
            //{
                manager.StartDialogue(objectiveDialogue[0]);
            //}
            //else
            //{
            //    manager.StartDialogue(completedDialogue);
            //}
        }
    }

    private void NextDialogue()
    {
        if (conversationEnsues)
        {
            //if (!GameStates.States[GameStates.CARD])
            //{
                if (conversationCount > 1 /*2*/)
                {
                    //GameStates.States[GameStates.CARD] = true;
                    EndDialogue();
                }
                else
                {
                    conversationCount++;
                    manager.DisplayNextSentence(objectiveDialogue[conversationCount]);
                }
            //}
        }
    }

    private void EndDialogue()
    {
        if (conversationCount > 1 /*2*/)
        {
            //GameStates.States[GameStates.CARD] = true;
            manager.EndDialogue();
        }
    }
}