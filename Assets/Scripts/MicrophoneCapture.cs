using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneCapture : MonoBehaviour
{
    Animator anim;
    AudioClip microphoneInput;
    AudioSource audioSource;
    bool microphoneInitialized;
    public float sensitivity;
    //public bool flapped;
    public float speed;

    private void Awake()
    {
        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            microphoneInitialized = true;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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

        anim.SetFloat("scream_level", level);


        if (level < 0.1f && transform.position.y < 5f)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (level > 0.1f && transform.position.y > -3f)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }
        //transform.position = new Vector3(transform.position.x, -level * sensitivity * Time.deltaTime + 5, transform.position.z);
    }
}