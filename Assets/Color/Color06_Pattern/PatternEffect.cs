using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.VFX;

public class PatternEffect : MonoBehaviour {
    [SerializeField] private int currnetMode = 0;

    [SerializeField] private int tilesCountX = 50;

    private GraphicsBuffer hsvBuffer;
    private VisualEffect graph;

    void Start() {
        graph = GetComponent<VisualEffect>();
        hsvBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, tilesCountX, Marshal.SizeOf(typeof(HsvData)));
        hsvBuffer.SetData(Enumerable.Range(0, tilesCountX).Select(i => new Vector3(Random.value, Random.value, Random.value)).ToArray());
        graph.SetGraphicsBuffer("HsvBuffer", hsvBuffer);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            currnetMode = (++currnetMode) % 10;
            switch (currnetMode) {
                case 0:
                    hsvBuffer.SetData(Enumerable.Range(0, tilesCountX).Select(i => new Vector3(Random.value, Random.value, Random.value)).ToArray());
                    break;
                case 1:
                    hsvBuffer.SetData(Enumerable.Range(0, tilesCountX).Select(i => new Vector3(Random.value, Random.value, 1)).ToArray());
                    break;
                case 2:
                    hsvBuffer.SetData(Enumerable.Range(0, tilesCountX).Select(i => new Vector3(Random.value, 1, Random.value)).ToArray());
                    break;
                case 3:
                    hsvBuffer.SetData(Enumerable.Range(0, tilesCountX).Select(i => new Vector3(0, 0, Random.value)).ToArray());
                    break;
                case 4:
                    hsvBuffer.SetData(Enumerable.Range(0, tilesCountX).Select(i => new Vector3(0.55f, 1, Random.value)).ToArray());
                    break;
                case 5:
                    hsvBuffer.SetData(Enumerable.Range(0, tilesCountX).Select(i => new Vector3(0.55f, Random.value, 1)).ToArray());
                    break;
                case 6:
                    hsvBuffer.SetData(Enumerable.Range(0, tilesCountX).Select(i => new Vector3(Random.Range(0, 0.5f), Random.Range(0.8f, 1f), Random.Range(0.5f, 0.9f))).ToArray());
                    break;
                case 7:
                    hsvBuffer.SetData(Enumerable.Range(0, tilesCountX).Select(i => new Vector3(Random.Range(0.5f, 1f), Random.Range(0.8f, 1f), Random.Range(0.5f, 0.9f))).ToArray());
                    break;
                case 8: {
                        var hsvs = new List<Vector3>();
                        for (var i = 0; i < tilesCountX; i++) {
                            if (i % 2 == 0)
                                hsvs.Add(new Vector3(Random.value, 1, Random.value));
                            else
                                hsvs.Add(new Vector3(0.55f, Random.value, 1));
                        }
                        hsvBuffer.SetData(hsvs);
                    }
                    break;
                case 9: {
                        var hsvs = new List<Vector3>();
                        for (var i = 0; i < tilesCountX; i++) {
                            if (i % 2 == 0)
                                hsvs.Add(new Vector3(0.53f, Random.value, Random.Range(0.1f, 1f)));
                            else
                                hsvs.Add(new Vector3(0.76f, Random.value, Random.Range(0.1f, 0.9f)));
                        }
                        hsvBuffer.SetData(hsvs);
                    }
                    break;
            }
        }
    }

    private void OnDestroy() {
        hsvBuffer.Dispose();
    }
    [VFXType(VFXTypeAttribute.Usage.GraphicsBuffer)]
    public struct HsvData {
        public Vector3 hsv;
    }
}
