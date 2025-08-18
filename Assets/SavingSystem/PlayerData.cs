using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health = 3;
    public int[] itemNumbers;
    public float[] itemPositionX;
    public float[] itemPositionY;
    public float[] itemPositionZ;
    public int bulletAmount;
    public bool bellAlarmOff;
}
