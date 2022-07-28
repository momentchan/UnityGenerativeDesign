using mj.gist;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeEffect : EffectBase {
    [SerializeField] private Shader drawShader;
    [SerializeField] private PingPongRenderTexture rt;
    [SerializeField, Range(0, 1f)] private float alpha = 0.2f;
    [SerializeField, Range(0, 0.1f)] private float width = 0.005f;
    [SerializeField] private bool inverse;

    private Material drawMat;

    protected override void Start() {
        base.Start();
        drawMat = new Material(drawShader);
        Reset();
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            drawMat.SetTexture("_Previous", rt.Read);
            Graphics.Blit(Texture2D.blackTexture, rt.Write, drawMat);
            rt.Swap();
        }

        if (Input.GetMouseButton(1))
            Reset();

        drawMat.SetFloat("_Alpha", alpha);
        drawMat.SetFloat("_Width", width);
        mat.SetInt("_Inverse", inverse ? 1 : 0);
    }

    private void Reset() {
        if (rt != null)
            rt.Dispose();
        rt = new PingPongRenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGBFloat);
        mat.SetTexture("_MainTex", rt.Read);
    }

    private void OnDestroy() {
        rt.Dispose();
    }

}
