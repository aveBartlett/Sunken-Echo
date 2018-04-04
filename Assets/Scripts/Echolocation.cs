using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Echolocation : MonoBehaviour {

    public AudioSource micInput;

    public Light PlayerVision;

    [Range(1, 100)] public float visionDistance;
    public FFTWindow fftWindow;
    public Slider sensitivitySlider;

    public GameObject particles;

    float[] audioData;

    float currTime;
    float updateStep = 0.1f;

    float clipLoudness;

    // Use this for initialization
    void Start () {
        visionDistance = PlayerPrefsManager.GetSensitivity();

        sensitivitySlider.onValueChanged.AddListener(delegate {
            SensitivityValueChangedHandler(sensitivitySlider);
        });
        
        audioData = new float[64];
        currTime = 0f;

        micInput = this.GetComponent<AudioSource>();
    }

    public void SensitivityValueChangedHandler(Slider sensitivitySlider)
    {
        visionDistance = sensitivitySlider.value;
    }

    // Update is called once per frame
    void Update () {

        // populate array with fequency spectrum data
        GetComponent<AudioSource>().GetSpectrumData(audioData, 0, fftWindow);

        //only update the loudness every 10th of a second to save computational power
        currTime += Time.deltaTime;

        if (currTime >= updateStep)
        {
            currTime = 0f;
            micInput.clip.GetData(audioData, micInput.timeSamples); //I read 64 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (float sample in audioData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= audioData.Length; //average
        }

        PlayerVision.spotAngle = 30 + (clipLoudness * visionDistance);
    }


    void emitSoundParticles(float particleLife)
    {

    }
}
