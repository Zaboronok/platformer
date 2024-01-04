using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public AudioSource ShotSound;
    public GameObject Flash;
    public ParticleSystem shotEffect;

    [SerializeField]
    private float _bulletSpeed = 16f;
    [SerializeField]
    private float _shotPeriod = 0.2f;
    
    private float _timer;

    void Update()
    {
        _timer += Time.unscaledDeltaTime;

        if (_timer > _shotPeriod && Input.GetMouseButton(0))
        {
            _timer = 0;
            Shot();            
        }
    }

    public void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int amount)
    {

    }

    public virtual void Shot()
    {
        var newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * _bulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);
        shotEffect.Play();

        Invoke("HideFlash", 0.08f);
    }
}
