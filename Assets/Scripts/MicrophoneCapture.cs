using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneCapture : MonoBehaviour
{
    AudioClip microphoneInput;
    bool microphoneInitialized;
    public float sensitivity;
    public bool flapped;

    private void Awake()
    {
        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            microphoneInitialized = true;
        }
    }

    private void Update()
    {
        //get mic volume
        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(null) - (dec + 1); // null means the first microphone
        microphoneInput.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        float levelMax = 0;
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));

        Debug.Log(level);
        transform.Translate(Vector3.up * -level * sensitivity * Time.deltaTime);
        //transform.position = new Vector3(transform.position.x, -level * sensitivity * Time.deltaTime + 5, transform.position.z);
    }
}