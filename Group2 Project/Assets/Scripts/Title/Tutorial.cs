using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tutorial
{
    [Tooltip("����")]
    public string[] contexts;
}

[System.Serializable]
public class TutorialEvent
{
    public Tutorial[] tutorials;
    public Vector2 line;
}