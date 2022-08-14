using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulePatternsEffect : VFXEffectBase {
    [SerializeField] private int tilesCount = 6;
    [SerializeField] private int count = 10;
    private int pattern = 0;

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            tilesCount++;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            tilesCount--;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            count++;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            count--;
        if (Input.GetMouseButtonDown(0))
            pattern = (++pattern) % 2;

        graph.SetInt("TilesCount", tilesCount);
        graph.SetInt("Count", count);
        graph.SetInt("Pattern", pattern);
    }
}
