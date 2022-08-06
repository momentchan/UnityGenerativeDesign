using UnityEngine;

public class MovementTwoColorEffect : VFXEffectBase {
    [SerializeField] private bool useColor1;
    [SerializeField] private bool useColor2;
    [SerializeField] private bool useAlpha;
    [SerializeField] private Vector2 sizeRange = new Vector2(0, 0.1f);
    private float size1 = 0.04f;
    private float size2 = 0.02f;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            useColor1 = !useColor1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            useColor2 = !useColor2;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            useAlpha = !useAlpha;

        if (Input.GetKey(KeyCode.DownArrow))
            size1 = Mathf.Clamp(size1 - 1e-3f, sizeRange.x, sizeRange.y);
        if (Input.GetKey(KeyCode.UpArrow))
            size1 = Mathf.Clamp(size1 + 1e-3f, sizeRange.x, sizeRange.y);

        if (Input.GetKey(KeyCode.LeftArrow))
            size2 = Mathf.Clamp(size2 - 1e-3f, sizeRange.x, sizeRange.y);
        if (Input.GetKey(KeyCode.RightArrow))
            size2 = Mathf.Clamp(size2 + 1e-3f, sizeRange.x, sizeRange.y);



        graph.SetBool("UseColor1", useColor1);
        graph.SetBool("UseColor2", useColor2);
        graph.SetBool("UseAlpha", useAlpha);
        graph.SetFloat("Size1", size1);
        graph.SetFloat("Size2", size2);
    }
}
