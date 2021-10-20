using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IApplyDamage
{
    //** Changed some variable names to better reflect new bullet movement. **//
    public float horizontalSpeed; //** Previously verticalSpeed. **//
    public float horizontalBoundary; //** Previously verticalSpeed. **//
    public BulletManager bulletManager;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    //** Changed bullet's Move() to be fired along the x-axis. **//
    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed, 0.0f, 0.0f ) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (transform.position.x > horizontalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        bulletManager.ReturnBullet(gameObject);
    }

    public int ApplyDamage()
    {
        return damage;
    }
}
