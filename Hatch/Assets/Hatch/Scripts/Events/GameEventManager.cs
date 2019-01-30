﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour {
    public GameObject player;
    public delegate void InteractTextAction();
    public static event InteractTextAction OnEntered;
    public static event InteractTextAction OnExited;

    public void EnteredEvent()
    {
        if (OnEntered != null)
        {
            OnEntered();
        }
    }

    public void ExitedEvent()
    {
        if (OnExited != null)
        {
            OnExited();
        }
    }
}
