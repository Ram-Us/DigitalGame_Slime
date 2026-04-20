using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.Examples;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private AudioClip cg;
    private AudioSource audioSource;
    private int score;

    public int Score => score;


    [SerializeField] private TextMeshProUGUI ct;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ct.text = "×0";
    }

    public void AddScore(int amount)
    {
        score += amount;
        ct.text = $"×{score/10}";
        audioSource.PlayOneShot(cg);
        Debug.Log("スコア加算！現在：" + score);
    }
}
