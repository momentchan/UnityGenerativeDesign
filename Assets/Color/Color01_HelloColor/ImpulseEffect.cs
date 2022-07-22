using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseEffect : EffectBase {
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float pulse = 0f;
    [SerializeField] private AnimationCurve curve;

    void Update() {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(EffectCoroutine());

        pulse %= Mathf.PI * 2;
        mat.SetFloat("_Pulse", pulse);
    }

    IEnumerator EffectCoroutine() {
        var t = 0f;
        while (t < duration) {
            yield return null;
            t += Time.deltaTime;
            pulse += curve.Evaluate(t / duration);
        }
    }
}
