using System;
using UnityEngine;

[Serializable]
public struct IntRange
{
    public int Min;
    public int Max;

    public int GetRandom()
    {
        return UnityEngine.Random.Range(Min, Max);
    }
}