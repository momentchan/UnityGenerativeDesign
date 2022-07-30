using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignVFXEffect : VFXEffectBase {
    void Update() {
        if (Input.GetMouseButtonDown(0))
            graph.SetFloat("Seed", Random.value);

    }
}
