﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class InteractEvent : MonoBehaviour, IEnteredEvent
{
    public DialogueTargetClass dialogueTargetClass;

    //Determines if the event is upon entrance
    public bool enterEvent = false;

    //Level Requirement Items
    public Vector2 newPlayerPosition;
    public Vector3 newCameraPosition;
    public Level level;
    public AudioSource levelMusic;
    public bool dynamicCameraHorizontal = false;
    public float cameraLeftThreshold;
    public float cameraRightThreshold;
    public float cameraSize = 10.0f;
    public GameController gameController;

    private GameEventManager manager;
    private Platformer2DUserControl user;
    private bool interactable = false;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        manager = transform.parent.GetComponent<GameEventManager>();
        user = manager.player.GetComponent<Platformer2DUserControl>();
    }

    protected void Subscribe()
    {
        GameController.Interact += ConditionallyTriggerEvent;
    }

    public virtual void TriggerEvent()
    {
        gameController.StartDialogueEvent();
    }

    private void ConditionallyTriggerEvent()
    {
        if (interactable)
        {
            TriggerEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!enterEvent)
            {
                interactable = true;
                if (manager != null)
                {
                    manager.EnteredEvent();
                }
                else
                {
                    manager = transform.parent.GetComponent<GameEventManager>();
                }
            }
            else
            {
                TriggerEvent();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactable = false;
            if (manager != null)
            {
                manager.ExitedEvent();
            }
            else
            {
                manager = transform.parent.GetComponent<GameEventManager>();
            }
        }
    }
}
