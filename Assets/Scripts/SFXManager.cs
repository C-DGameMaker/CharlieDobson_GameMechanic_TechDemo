using UnityEngine;

[RequireComponent(typeof(AudioSource))]
/// <summary>
/// This will make the sound
/// </summary>
public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource _sfxSource;

    public AudioClip _pickUpCoin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _sfxSource = GetComponent<AudioSource>();
        if(_sfxSource == null)
        {
            Debug.Log("Add an AudioSource");
        }
    }

    public void PickUpSound()
    {
        _sfxSource.PlayOneShot(_pickUpCoin);
    }
}
