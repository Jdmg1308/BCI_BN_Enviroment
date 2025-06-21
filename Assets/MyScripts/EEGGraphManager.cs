using System.Collections.Generic;
using UnityEngine;
using Interaxon.Libmuse;

public class EEGGraphManager : MonoBehaviour
{
    public LineRenderer alphaLine;
    public LineRenderer betaLine;
    public LineRenderer deltaLine;
    public LineRenderer thetaLine;
    public LineRenderer gammaLine;

    public Dictionary<string, List<float>> bufferDict = new Dictionary<string, List<float>>();

    public int maxPoints = 100;
    [SerializeField] public float yScale = 200.0f;

    void Start()
    {
        bufferDict["ALPHA_ABSOLUTE"] = new List<float>();
        bufferDict["BETA_ABSOLUTE"] = new List<float>();
        bufferDict["DELTA_ABSOLUTE"] = new List<float>();
        bufferDict["THETA_ABSOLUTE"] = new List<float>();
        bufferDict["GAMMA_ABSOLUTE"] = new List<float>();
    }

    public void AddValue(MuseDataPacketType type, float value)
    {
        if (bufferDict.TryGetValue(type.ToString(), out var buffer))
        {
            buffer.Add(value);
            if (buffer.Count > maxPoints)
                buffer.RemoveAt(0);
            UpdateLine(type.ToString(), buffer);
        }
        else
        {
            Debug.Log($"Unknown band: {type}");
        }
    }

    private void UpdateLine(string band, List<float> values)
    {
        LineRenderer lineRenderer = GetLineRenderer(band);
        if (lineRenderer == null) return;

        lineRenderer.positionCount = values.Count;
        for (int i = 0; i < values.Count; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(i * 0.1f, values[i] * yScale, 0));
        }
    }

    private LineRenderer GetLineRenderer(string band)
    {
        return band switch
        {
            "ALPHA_ABSOLUTE" => alphaLine,
            "BETA_ABSOLUTE" => betaLine,
            "DELTA_ABSOLUTE" => deltaLine,
            "THETA_ABSOLUTE" => thetaLine,
            "GAMMA_ABSOLUTE" => gammaLine,
            _ => null
        };
    }

    public Dictionary<string, float> GetLatestAverages(int sampleCount = 30)
    {
        Dictionary<string, float> averages = new Dictionary<string, float>();
        foreach (var band in bufferDict.Keys)
        {
            var buffer = bufferDict[band];
            int count = Mathf.Min(sampleCount, buffer.Count);
            if (count == 0) continue;

            float sum = 0f;
            for (int i = buffer.Count - count; i < buffer.Count; i++)
                sum += buffer[i];

            averages[band] = sum / count;
        }
        return averages;
    }

}
