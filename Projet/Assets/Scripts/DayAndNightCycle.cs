using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class DayAndNightCycle : MonoBehaviour
{
    [Header("Time Settings")]
    [Range(0f, 24F)]
    public float currentTime;
    public float timeSpeed = 1f;
    [Header("CurrentTine")]
    public string currentTimeString;

    [Header("Light Settings")]
    public Light sunLight;
    public float sunPosition = 1f;
    public float sunIntensity = 1f;
    public AnimationCurve sunIntensityMultiplier;
    public AnimationCurve lightTemperatureCurse;

    public bool isDay = true;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateTimeText();
        CheckShadowStatus();
    }
    
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime * timeSpeed;
            if(currentTime >=24)
                currentTime = 0;
        UpdateTimeText();
        UpdateLight();
        CheckShadowStatus();
    }
    private void OnValidate()
    {
        UpdateLight();
        CheckShadowStatus();
    }

    void UpdateTimeText() {
        currentTimeString = Mathf.Floor(currentTime).ToString("00") + ":"+((currentTime % 1) * 60). ToString("00");
    }

    void UpdateLight()
    {
        float sunRotation = currentTime / 24f * 360f;
        sunLight.transform.rotation = Quaternion.Euler(sunRotation - 90f, sunPosition, 0f);

        float normalizedTime = currentTime / 24f;
        float IntensityCurve = sunIntensityMultiplier.Evaluate(normalizedTime);
        HDAdditionalLightData sunLightData = sunLight.GetComponent<HDAdditionalLightData>();

        if(sunLightData!=null)
        {
            sunLightData.intensity = IntensityCurve*sunIntensity;
        }

        float temperatureMultiplier = lightTemperatureCurse.Evaluate(normalizedTime);
        Light lightComponent = sunLight.GetComponent<Light>();

        if(lightComponent!=null)
        {
            lightComponent.colorTemperature = temperatureMultiplier * 10000f;
        }

    }

    void CheckShadowStatus()
    {
        HDAdditionalLightData sunLightData = sunLight.GetComponent<HDAdditionalLightData>();
        float currentSunRotation = currentTime;
        if(currentSunRotation >= 6f && currentSunRotation <= 10f)
        {
            sunLightData.EnableShadows(true);
            isDay = true;
        }
        else
        {
            sunLightData.EnableShadows(false);
            isDay = false;
        }
    }


}
