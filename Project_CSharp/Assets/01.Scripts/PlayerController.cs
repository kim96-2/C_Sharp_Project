using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int hp = 3;

    public float speed = 2f;
    public float fowardSpeedAmount = 0.2f;

    float maxShootingGauge = 100f;
    public float MaxShootingGauge
    {
        get { return maxShootingGauge; }
    }

    float shootingGauge;
    public float ShootingGauge
    {
        get { return shootingGauge; }
        set
        {
            if (value < 0f) shootingGauge = 0f;
            else if (value > maxShootingGauge) shootingGauge = maxShootingGauge;
            else shootingGauge = value;
        }
    }
    public bool isShootingGaugeExist
    {
        get
        {
            if (shootingGauge > 0) return true;
            else return false;
        }
    }

    public float gaugeDecreaseRate = 5f;
    public float gaugeIncreaseRate = 3f;

    List<Shooter> shooters = new List<Shooter>();

    Vector2 moveDir = new Vector2();

    Rigidbody2D rb;

    Material material;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        material = GetComponent<Renderer>().material;

        shooters.Add(GetComponentInChildren<Shooter>());
    }

    // Update is called once per frame
    void Update()
    {
        CheckShootingGauge();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()//Player Moving
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (v > 0) v *= fowardSpeedAmount;

        moveDir.Set(h, v);
        if (moveDir.sqrMagnitude > 1f) moveDir.Normalize();

        rb.MovePosition(rb.position + moveDir * speed * Time.deltaTime);
    } 

    void CheckShootingGauge()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ShootingGauge -= gaugeDecreaseRate * Time.deltaTime;
        }
        else
        {
            ShootingGauge += gaugeIncreaseRate * Time.deltaTime;
        }
    }

    protected void CreateShooter(GameObject shooterObj)
    {
        GameObject obj = Instantiate(shooterObj, transform.position, Quaternion.identity);

        Shooter shooter = obj.GetComponent<Shooter>();

        obj.transform.parent = transform;

        shooters.Add(shooter);
    }

    public void AddShooter(GameObject shooterObj)
    {
        Debug.Log("Add");

        Shooter shooterClass = shooterObj.GetComponent<Shooter>();

        foreach(Shooter s in shooters)
        {
            if(s.shooterName == shooterClass.shooterName)
            {
                UpgradeShooter(s);
                return;
            }
        }

        CreateShooter(shooterObj);
    }

    protected void DeleteShooter(Shooter shooter)
    {
        shooters.Remove(shooter);

        Destroy(shooter.gameObject);
    }

    protected void UpgradeShooter(Shooter shooter)
    {
        Debug.Log("Upgrade");

        GameObject upgrade = shooter.nextLevelShooter;
        if (upgrade == null) return;

        DeleteShooter(shooter);

        CreateShooter(upgrade);
    }

    public void Damage()
    {
        hp -= 1;
        if (hp <= 0) PlayerGameOver();

        StopCoroutine("DamageEffect");

        StartCoroutine("DamageEffect");
    }

    protected void PlayerGameOver()
    {
        GameObject.FindWithTag("GameController").GetComponent<GameManager>().GameOver();
        transform.Find("Booster").gameObject.SetActive(false);

        GetComponent<Collider2D>().enabled = false;

        GetComponent<SpriteRenderer>().enabled = false;

        Destroy(this);
    }

    IEnumerator DamageEffect()
    {
        material.SetFloat("_Hit_Amount", 1f);

        yield return new WaitForSeconds(0.6f);

        material.SetFloat("_Hit_Amount", 0f);
    }
}
