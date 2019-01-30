﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public delegate void InteractAction();
    public static event InteractAction Interact;
    public static event InteractAction InteractActive;
    public static event InteractAction InteractInactive;
    public delegate void CancelDialogueAction();
    public static event CancelDialogueAction CancelDialogue;
    public delegate void FinishKeypadAction();
    public static event FinishKeypadAction FinishKeypad;
    public delegate void EndDialogueAction();
    public static event EndDialogueAction EndDialogue;
    public delegate void NextDialogueAction();
    public static event NextDialogueAction NextDialogue;
    public delegate void CancelJumpAction();
    public static event CancelJumpAction CancelJump;
    public delegate void StopPlayerAction();
    public static event StopPlayerAction StopPlayer;
    public delegate void StartPlayerAction();
    public static event StartPlayerAction StartPlayer;
    public delegate void StartDialogueAction();
    public static event StartDialogueAction StartDialogue;

    public void StopCharacter()
    {
        if (StopPlayer != null)
        {
            StopPlayer();
        }
    }

    public void StartCharacter()
    {
        if (StartPlayer != null)
        {
            StartPlayer();
        }
    }

    public void InteractEvent()
    {
        if (Interact != null)
        {
            Interact();
        }
    }

    public void InteractActiveEvent()
    {
        if (InteractActive != null)
        {
            InteractActive();
        }
    }

    public void InteractInactiveEvent()
    {
        if (InteractInactive != null)
        {
            InteractInactive();
        }
    }

    internal void EscapeFunctionsEvent()
    {
        CancelDialogue();
        FinishKeypadEvent();
    }

    internal void CancelDialogueEvent()
    {
        if (CancelDialogue != null)
        {
            CancelDialogue();
            InteractActiveEvent();
            StartCharacter();
        }
    }

    public void FinishKeypadEvent()
    {
        if (FinishKeypad != null)
        {
            FinishKeypad();
            StartCharacter();
        }
    }

    internal void EndDialogueEvent()
    {
        if (EndDialogue != null)
        {
            EndDialogue();
            StartCharacter();
        }
    }

    internal void NextDialogueEvent()
    {
        if (NextDialogue != null)
        {
            NextDialogue();
        }
    }

    internal void CancelJumpEvent()
    {
        if (CancelJump != null)
        {
            CancelJump();
        }
    }

    public void StartDialogueEvent()
    {
        if (StartDialogue != null)
        {
            StartDialogue();
            InteractInactiveEvent();
            StopCharacter();
        }
    }
}
