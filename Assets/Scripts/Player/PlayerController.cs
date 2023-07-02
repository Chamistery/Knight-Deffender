using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource soundSource2;
    [SerializeField] private AudioClip hitWallSound;
    [SerializeField] private AudioClip hp_plus;
    [SerializeField] private AudioClip slice;
    [SerializeField] private AudioClip _slow;
    [SerializeField] private AudioClip SwordingUp;
    [SerializeField] private AudioClip SwordingDown;
    [SerializeField] private AudioClip boost;
    [SerializeField] private GameObject SwordedUp;
    public Animator anim;
    private float speed = 0f;
 //   bool working = false;
    // public GameObject[] attackhitbox;
    public GameObject hitbox;
    private bool isAttacking = false;
    public static float coeff = 1;
    private bool isBoosted;
    private float distance = 1f;
    private bool Bigged = false;
    public GameObject slow;
    public static int numOfActivities = 0;
    int durX = 1;
    int durY = 1;
  //  private float timing = 0;
    // public GameObject shaman;
    private bool flagslow = false;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    // int flag = 0;
    //  public static Collider2D enemy;
    private void Awake()
    {
        Bigged = false;
        //   SwordedUp.SetActive(false);
        SwordUp.BIG = false;
        distance = 1f;
        coeff = 1f;
        flagslow = false;
    }
    void Start()
    {
        //SwordedUp.SetActive(false);
        //slow.SetActive(false);
        //attackhitbox[0].SetActive(false);
        //attackhitbox[1].SetActive(false);
        //attackhitbox[2].SetActive(false);
        //attackhitbox[3].SetActive(false);
        hitbox.transform.position = this.transform.position;
        hitbox.SetActive(false);
        coeff = 1f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Invoke("Speed", 1.2f);
    }
    void Speed()
    {
        speed = 200f;
    }

    void Update()
    {
        //    if (Pause_Menu.retryed)
        //    {
        //        //Bigged = false;
        //        ////   SwordedUp.SetActive(false);
        //        //SwordUp.BIG = false;
        //        //distance = 1f;
        //        //coeff = 1f;
        //        //flagslow = false;
        //        foreach (Transform child in GetComponentsInChildren<Transform>())
        //        {
        //            Destroy(child);
        //        }
        //      }
        if (!Bigged && SwordUp.BIG)
        {
            StartCoroutine(Bigging(10f));
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal")) != 0 && Mathf.Abs(Input.GetAxis("Vertical")) != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                durX = -1;
              //  flag = 1;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                durX = 1;
            //   flag = 1;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                durY = -1;
              //  flag = 2;
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                durY = 1;
              //  flag = 2;
            }
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            durX = -1;
            durY = 0;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            durX = 1;
            durY = 0;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            durX = 0;
            durY = -1;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            durX = 0;
            durY = 1;
        }
        //   Debug.DrawLine(this.transform.position, this.transform.position+Vector3.forward, Color.green,3);
        if (!isAttacking)
            hitbox.transform.position = this.transform.position;
        //if (IfHit.miss == true)
        //{
        //    soundSource2.PlayOneShot(hitWallSound);
        //    IfHit.miss = false;
        //}
        if (Health.heal)
        {
            soundSource.PlayOneShot(hp_plus);
            Health.heal = false;
        }
        if (ShamanScript.Slowing == true && !flagslow)
        {
            StartCoroutine(Slowing(1.5f));
        }
        float deltaX = Input.GetAxisRaw("Horizontal") * speed * coeff;
        float deltaY = Input.GetAxisRaw("Vertical") * speed * coeff;
        //Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //moveVelocity = moveInput.normalized * speed;
        rb.velocity = new Vector2(deltaX, deltaY) * Time.fixedDeltaTime;
        anim.SetFloat("SpeedX", deltaX);
        anim.SetFloat("SpeedY", deltaY);
        if (Input.GetKeyDown(KeyCode.LeftShift) && Mathf.Abs(deltaX) >= 0.1f && !Pause_Menu.GameIsPaused && !Text1.starting && !isBoosted)
        {
            StartCoroutine(Boosting());
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking && !Pause_Menu.GameIsPaused && !isBoosted && !Text1.starting)
        {
            if (Bigged)
            {
                anim.SetTrigger("BigHit");
            }
            else
            {
                anim.SetTrigger("Hit");
            }
            StartCoroutine(HIT());
            //Ray2D down = new Ray2D(transform.position, new Vector2(Input.GetAxisRaw("Horizontal"), 0));
            //RaycastHit2D hit;
            Collider2D enemy;
          //  RaycastHit2D hit;
            //hit = Physics2D.Raycast(transform.position, transform.right);
            // Collider2D enemy = Physics2D.Raycast(new Vector2(transform.position.x, this.transform.position.y), new Vector2(durX, durY), 100f).collider;
            //if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) != 0 && Mathf.Abs(Input.GetAxisRaw("Vertical")) != 0)
            //{ 
            //    enemy = Physics2D.Raycast(new Vector2(transform.position.x, this.transform.position.y), new Vector2(durX, durY),2f).collider;
            //    Debug.DrawRay(new Vector2(transform.position.x, this.transform.position.y), new Vector2(durX, durY), Color.red, 5f);
            //}
            //else if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) != 0 || (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 0 && Mathf.Abs(Input.GetAxisRaw("Vertical")) == 0))
            //{
            //    enemy = Physics2D.Raycast(new Vector2(transform.position.x, this.transform.position.y), new Vector2(durX, 0),2f).collider;
            //    Debug.DrawRay(new Vector2(transform.position.x, this.transform.position.y), new Vector2(durX, 0), Color.red, 5f);
            //}
            //else
            //{
            //    enemy = Physics2D.Raycast(new Vector2(transform.position.x, this.transform.position.y), new Vector2(0, durY),2f).collider;
            //    Debug.DrawRay(new Vector2(transform.position.x, this.transform.position.y), new Vector2(0, durY), Color.red, 5f);
            //}
            enemy = Physics2D.Raycast(new Vector2(transform.position.x, this.transform.position.y), new Vector2(durX, durY), 2f*distance).collider;
            Debug.DrawRay(new Vector2(transform.position.x, this.transform.position.y), new Vector2(durX, durY), Color.red, 5 * distance);
            if (enemy != null)
            {
                // Debug.Log(enemy.tag);
                //    Collider2D enemyVert = Physics2D.CircleCast(this.transform.position, 2, new Vector2(0,Input.GetAxisRaw("Vertical")), 3).collider;
                if (enemy.CompareTag("Enemy"))//(down, 3, out hit))
                {
                    //    enemy.GetComponent<SpriteRenderer>().color = Color.cyan;
                    soundSource2.PlayOneShot(slice);
                    if (enemy.GetComponent<MoveToWayPoints>() != null)
                        enemy.GetComponent<MoveToWayPoints>().hp.GetComponent<HP>().Dmg(10, 1);
                    if (enemy.GetComponent<ShamanScript>() != null)
                    {
                        enemy.GetComponent<ShamanScript>().hp.GetComponent<HP>().Dmg(10, 1);
                    }
                }
                //if (enemyVert.CompareTag("Enemy"))//(down, 3, out hit))
                //{
                //    soundSource2.PlayOneShot(slice);
                //    if (enemyVert.GetComponent<MoveToWayPoints>() != null)
                //        enemyVert.GetComponent<MoveToWayPoints>().hp.GetComponent<HP>().Dmg(10, 1);
                //    if (enemyVert.GetComponent<ShamanScript>() != null)
                //        enemyVert.GetComponent<ShamanScript>().hp.GetComponent<HP>().Dmg(10, 1);
                //}
            }
            else
                soundSource2.PlayOneShot(hitWallSound);
        }
    }
    //private GameObject MovePosition()
    //{

    //}
    //IEnumerator justSpawn()
    //{
    //    CreatingState.Respawned = true;
    //    yield return new WaitForSeconds(.01f);
    //    CreatingState.Respawned = false;
    //}
    IEnumerator SetActivities(GameObject obj, float timer)
    {
        GameObject create = GameObject.Instantiate(obj, new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 1.2f, 0f), Quaternion.identity, this.gameObject.transform) as GameObject;
        create.transform.localScale = new Vector3(0.05f, 0.05f, 1);
       // StartCoroutine(justSpawn());
        create.SetActive(true);
        // if(working)
        // {
        //     numOfActivities--;
        // }
        //// timing = timer;
        // working = true;
        // numOfActivities++;
        // obj.SetActive(true);
        // Vector3 pos = obj.transform.localPosition;
        // Debug.Log("setting");
        // obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, numOfActivities * obj.transform.localPosition.y, 0);
        yield return new WaitForSeconds(timer);
      //  IsHereState.colOfMovements = 0;
        //if (numOfActivities != 0)
        //{
        //    numOfActivities--;
        //}
        //obj.transform.localPosition = pos;
        //obj.SetActive(false);
        //working = false;
        Destroy(create);
    }
    IEnumerator Bigging(float seconds)
    {
        soundSource2.PlayOneShot(SwordingUp);
        distance = 2f;
        Bigged = true;
        StartCoroutine(SetActivities(SwordedUp, seconds));
        yield return new WaitForSeconds(seconds);
        Bigged = false;
        soundSource2.PlayOneShot(SwordingDown);
        //   SwordedUp.SetActive(false);
        SwordUp.BIG = false;
        distance = 1f;
    }
    IEnumerator Slowing(float seconds)
    {
        soundSource.PlayOneShot(_slow);
        flagslow = true;
        coeff = 0.6f;
        //  slow.SetActive(true);
        StartCoroutine(SetActivities(slow, seconds));
        yield return new WaitForSeconds(seconds);
        // slow.SetActive(false);
        ShamanScript.Slowing = false;
        coeff = 1f;
        flagslow = false;
    }

    IEnumerator HIT()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1f);
        anim.ResetTrigger("Hit");
        isAttacking = false;
    }
    IEnumerator Hit(Vector3 position)
    {
        //vertattackhitbox.transform.localPosition = -vertattackhitbox.transform.localPosition;
        //horattackhitbox.transform.localPosition = -horattackhitbox.transform.position;
        isAttacking = true;
        anim.SetTrigger("Hit");
        // yield return null;// new WaitForSeconds(.2f);
        // attackhitbox[a].SetActive(true);
        hitbox.SetActive(true);
        hitbox.transform.position = this.transform.position + position;
        yield return null;
        hitbox.SetActive(false);
        //vertattackhitbox.SetActive(true);
        //horattackhitbox.SetActive(true);
        anim.ResetTrigger("Hit");
        //vertattackhitbox.transform.localPosition = -vertattackhitbox.transform.localPosition;
        //horattackhitbox.transform.localPosition = -horattackhitbox.transform.localPosition;
        //yield return new WaitForSeconds(0.001f);
        //horattackhitbox.transform.localPosition = startpos1;
        //vertattackhitbox.transform.localPosition = startpos2;
      //  attackhitbox[a].SetActive(false);
        //vertattackhitbox.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        isAttacking = false;
    }
    //private IEnumerator starting()
    //{
    //    speed = 0f;
    //    yield return new WaitForSeconds(1f);
    //    speed = 200f;
    //}
    private IEnumerator Boosting()
    {
        isBoosted = true;
        anim.SetTrigger("Force");
        anim.SetInteger("ForceDoing", 1);
        speed = 400f;
        yield return new WaitForSeconds(0.15f);
        soundSource.PlayOneShot(boost);
        yield return new WaitForSeconds(1.05f);
        anim.ResetTrigger("Force");
        anim.SetInteger("ForceDoing", 0);
        speed = 200f;
        isBoosted = false;
    }
    //private void FixedUpdate()
    //{
    //    rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    //}
}
