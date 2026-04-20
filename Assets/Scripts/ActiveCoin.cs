using UnityEngine;

public class ActiveCoin : MonoBehaviour
{

    [SerializeField] private Vector3 rotateAngle;
    [SerializeField] private float rotateSpeed;

    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateAngle, rotateSpeed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.transform.position += Vector3.up * 1.5f;
            Debug.Log("コインゲット");

        }
    }
}
