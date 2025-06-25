using System.Collections.Generic;
using UnityEngine;

public class AuroraVisualizer : MonoBehaviour
{
    public EEGGraphManager graphManager;
    public ParticleSystem auroraParticles_alpha;
    public ParticleSystem auroraParticles_beta;
    public ParticleSystem auroraParticles_delta;
    public ParticleSystem auroraParticles_theta;
    public ParticleSystem auroraParticles_gamma;

    //public float minSize = 5f;
    //public float maxSize = 30f;
    public float fullSize = 60f;

    void Update()
    {

        Dictionary<string, float> averages = graphManager.GetLatestAverages(5);

        if (averages.TryGetValue("ALPHA_ABSOLUTE", out float alphaVal))
        {
            Debug.Log("average alpha:" + alphaVal);
            var main = auroraParticles_alpha.main;
            main.startSizeY = alphaVal * fullSize; // Mathf.Lerp(minSize, maxSize, Mathf.Clamp01(alphaVal));
        }
        if (averages.TryGetValue("BETA_ABSOLUTE", out float betaVal))
        {
            Debug.Log("average beta:" + betaVal);
            var main = auroraParticles_beta.main;
            main.startSizeY = betaVal * fullSize;
        }
        if (averages.TryGetValue("DELTA_ABSOLUTE", out float deltaVal))
        {
            Debug.Log("average delta:" + deltaVal);
            var main = auroraParticles_delta.main;
            main.startSizeY = deltaVal * fullSize;
        }
        if (averages.TryGetValue("THETA_ABSOLUTE", out float thetaVal))
        {
            Debug.Log("average theta:" + thetaVal);
            var main = auroraParticles_theta.main;
            main.startSizeY = thetaVal * fullSize;
        }
        if (averages.TryGetValue("GAMMA_ABSOLUTE", out float gammaVal))
        {
            Debug.Log("average gamma:" + gammaVal);
            var main = auroraParticles_gamma.main;
            main.startSizeY = gammaVal * fullSize;
        }
    }
}
