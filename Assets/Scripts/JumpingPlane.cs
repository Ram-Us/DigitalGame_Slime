using UnityEngine;

public class JumpingPlane : MonoBehaviour
{
    [SerializeField]
    private float JumpSpeed = 100f;
    [SerializeField] private AudioClip jp;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(jp);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpSpeed,ForceMode.Impulse);
        }
    }
}
