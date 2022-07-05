using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBase : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioClip on;
    [SerializeField] private AudioClip off;
    [SerializeField] private AudioClip error;
    public AudioClip GetClip(string type)
    {
        if (type == Names.Random) return clips[Random.Range(0, clips.Length)];
        else if (type == Names.On) return on;
        else if (type == Names.Off) return off;
        else if (type == Names.Error) return error;
        return clips[Random.Range(0, clips.Length)];
    }
}
