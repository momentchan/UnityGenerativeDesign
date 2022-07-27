using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.VFX;

public class PatternSizeEffect : VFXEffectBase {
    [SerializeField] private int colorCount = 20;
    [SerializeField] private Vector2 rowCounts = new Vector2(5, 40);
    [SerializeField] private List<TileData> tilesData;

    private GraphicsBuffer tilesBuffer;

    protected override void Start() {
        base.Start();
        Reset();

    }
    private void Update() {
        if (Input.GetMouseButtonDown(0))
            Reset();
    }

    private void Reset() {
        var hsvs = new List<Vector3>();
        for (var i = 0; i < colorCount; i++) {
            if (i % 2 == 0)
                hsvs.Add(new Vector3(Random.value, 1, Random.value));
            else
                hsvs.Add(new Vector3(0.55f, Random.value, 1));
        }


        tilesData = new List<TileData>();
        var rowCount = (int)Random.Range(rowCounts.x, rowCounts.y);
        var counter = 0;
        for (var i = 0; i < rowCount; i++) {
            var partCount = i + 1;
            var parts = new List<float>();

            // subdivision
            for (var j = 0; j < partCount; j++) {
                if (Random.value < 0.075) {
                    var fragments = Random.Range(2, 20);
                    partCount += fragments;
                    for (var k = 0; k < fragments; k++)
                        parts.Add(Random.value * 2);
                }
                else
                    parts.Add(Random.Range(2f, 20f));
            }

            // sum up
            var sumOfPartsTotal = 0f;
            for (var j = 0; j < partCount; j++)
                sumOfPartsTotal += parts[j];

            var sumOfPartsNow = 0f;
            for (var j = 0; j < partCount; j++) {
                var index = counter % colorCount;
                tilesData.Add(new TileData() {
                    pos = new Vector2(sumOfPartsNow / sumOfPartsTotal, 1f * i / rowCount),
                    size = new Vector2(parts[j] / sumOfPartsTotal, 1f / rowCount),
                    hsv = hsvs[index]
                });
                sumOfPartsNow += parts[j];
                counter++;
            }
        }

        if (tilesBuffer != null)
            tilesBuffer.Release();
        tilesBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, tilesData.Count, Marshal.SizeOf(typeof(TileData)));
        tilesBuffer.SetData(tilesData);

        graph.SetGraphicsBuffer("TilesBuffer", tilesBuffer);
        graph.SetInt("TilesCount", tilesData.Count);
        graph.SetInt("RowCount", rowCount);
        graph.SendEvent("OnSpawn");
    }

    private void OnDestroy() {
        tilesBuffer.Release();
    }

    [System.Serializable]
    [VFXType(VFXTypeAttribute.Usage.GraphicsBuffer)]
    public struct TileData {
        public Vector2 pos;
        public Vector2 size;
        public Vector3 hsv;
    }
}
