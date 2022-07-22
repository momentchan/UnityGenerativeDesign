using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionSetter : MonoBehaviour {
    [SerializeField] private Vector3 mouseUVPos;
    void Update() {
        var mouseScreenPos = Input.mousePosition;
        mouseUVPos = Camera.main.ScreenToViewportPoint(mouseScreenPos);
        Shader.SetGlobalVector("_MousePos", mouseUVPos);
    }
}
