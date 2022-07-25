using mj.gist;
using UnityEngine;

public class HSVSort : SortEffect {
    [SerializeField] private SortMode currentMode;

    protected override void Start() {
        base.Start();

        UpdateTexture(SortMode.None);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            UpdateTexture(SortMode.None);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            UpdateTexture(SortMode.Hue);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            UpdateTexture(SortMode.Saturation);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            UpdateTexture(SortMode.Value);
    }

    private void UpdateTexture(SortMode mode) {
        if (currentMode == mode) return;
        currentMode = mode;

        //Copy
        cs.SetTexture(0, "_Source", tex);
        cs.SetTexture(0, "_Result", result);
        cs.DispatchThreads(0, tex.width, tex.height, 1);

        if (mode == SortMode.None) return;
        // Sort
        cs.SetTexture(1, "_Sort", result);
        cs.SetInt("_Mode", (int)mode);
        cs.DispatchThreads(1, tex.height, 1, 1);
    }


    public enum SortMode { None, Hue, Saturation, Value }
}
