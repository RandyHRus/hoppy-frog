using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static GameStates gameState;
}

public enum GameStates
{
    playing, notPlaying
}