using UnityEngine;
using UnityEngine.UI;
public class PauseScreen : MonoBehaviour
{
    //[SerializeField] Image tb, mb;
    [SerializeField] GameObject panel;

    public static PauseScreen Instance;
    private bool isActiving = true;
    public bool IsActiving => isActiving;
    //private Vector3 PresentSize = new Vector3(7f, 3f, 6f);
    //private Vector3 ToucheSize = new Vector3(8f, 4f, 6f);

    private bool isPausing = false;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)&&!(isPausing))
        {
            panel.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
            isPausing = true;
            
        }else if (Input.GetKeyDown(KeyCode.Tab) && isPausing)
        {
            panel.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1f;
            isPausing = false;
        }
    }
}
