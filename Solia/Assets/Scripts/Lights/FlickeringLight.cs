using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlickeringLight : MonoBehaviour
{
    [Tooltip("The light to flicker")]
    [SerializeField] private Light2D lightUsed;

    [Tooltip("Frequency of the flickering")]
    [SerializeField] private float frequency;

    [Tooltip("The maximum value offset from the base value of intensity")]
    [SerializeField] private float maxOffsetIntensity;

    [Tooltip("The maximum value offset from the base value of outer Radius")]
    [SerializeField] private float maxOffsetOuterRadius;

    [Tooltip("The maximum value offset from the base value of inner Radius")]
    [SerializeField] private float maxOffsetInnerRadius;

    [Tooltip("The base intensity value")]
    [SerializeField] private float baseIntensity;

    [Tooltip("The base Outer Radius value")]
    [SerializeField] private float baseOuterRadius;

    [Tooltip("The base Inner Radius value")]
    [SerializeField] private float baseInnerRadius;

    private float lastFlickerTime = 0;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        lastFlickerTime += Time.deltaTime;

        if(lastFlickerTime >= 1f / frequency)
        {
            //randomise the values
            float multiplier = Random.Range(-1f, 1f);

            lightUsed.intensity = baseIntensity + ( maxOffsetIntensity * multiplier );
            lightUsed.pointLightOuterRadius = baseOuterRadius + ( maxOffsetOuterRadius * multiplier );
            lightUsed.pointLightInnerRadius = baseInnerRadius + ( maxOffsetInnerRadius * multiplier );
            lastFlickerTime = 0;
        }
    }
}