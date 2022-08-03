using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignFacingEffect : VFXEffectBase {
    [SerializeField, Range(0.05f, 0.2f)] private float size = 0.1f;
    [SerializeField] private float angleOffset = 0f;
    [SerializeField] private SizeMode sizeMode;
    [SerializeField] private ColorMode colorMode;
    [SerializeField] private List<Texture2D> textures;
    
    private int currentTexture = 0;


    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            currentTexture = (++currentTexture) % textures.Count;
            var tex = textures[currentTexture];
            graph.SetTexture("Texture", tex);
            graph.SetVector2("TextureSize", new Vector2(tex.width / 256f, tex.height / 256f));
        }

        if (Input.GetKey(KeyCode.DownArrow))
            size = Mathf.Clamp(size - 0.01f, 0.05f, 0.2f);

        if (Input.GetKey(KeyCode.UpArrow))
            size = Mathf.Clamp(size + 0.01f, 0.05f, 0.2f);

        if (Input.GetKey(KeyCode.LeftArrow))
            angleOffset -= 5f;

        if (Input.GetKey(KeyCode.RightArrow))
            angleOffset += 5f;

        if (Input.GetKeyDown(KeyCode.D)) {
            sizeMode = (SizeMode)(((int)sizeMode+1) % Enum.GetValues(typeof(SizeMode)).Length);
            graph.SetInt("SizeMode", (int)sizeMode);
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            colorMode = (ColorMode)(((int)colorMode + 1) % Enum.GetValues(typeof(ColorMode)).Length);
            graph.SetInt("ColorMode", (int)colorMode);
        }

        graph.SetFloat("Size", size);
        graph.SetFloat("AngleOffset", angleOffset);
    }

    public enum SizeMode { Default, Ascent, Descent}
    public enum ColorMode { Black, Color, ColorAscent, ColorDescent }
}
