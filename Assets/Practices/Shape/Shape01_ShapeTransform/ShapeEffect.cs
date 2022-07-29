using mj.gist;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeEffect : EffectBase {
    [SerializeField] private Shader drawShader;
    [SerializeField] private RenderTexture rt;
    [SerializeField, Range(0, 1f)] private float alpha = 0.2f;
    [SerializeField, Range(0, 0.1f)] private float width = 0.005f;
    [SerializeField] private bool inverse;
    [SerializeField] private List<Color> colors;

    private Material drawMat;

    private int currentColor;

    protected override void Start() {
        base.Start();
        drawMat = new Material(drawShader);
        Reset();
    }

    private void Update() {
        if (Input.GetMouseButton(0))
            Graphics.Blit(null, rt, drawMat);

        if (Input.GetMouseButtonDown(1))
            currentColor = (++currentColor) % colors.Count;

        if (Input.GetKeyDown(KeyCode.C))
            Reset();

        drawMat.SetFloat("_Alpha", alpha);
        drawMat.SetFloat("_Width", width);
        drawMat.SetColor("_Color", colors[currentColor]);
        mat.SetInt("_Inverse", inverse ? 1 : 0);
    }

    private void Reset() {
        if (rt != null)
            rt.Release();

        rt = RTUtil.Create(Screen.width, Screen.height, 0, RenderTextureFormat.ARGBFloat);
        RenderTexture.active = rt;
        GL.Clear(false, true, Color.white);
        RenderTexture.active = null;
        mat.SetTexture("_MainTex", rt);
    }

    private void OnDestroy() {
        rt.Release();
    }

}
