using System;
using System.Collections.Generic;
using UnityEngine;

public class AlignFacingEffect : VFXEffectBase {
    [SerializeField] private Vector2 sizeRange = new Vector2(0.05f, 0.2f);
    [SerializeField] private float angleOffset = 0f;
    [SerializeField] private SizeMode sizeMode;
    [SerializeField] private ColorMode colorMode;
    [SerializeField] private List<SpriteData> sprites;
    
    private int currentSprite = 0;
    private float size = 0.1f;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            currentSprite = (++currentSprite) % sprites.Count;
            var sprite = sprites[currentSprite];
            graph.SetTexture("Texture", sprite.texture);
            graph.SetVector2("TextureSize", new Vector2(sprite.texture.width / 256f, sprite.texture.height / 256f));
            graph.SetVector3("PosOffset", sprite.posOffset);
        }

        if (Input.GetKey(KeyCode.DownArrow))
            size = Mathf.Clamp(size - 1e-3f, sizeRange.x, sizeRange.y);

        if (Input.GetKey(KeyCode.UpArrow))
            size = Mathf.Clamp(size + 1e-3f, sizeRange.x, sizeRange.y);

        if (Input.GetKey(KeyCode.LeftArrow))
            angleOffset -= 1f;

        if (Input.GetKey(KeyCode.RightArrow))
            angleOffset += 1f;

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

    [Serializable]
    public class SpriteData {
        public Vector3 posOffset;
        public Texture2D texture;
    }
}
