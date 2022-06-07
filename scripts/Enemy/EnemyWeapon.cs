using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float secondsBetweenShoot;
    [SerializeField] private float reycastDistance;
    [Space] [SerializeField] private AudioClip audioShoot;
    
    private AudioSource _audioSource;
    private float _lastShootTime;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.position, transform.right);
        Debug.DrawRay(point.position, transform.right * reycastDistance, Color.red);

        if (hit.distance <= reycastDistance && hit.collider.TryGetComponent(out PlayerMove _playerMove))
        {
            if (_lastShootTime <= 0)
            {
                Shoot();
                _lastShootTime = secondsBetweenShoot;
            }
        }
        _lastShootTime -= Time.deltaTime;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, point.position, point.rotation);
        _audioSource.PlayOneShot(audioShoot);
    }
}
