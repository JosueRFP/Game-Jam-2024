using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RainbowText : MonoBehaviour
{
    TMP_Text textmesh;

    Mesh mesh;

    Vector3[] vertices;

    public Gradient rainbow;

    private void Start()
    {
        textmesh = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        textmesh.ForceMeshUpdate();
        mesh = textmesh.mesh;
        vertices = mesh.vertices;

        Color[] colors = mesh.colors;

        for (int i = 0; i < textmesh.textInfo.characterCount; i++) 
        {
            TMP_CharacterInfo c = textmesh.textInfo.characterInfo[i];

            int index = c.vertexIndex;

            Vector3 offset = wobble(Time.time + i);

            colors[index] = rainbow.Evaluate(Mathf.Repeat(Time.time + vertices[index].x * 1f, 1f));
            colors[index + 1] = rainbow.Evaluate(Mathf.Repeat(Time.time + vertices[index + 1].x * 1f, 1f));
            colors[index + 2] = rainbow.Evaluate(Mathf.Repeat(Time.time + vertices[index + 2].x * 1f, 1f));
            colors[index + 3] = rainbow.Evaluate(Mathf.Repeat(Time.time + vertices[index + 3].x * 1f, 1f));

            vertices[index] += offset;
            vertices[index + 1] += offset;
            vertices[index + 2] += offset;
            vertices[index + 3] += offset;
        }

        mesh.vertices = vertices;
        mesh.colors = colors;
        textmesh.canvasRenderer.SetMesh(mesh);
    }

    Vector2 wobble(float time) 
    {
        return new Vector2(Mathf.Sin(time*1.3f), Mathf.Cos(time*1.5f));
    }
}

