using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSetter : VFXEffectBase
{
    [SerializeField] private int patternCount;
    [SerializeField] private int currentPattern;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            currentPattern = (++currentPattern) % patternCount;
        graph.SetInt("Pattern", currentPattern);
    }
}
