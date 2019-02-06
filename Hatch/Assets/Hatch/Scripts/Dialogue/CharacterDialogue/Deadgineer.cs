﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadgineer : MonoBehaviour
{
    public DialogueManager manager;
    private DialogueObject[] objectiveDialogue;
    private DialogueObject[] completedDialogue;
    private int conversationCount;
    private DeadgineerDialogue deadgineerEvent;
    private bool conversationEnsues = false;

    // Use this for initialization
    void Start()
    {
        deadgineerEvent = GameObject.Find("DeadgineerDialogue").GetComponent<DeadgineerDialogue>();
        completedDialogue = new DialogueObject[]
        {
            new DialogueObject(DialogueTarget.Engineer, "...", 1.0f, Emotions.Idle, null)
        };
        objectiveDialogue = new DialogueObject[]
        {
            new DialogueObject(DialogueTarget.Player, "...", 0.5f, Emotions.Idle, null),
            new DialogueObject(DialogueTarget.Engineer, "...", 1.0f, Emotions.Idle, null)
        };
        GameController.StartDialogue += StartDialogue;
        GameController.NextDialogue += NextDialogue;
        GameController.CancelDialogue += EndDialogue;
    }

    private void StartDialogue()
    {
        if (deadgineerEvent.isActivated)
        {
            conversationEnsues = true;
            conversationCount = 0;
            manager.StartDialogue(objectiveDialogue[0]);
        }
    }

    private void NextDialogue()
    {
        if (conversationEnsues)
        {
            if (manager.typeSentenceActive)
            {
                manager.FinishSentence(objectiveDialogue[conversationCount]);
            }
            else
            {
                conversationCount++;
                if (conversationCount > 1)
                {
                    EndDialogue();
                }
                else
                {
                    manager.DisplayNextSentence(objectiveDialogue[conversationCount]);
                }
            }
        }
    }

    private void EndDialogue()
    {
        if (conversationCount > 1)
        {
            deadgineerEvent.isActivated = false;
            manager.EndDialogue();
        }
    }
}