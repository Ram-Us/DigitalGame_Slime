using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private GameObject GetCoin, ResetSlime, ArrivePoint;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fall") && collision.gameObject.CompareTag("Block"))
        {
            GameObject PreParticle = Instantiate(ResetSlime, collision.gameObject.transform.position, Quaternion.identity);
            Debug.Log("やほー");
            Destroy(PreParticle, 1.0f);

        }
    }
    void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Middle"))
        {
            GameObject PreParticle = Instantiate(ArrivePoint,gameObject.transform.position, Quaternion.identity);
            Debug.Log("やほー2");
            Destroy(PreParticle,1.0f);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            GameObject PreParticle = Instantiate(GetCoin,gameObject.transform.position, Quaternion.identity);
            Debug.Log("やほー3"+other.gameObject.name);
            Destroy(PreParticle,1.0f);
        }
    }
}
