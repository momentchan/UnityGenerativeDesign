using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBase : MonoBehaviour {
    protected Material mat;

    protected virtual void Start() {
        mat = GetComponent<Renderer>().material;
    }
}
