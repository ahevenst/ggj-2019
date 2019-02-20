﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class MysteryManIntro : MonoBehaviour
{
    public DialogueManager manager;
    private DialogueObject[] objectiveDialogue;
    private DialogueObject[] completedDialogue;
    private int conversationCount;
    private DialogueEvent medicEvent;
    private bool conversationEnsues = false;
    private AudioSource talkClip;
    private AudioSource playerClip;

    // Use this for initialization
    void Start()
    {
        medicEvent = GameObject.Find("MedicRescueDialogue").GetComponent<DialogueEvent>();
        talkClip = gameObject.GetComponent<AudioSource>();
        playerClip = GameObject.Find("Player_Wireframe").GetComponentInChildren<AudioSource>();
        completedDialogue = new DialogueObject[]
        {

        };
        objectiveDialogue = new DialogueObject[]
        {
            new DialogueObject(DialogueTarget.MysteryMan, "Oh my, what a shattered state to find you in.", .06f, Emotions.Idle, talkClip),
            new DialogueObject(DialogueTarget.MysteryMan, "All of these fragments will take great care to piece together.", .06f, Emotions.Idle, talkClip),
            new DialogueObject(DialogueTarget.MysteryMan, "Shall we take a look?", .08f, Emotions.Idle, talkClip),
            new DialogueObject(DialogueTarget.MysteryMan, "I have always found your kind to be so.. delicate", .08f, Emotions.Idle, talkClip),
            new DialogueObject(DialogueTarget.MysteryMan, "Like absence versus thin air", .08f, Emotions.Idle, talkClip),
            new DialogueObject(DialogueTarget.MysteryMan, "I think it is time for you to collect your thoughts..", .06f, Emotions.Idle, talkClip),
            new DialogueObject(DialogueTarget.MysteryMan, "Perhaps I will see you up ahead.", .06f, Emotions.Idle, talkClip)
        };
    }

    public void StartDialogue(GameObject dialogueTarget)
    {
        conversationEnsues = true;
        conversationCount = 0;
        StaticEvent.StartDialogue(gameObject, true);
        manager.StartDialogue(objectiveDialogue[0]);
    }

    public void NextDialogue()
    {
        conversationCount++;
        manager.DisplayNextSentence(objectiveDialogue[conversationCount]);
    }

    public void EndDialogue()
    {
        manager.EndDialogue();
    }
}