using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody playerRb;
    public float speed;
    public Transform spawn;
    public Gun gun;
    public ChargeIcon chargeIcon;

    public float maxChange = 3f;
    private float _currentCharge;
    private bool _isCharged;

    void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerRb.AddForce(-spawn.forward * speed, ForceMode.VelocityChange);
                gun.Shot();
                _isCharged = false;
                _currentCharge = 0;
                chargeIcon.StartCharge();
            }
        } else
        {
            _currentCharge += Time.unscaledDeltaTime;
            chargeIcon.SetChargeValue(_currentCharge, maxChange);

            if (_currentCharge >= maxChange)
            {
                _isCharged = true;
                chargeIcon.StopCharge();
            }
        }
                
    }
}
