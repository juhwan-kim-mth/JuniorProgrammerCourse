using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class BackgroundMusicController : MonoBehaviour
{
    [FormerlySerializedAs("_audioClips")] [SerializeField] private AudioClip[] audioClips;
    private AudioSource _backgroundAudioSource;
    private readonly float _audioVolume = 0.3f;

    // Start is called before the first frame update
    private void Start()
    {
        _backgroundAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_backgroundAudioSource.isPlaying)
        {
           _backgroundAudioSource.PlayOneShot(RandomClip(), _audioVolume); 
        }
    }

    private AudioClip RandomClip()
    {
        return audioClips[Random.Range(0, audioClips.Length)];
    }
}
