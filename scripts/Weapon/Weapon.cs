using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Bullet bulletPrefab;
    [Space] [SerializeField] private AudioClip audioShoot;

    private AudioSource _audioSource;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, point.position, point.rotation);
            _audioSource.PlayOneShot(audioShoot);
        }
    }
}
