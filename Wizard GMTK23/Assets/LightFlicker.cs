using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public bool flickIntensity;
    public float _baseIntensity;
    public float intensityRange;
    public float intensityTimeMin;
    public Light2D _light;
    public float intensityTimeMax;

    private IEnumerator FlickIntensity()
    {
        float t0 = Time.time;
        float t = t0;
        WaitUntil wait = new WaitUntil(() => Time.time > t0 + t);
        yield return new WaitForSeconds(Random.Range(0.01f, 0.5f));

        while (true)
        {
            if (flickIntensity)
            {
                t0 = Time.time;
                float r = Random.Range(_baseIntensity - intensityRange, _baseIntensity + intensityRange);
                _light.intensity = r;
                t = Random.Range(intensityTimeMin, intensityTimeMax);
                yield return wait;
            }
            else yield return null;
        }
    }

    private void Update()
    {
        StartCoroutine(FlickIntensity());
    }
}
