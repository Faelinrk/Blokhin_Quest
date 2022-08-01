using Quest;
using Quest.Common;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private int damage = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag(Constants.PlayerTag) || other.CompareTag(Constants.EnemyTag))
        {
            if (other.TryGetComponent<HpObject>(out HpObject hpObject))
            {
                hpObject.GetDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
