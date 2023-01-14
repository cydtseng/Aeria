using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioProc : MonoBehaviour
{
    private const int NUM_FREQUENCY_BANDS = 8;
    private const int NUM_SAMPLES = 512;
    private float[] bufferDecrease = new float[NUM_FREQUENCY_BANDS];
    private float[] freqBandHighest = new float[NUM_FREQUENCY_BANDS];

    public AudioSource audioSource;
    public static float[] samples = new float[NUM_SAMPLES];
    public static float[] frequencyBands = new float[NUM_FREQUENCY_BANDS];
    public static float[] frequencyBandBuffer = new float[NUM_FREQUENCY_BANDS];
    public static float[] audioBands = new float[NUM_FREQUENCY_BANDS];
    public static float[] audioBandBuffer = new float[NUM_FREQUENCY_BANDS];


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audioSource.clip != null)
        {
            GetSpectrumAudioSource();
            MakeFrequencyBands();
            BandBuffer();
            CreateAudioBands();
        }
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int currSample = 0;
        for (int i = 0; i < NUM_FREQUENCY_BANDS; i++)
        {
            float avg = 0;
            int samplesToTakePerFreqBand = (int)Mathf.Pow(2, i + 1);
            if (i == 7)
            {
                samplesToTakePerFreqBand += 2;
            }

            for (int j = 0; j < samplesToTakePerFreqBand; j++)
            {
                avg += samples[currSample] * (currSample + 1);
                currSample++;
            }
            avg /= currSample;
            frequencyBands[i] = avg * 10;
        }
    }

    void BandBuffer()
    {
        for (int i = 0; i < NUM_FREQUENCY_BANDS; i++)
        {
            if (frequencyBands[i] > frequencyBandBuffer[i])
            {
                frequencyBandBuffer[i] = frequencyBands[i];
                bufferDecrease[i] = 0.005f;
            }

            if (frequencyBands[i] < frequencyBandBuffer[i])
            {
                frequencyBandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < NUM_FREQUENCY_BANDS; i++)
        {
            if (frequencyBands[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = frequencyBands[i];
            }
            if (freqBandHighest[i] != 0)
            {
                audioBands[i] = (frequencyBands[i] / freqBandHighest[i]);
                audioBandBuffer[i] = (frequencyBandBuffer[i] / freqBandHighest[i]);
            }
        }
    }
}
