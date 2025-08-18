using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{

    public static Action<int> EventOn;

    public static Action<bool> LiftOn;

    public static Action LiftLift;

    public static Action DecentLift;

    public static Action<Vector3> OnGoingPoint;
    public static bool goingPointIsActive;
    public static float chaseRange;

    public static Action OnSaveGame;
    public static Action OnLoadGame;
    public static Action OnResetGame;

    public static Action<bool> OnHide;

}
