using UnityEngine;

public class WalkingWall : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotateSpeed = 5f;

    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Vector3 rotateAngle;
    [SerializeField] private bool looping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    // Update is called once per frame
    void Update()
    {
        if (looping)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (Mathf.Sin(Time.time * moveSpeed) + 1f) / 2f);
        }
        else
        {
            transform.Rotate(rotateAngle, Time.deltaTime*rotateSpeed);
        }
        
    }
}
