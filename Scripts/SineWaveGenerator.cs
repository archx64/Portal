using UnityEngine;

public class SineWaveGenerator : MonoBehaviour
{
    private float frequency = 440.0f;
    private float increment;
    private float phase;
    private readonly float samplingFrequency = 48000.0f;
    public float gain;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 0;
        audioSource.Play();
    }

    private void Update()
    {
        if (frequency < 10000)
        {
            frequency += 1.0f;
        }
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = frequency * 2 * Mathf.PI / samplingFrequency;

        for (int i = 0; i < data.Length; i += channels)
        {
            phase += increment;
            data[i] = gain * Mathf.Sin(phase);

            if (channels == 2)
            {
                data[i + 1] = data[i];
            }

            if (phase > (Mathf.PI * 4))
            {
                phase = 0;
            }
        }
    }


}