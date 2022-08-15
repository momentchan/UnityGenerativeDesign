using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternShapesEffect : VFXEffectBase
{
    [SerializeField] private int CurrentTilesCountX = 5;
    [SerializeField] private int CurrentTilesCountY = 5;

    private const int MAX_TILES_COUNT = 20;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            CurrentTilesCountY = Mathf.Clamp(++CurrentTilesCountY, 1, MAX_TILES_COUNT);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            CurrentTilesCountY = Mathf.Clamp(--CurrentTilesCountY, 1, MAX_TILES_COUNT);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            CurrentTilesCountX = Mathf.Clamp(++CurrentTilesCountX, 1, MAX_TILES_COUNT);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            CurrentTilesCountX = Mathf.Clamp(--CurrentTilesCountX, 1, MAX_TILES_COUNT);

        graph.SetInt("TilesCountX", CurrentTilesCountX);
        graph.SetInt("TilesCountY", CurrentTilesCountY);
    }
}
