using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject preFab;
    public Transform BulletTrash;
    public Transform BulletSpawn;
    public Transform ArrowTrash;
    public Transform ArrowSpawn;

    private const float Timer = 0.5f;
    private float _currentTime = 0.5f;
    private bool _canShoot = true;

    private void Update()
    {
        TimerMethod();
        Shoot();
    }

    private void TimerMethod()
    {
        if (!_canShoot)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime < 0)
            {
                _canShoot = true;
                _currentTime = Timer;
            }
        }
    }

    private void Shoot()
    {

        if (Input.GetKeyUp(KeyCode.Mouse0) && _canShoot)
        {
            GameObject bullet = Instantiate(preFab, BulletSpawn.position, Quaternion.identity);

            bullet.transform.SetParent(BulletTrash);

            _canShoot = false;

            GameObject Arrow = Instantiate(preFab, ArrowSpawn.position, Quaternion.identity);

            bullet.transform.SetParent(ArrowTrash);

            _canShoot = false;
        }
    }
}
