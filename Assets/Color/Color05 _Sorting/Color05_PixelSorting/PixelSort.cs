using mj.gist;
using UnityEngine;

public class PixelSort : SortEffect {
    [Range(0, 1), SerializeField] private float lumaMin = 0.25f;
    [Range(0, 1), SerializeField] private float lumaMax = 0.5f;

    protected override void Start() {
        base.Start();
        UpdateTexture();
    }
    private void UpdateTexture() {
        if (result == null) return;
        //Copy
        cs.SetTexture(0, "_Source", tex);
        cs.SetTexture(0, "_Result", result);
        cs.DispatchThreads(0, tex.width, tex.height, 1);

        // Sort
        cs.SetTexture(1, "_Sort", result);
        cs.SetInt("_Mode", 0);
        cs.SetVector("_Threshold", new Vector2(lumaMin, lumaMax));
        cs.DispatchThreads(1, tex.height, 1, 1);
    }
    private void OnValidate() {
        UpdateTexture();
    }
}
