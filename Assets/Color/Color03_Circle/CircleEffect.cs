using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEffect : EffectBase {
    void Update() {
        if (Input.GetMouseButton(0)) {
            var mouseScreenPos = Input.mousePosition;
            var mouseUVPos = Camera.main.ScreenToViewportPoint(mouseScreenPos);
            mat.SetVector("_SegmentRadius", mouseUVPos);
        }
    }
}
