using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip _success;
    [SerializeField] AudioClip _failure;

    AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySuccess()
    {
        _source.PlayOneShot(_success);
    }
    public void PlayFailure()
    {
        _source.PlayOneShot(_failure);
    }
}
