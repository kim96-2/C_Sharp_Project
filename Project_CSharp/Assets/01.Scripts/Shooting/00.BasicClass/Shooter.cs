using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public string shooterName;

    public GameObject nextLevelShooter;

    public float shootingDelay;

    protected PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        ShootingUpdate();
    }

    private void OnDestroy()
    {
        Exit();
    }

    protected virtual void Init()
    {
        player = transform.GetComponentInParent<PlayerController>();
    }

    protected virtual void ShootingUpdate()
    {

    }

    protected virtual void Exit()
    {

    }

}
