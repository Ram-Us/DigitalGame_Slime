using UnityEngine;
using TMPro;
using System.Data; // TextMeshProを使う場合

public class CountdownTsimer : MonoBehaviour
{

    public static CountdownTsimer Instance;
    [SerializeField] float timeLimit = 180f; // 3分 = 180秒

    public TextMeshProUGUI timerText; // 表示用のテキスト

    private float timeRemain;
    public float TimeRemain => timeRemain;
    private bool isJudging;
    private bool isClearing = true;
    public bool IsClearing => isClearing;

    [SerializeField] private AudioClip tu;
    private AudioSource audioSource;

     void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        
        timeRemain = timeLimit;
        isJudging = SlimeController.Instance.BT;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
       
            // 残り時間を減らす
        timeRemain -= Time.deltaTime;
        

        if (timeRemain < 0)
        {
            audioSource.PlayOneShot(tu);
            SlimeController.Instance.GameEnd();
            isJudging = true;
            isClearing = false;
            Debug.Log("Time Up!");
        }

        if (!(isJudging))
        {
            // 分と秒に変換
            int minutes = Mathf.FloorToInt(timeRemain / 60);
            int seconds = Mathf.FloorToInt(timeRemain % 60);

            // 表示を更新
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
        
        
        
    }
}

