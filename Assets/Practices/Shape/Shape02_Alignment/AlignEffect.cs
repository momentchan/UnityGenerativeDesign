using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignEffect : EffectBase {
    void Update() {
        if (Input.GetMouseButtonDown(0))
            mat.SetFloat("_Seed", Random.value);

    }
}
