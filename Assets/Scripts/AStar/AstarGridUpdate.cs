using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
[RequireComponent(typeof(AstarPath))]
public class AstarGridUpdate : MonoBehaviour
{
    private AstarPath astarPath;
    private bool shouldUpdateNextFrame = false;
    private Vector2 graphUpdateBoundSize = new Vector2(3, 3);
    private void Awake()
    {
        astarPath = GetComponent<AstarPath>();
        DestructibleTilemap.OnMapChanged += UpdateGraphs;
    }
    private void UpdateGraphs(Vector2 position)
    {
        StartCoroutine(UpdateGraphsNextFrame(position));
    }
    private IEnumerator UpdateGraphsNextFrame(Vector2 position)
    {
        yield return null;
        astarPath.UpdateGraphs(new Bounds(position, graphUpdateBoundSize));
    }
    private void OnDestroy()
    {
        DestructibleTilemap.OnMapChanged -= UpdateGraphs;
    }

}
