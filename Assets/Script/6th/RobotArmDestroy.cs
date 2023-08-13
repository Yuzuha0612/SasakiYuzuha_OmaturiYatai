using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArmDestroy : MonoBehaviour
{
    private Rigidbody2D rb;

    public float heightArmpos;
    public float WidthArmpos;
    public GameObject RobotArmobj;
    public GameObject Zoukinobj;
    public SpriteRenderer RobotArm;
    public SpriteRenderer Zoukin;
    public GameObject Yogoreobj;
    public GameObject Kirakiraobj;
    public GameObject MoyaMoyaobj;
    public SpriteRenderer Yogore;
    public SpriteRenderer Kirakira;
    public SpriteRenderer MoyaMoya;
    public BoxCollider2D YogoreCollider;
    public BoxCollider2D KirakiraCollider;
    public BoxCollider2D MoyaMoyaCollider;

    private GameObject CountText;
    CountYogore CountYogoreSc;
    public AudioClip YogoreSound;
    public AudioClip KirakiraSound;
    AudioSource audioSource;
    void Start()
    {
        RobotArmobj = GameObject.Find("RobotArm4");
        Zoukinobj = GameObject.Find("zoukin");
        CountText = GameObject.Find("YogoreCount");
        RobotArm = RobotArmobj.GetComponent<SpriteRenderer>();
        Zoukin = Zoukinobj.GetComponent<SpriteRenderer>();
        CountYogoreSc = CountText.GetComponent<CountYogore>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ArmThreshold1")
        {
            //ArmDestry();
            rb = this.gameObject.GetComponent<Rigidbody2D>();
           rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            Vector3 tmp = this.gameObject.transform.position;
            heightArmpos = tmp.x;
            StartCoroutine(RobotArmAndZoukin());
           // Destroy(this.gameObject, 1);
        }
        if (collision.gameObject.tag == "Yogore")
        {
            audioSource.PlayOneShot(YogoreSound);
            Yogoreobj = collision.gameObject;
            Yogore = Yogoreobj.GetComponent<SpriteRenderer>();
            YogoreCollider = Yogoreobj.GetComponent<BoxCollider2D>();
            rb = this.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            Vector3 tmp = this.gameObject.transform.position;
            heightArmpos = tmp.x;
            Yogore.enabled = false;
            CountYogoreSc.YogoreCount++;
            StartCoroutine(RobotArmAndZoukinYogore());
        }
        if (collision.gameObject.tag == "Kirakira")
        {
            Kirakiraobj = collision.gameObject;
            Kirakira = Kirakiraobj.GetComponent<SpriteRenderer>();
            KirakiraCollider= Kirakiraobj.GetComponent<BoxCollider2D>();
        }
        if (collision.gameObject.tag == "MoyaMoya")
        {
           MoyaMoyaobj = collision.gameObject;
            MoyaMoya = MoyaMoyaobj.GetComponent<SpriteRenderer>();
            MoyaMoyaCollider = MoyaMoyaobj.GetComponent<BoxCollider2D>();
            rb = this.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            Vector3 tmp = this.gameObject.transform.position;
            heightArmpos = tmp.x;
            MoyaMoya.enabled = false;
            CountYogoreSc.YogoreCount++;
            StartCoroutine(RobotArmAndZoukinMoyaMoya());
        }
    }
    
        IEnumerator RobotArmAndZoukin()
    {
        Debug.Log("コルーチン!");
        yield return new WaitForSecondsRealtime(1.0f);
        Zoukin.enabled = true;
        RobotArm.enabled = true;
        Destroy(this.gameObject);
    }
    IEnumerator RobotArmAndZoukinYogore()
    {
        Debug.Log("コルーチン!");
        yield return new WaitForSecondsRealtime(1.0f);
        Zoukin.enabled = true;
        RobotArm.enabled = true;
        Kirakira.enabled = true;
        KirakiraCollider.enabled = false;
        YogoreCollider.enabled = false;
        audioSource.PlayOneShot(KirakiraSound);
        Destroy(this.gameObject);
    }
    IEnumerator RobotArmAndZoukinMoyaMoya()
    {
        Debug.Log("コルーチン!");
        yield return new WaitForSecondsRealtime(1.0f);
        Zoukin.enabled = true;
        RobotArm.enabled = true;
        Kirakira.enabled = true;
        KirakiraCollider.enabled = false;
        MoyaMoyaCollider.enabled = false;
        Destroy(this.gameObject);
    }
}