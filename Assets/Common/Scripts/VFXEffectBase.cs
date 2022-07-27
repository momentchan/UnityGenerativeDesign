using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXEffectBase : MonoBehaviour
{
    protected VisualEffect graph;
    protected virtual void Start() {
        graph = GetComponent<VisualEffect>();
    }
}
