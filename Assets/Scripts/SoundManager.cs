using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioClip move, jump, squase, stretch;
    [SerializeField] private AudioSource moveSource;

    private AudioSource audioSource;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnMove()
    {
        audioSource.PlayOneShot(move);
    }
    public void OnJump()
    {
        audioSource.PlayOneShot(jump);
    }
    public void OnSquase()
    {
        audioSource.PlayOneShot(squase);
    }
    public void OnStretch()
    {
        audioSource.PlayOneShot(stretch);
    }
    public void PlayMoveLoop()
    {
    if (!moveSource.isPlaying)
        moveSource.Play();
    }

    public void StopMoveLoop()
    {
    moveSource.Stop();
    }
    
}
