using System.Collections.Generic;
using UnityEngine;

public class AuroraVisualizer : MonoBehaviour
{
    public EEGGraphManager graphManager;
    public ParticleSystem auroraParticles;

    public Gradient alphaGradient;
    //public float minSize = 5f;
    //public float maxSize = 30f;
    public float fullSize = 60f;

    void Update()
    {
        if (graphManager == null || auroraParticles == null) return;

        Dictionary<string, float> averages = graphManager.GetLatestAverages(5);

        if (averages.TryGetValue("ALPHA_ABSOLUTE", out float alphaVal))
        {
            Debug.Log("average alpha:" + alphaVal);
            var main = auroraParticles.main;
            //main.startColor = alphaGradient.Evaluate(Mathf.Clamp01(alphaVal));
            main.startSizeY = alphaVal * fullSize; // Mathf.Lerp(minSize, maxSize, Mathf.Clamp01(alphaVal));
        }

        // You can duplicate this block for other bands like BETA_ABSOLUTE if needed
    }
}
