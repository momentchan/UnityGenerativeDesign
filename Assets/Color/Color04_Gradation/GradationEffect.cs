using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradationEffect : EffectBase {
    [SerializeField] private ColorData left;
    [SerializeField] private ColorData right;

    protected override void Start() {
        base.Start();
        Reset();
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0))
            Reset();
    }

    private void Reset() {
        left.Reset();
        right.Reset();

        mat.SetTexture("_LeftTex", left.tex);
        mat.SetTexture("_RightTex", right.tex);
    }

    [System.Serializable]
    public class ColorData {
        public Gradient gradient;
        public Texture2D tex;
        public ColorPreset setting;
        public readonly int KEY_COUNTS = 8;

        public void Reset() {
            tex = GenerateGradientTexture(ref gradient, setting);
        }

        private Texture2D GenerateGradientTexture(ref Gradient gradient, ColorPreset set) {
            var colors = new List<GradientColorKey>();
            var alphas = new List<GradientAlphaKey>();
            for (var i = 0; i < KEY_COUNTS; i++) {
                colors.Add(new GradientColorKey() {
                    time = 1f * i / KEY_COUNTS,
                    color = Color.HSVToRGB(Random.Range(set.hue.x, set.hue.y),
                                           Random.Range(set.saturation.x, set.saturation.y),
                                           Random.Range(set.value.x, set.value.y))
                });
                alphas.Add(new GradientAlphaKey() {
                    time = 1f * i / KEY_COUNTS,
                    alpha = 1
                });
            }
            gradient.SetKeys(colors.ToArray(), alphas.ToArray());
            return GradientTexGen.Create(gradient);
        }
    }

    [System.Serializable]
    public class ColorPreset {
        public Vector2 hue;
        public Vector2 saturation;
        public Vector2 value;
    }
}
