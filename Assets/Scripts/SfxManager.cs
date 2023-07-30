using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    [SerializeField] AudioClip buttonClick;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip looseSound;
    [SerializeField] AudioClip damage;
    [SerializeField] AudioClip collect;
    [SerializeField] AudioSource sfxSource;
    public static SfxManager _insatnce;
    // Start is called before the first frame update
    private void Awake()
    {
        _insatnce = this;
    }
    void Start()
    {
        
    }
    public void Play_ButtonClick()
    {
        sfxSource.PlayOneShot(buttonClick);
    }
    public void Play_WinSound()
    {
        sfxSource.PlayOneShot(winSound);
    }
    public void Play_LooseSound()
    {
        sfxSource.PlayOneShot(looseSound);
    }
    public void Play_Damage()
    {
        sfxSource.PlayOneShot(damage);
    }
    public void Play_Collected()
    {
        sfxSource.PlayOneShot(collect);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
