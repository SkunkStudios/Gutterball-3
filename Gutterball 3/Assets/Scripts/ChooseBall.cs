using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChooseBall
{
    public enum LockType { None, Score, Spare, Beat, Earn, Custom }
    public string ballName;
    public LockType lockType;
    public int totalLock;
    public string CPUName;
    public Material ballMat;
    [Range(8, 16)]
    public int lbs = 12;
    [Range(10, 100)]
    public int speed = 55;
    [Range(0, 100)]
    public int spin = 50;
    public int isLock;
    public string urlTextureBall;
}
