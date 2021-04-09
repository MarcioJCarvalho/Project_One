using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace Assets._Scripts.Environments
{
    public class DayCycleController : MonoBehaviour
    {
        [Range(0, 24)]
        public float timeOfDay;

        public float orbitSpeed = 1.0f;
        public Light sun;
        public Light moon;

        public Volume skyVolume;
        private PhysicallyBasedSky sky;
        public AnimationCurve starsCurve;
        public Color DayGroundColor;
        public Color NightGroundColor;

        private bool isNight;

        // Use this for initialization
        void Start()
        {
            skyVolume.profile.TryGet(out sky);

            if (isNight)
            {
                sky.spaceEmissionMultiplier.value = 1000;
            }
            else
            {
                sky.spaceEmissionMultiplier.value = 0;
            }
        }

        // Update is called once per frame
        void Update()
        {
            timeOfDay += Time.deltaTime / orbitSpeed;
            if (timeOfDay > 24)
            {
                timeOfDay = 0;
            }

            UpdateTime();
        }

        private void OnValidate()
        {
            skyVolume.profile.TryGet(out sky);
            UpdateTime();
        }

        private void UpdateTime()
        {
            float alpha = timeOfDay / 24.0f;
            float sunRotation = Mathf.Lerp(-90, 270, alpha);
            float moonRotation = sunRotation - 180;
            
            sun.transform.rotation = Quaternion.Euler(sunRotation, 150.0f, 0);
            moon.transform.rotation = Quaternion.Euler(moonRotation, 150.0f, 0);

            //sky.spaceEmissionMultiplier.value = starsCurve.Evaluate(alpha) * 1000.0f;

            CheckNightDayTransition();
        }

        private void CheckNightDayTransition()
        {
            if (isNight)
            {
                if (moon.transform.rotation.eulerAngles.x > 180)
                {
                    StartDay();
                }
            }
            else
            {
                if (sun.transform.rotation.eulerAngles.x > 180)
                {
                    StartNight();
                }
            }
        }

        private void StartDay()
        {
            isNight = false;
            sun.shadows = LightShadows.Soft;
            moon.shadows = LightShadows.None;
            moon.gameObject.SetActive(false);
            sun.gameObject.SetActive(true);
            sky.spaceEmissionMultiplier.value = 0;
            //sky.groundTint.value = DayGroundColor; // Descomente para maior realismo no ceu
        }

        private void StartNight()
        {
            //float alpha = timeOfDay / 24.0f;
            isNight = true;
            sun.shadows = LightShadows.None;
            moon.shadows = LightShadows.Soft;
            moon.gameObject.SetActive(true);
            sun.gameObject.SetActive(false);
            //sky.spaceEmissionMultiplier.value = starsCurve.Evaluate(alpha) * 1000.0f;
            sky.spaceEmissionMultiplier.value = 1000;
            //sky.groundTint.value = NightGroundColor; // Descomente para maior realismo no ceu
        }
    }
}