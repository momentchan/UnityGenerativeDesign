using mj.gist;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortEffect : EffectBase {
    [SerializeField] protected ComputeShader cs;
    [SerializeField] protected Texture2D tex;
    [SerializeField] protected RenderTexture result;

    protected override void Start() {
        base.Start();

        result = new RenderTexture(tex.width, tex.height, 0, RenderTextureFormat.ARGBFloat);
        result.enableRandomWrite = true;
        result.Create();
        mat.SetTexture("_Texture2D", result);
    }

}
