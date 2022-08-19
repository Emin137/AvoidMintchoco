using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<PlayerController>();
            return instance;
        }
    }
    [SerializeField] Button skillButton;
    [SerializeField] Image skillImage;
    [SerializeField] Image skillImageBG;
    [SerializeField] Image passiveSkillImage;
    [SerializeField] Image debuffSkillImage;
    public float speed;
    private float edge = 2.5f;
    private float cooltime;
    private float teleportRange = 1.7f;
    private int shield, coinAdd;
    public GameObject dieMenu;
    public GameObject player;
    public GameObject playerShield;
    public List<SkillData> skillData;
    private bool skillused = false;
    private bool isLeft = false;
    private bool dontDie = false;
    private bool playerMove = true;
    public bool bigDDong = false;
    private SpriteRenderer playerImage;
    public AudioSource audioSource;
    public AudioClip flash;
    public AudioClip ice;
    public AudioClip snap;
    public AudioClip die;
    public AudioClip thanos;
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        skillButton.onClick.AddListener(UseSkill);
        playerImage = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 3; i++)
        {
            if (PlayerManager.GetPlayerList()[i].nowChoose)
            {
                playerImage.sprite = PlayerManager.GetPlayerList()[i].playerSprite;
                if(i==0)
                {
                    animator.SetTrigger("01");
                }
                if(i==1)
                {
                    gameObject.transform.localScale = new Vector3(-0.65f, 0.65f, 1);
                    animator.SetTrigger("02");
                }
                if(i==2)
                {
                    animator.SetTrigger("03");
                    gameObject.transform.localPosition = new Vector2(0, -4);
                    playerShield.transform.localPosition = new Vector2(0, 0.5f);
                    gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.03527361f, 0.4760385f);
                    gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.8211522f, 0.9184052f);
                }
            }
        }
    }
    private void Start()
    {
        speed = 3.0f;
        coinAdd = 1;
        shield = 0;
        skillData = SkillManager.GetResultSkill();
        if (skillData[0].skillName == "Á¡¸ê")
        {
            cooltime = 5.0f;
        }
        if (skillData[0].skillName == "¾óÀ½~¶¯!")
        {
            cooltime = 5.0f;
        }
        if (skillData[0].skillName == "ÇÎ°Å½º³À")
        {
            cooltime = 5.0f;
        }
        if (skillData[1].skillName == "¿øÄÚ±¹·ê")
        {
            playerShield.SetActive(true);
            shield += 1;
        }
        if (skillData[1].skillName == "ÀÌµ¿¼Óµµ Áõ°¡")
        {
            speed *= 2;
        }
        if (skillData[1].skillName == "¹¯°í ´õºí·Î °¡!")
        {
            coinAdd *= 2;
        }
        if (skillData[2].skillName == "¹«¼öÇÑ ¹ÎÃÊ")
        {
            DropGenerator.Instance.ddongCreatTime = 0.15f;
        }
        if (skillData[2].skillName == "»çÀÌÁî ¾÷")
        {
            bigDDong = true;
        }
        if (skillData[2].skillName == "³ª´Â ºÎÀÚ´Ù")
        {
            CoinGenerator.Instance.coinCreateTime = 0.60f;
            coinAdd *= 2;
        }
        skillImage.sprite = skillData[0].skillSprite;
        skillImageBG.sprite = skillData[0].skillSprite;
        passiveSkillImage.sprite = skillData[1].skillSprite;
        debuffSkillImage.sprite = skillData[2].skillSprite;
    }
    private void Update()
    {
        if (playerMove == true)
        {
            float horizontal = Input.GetAxis("Horizontal");
            if (horizontal < 0)
            {
                isLeft = true;
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                animator.SetBool("isRun", true);
            }
            else if (horizontal > 0)
            {
                animator.SetBool("isRun", true);
                isLeft = false;
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
                animator.SetBool("isRun", false);
            transform.Translate(horizontal * Time.deltaTime * speed, 0f, 0f);

            if (transform.position.x <= -edge)
            {
                transform.position = new Vector2(-edge, transform.position.y);
            }
            else if (transform.position.x >= edge)
            {
                transform.position = new Vector2(edge, transform.position.y);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.Instance.Pause();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseSkill();
        }
        if (skillused == true)
        {
            skillImage.fillAmount += Time.deltaTime / cooltime;
            if (skillImage.fillAmount >= 1)
            {
                skillused = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "Drop(Clone)" && shield == 0 && dontDie == false || collision.name == "BigDrop(Clone)" && shield == 0 && dontDie == false)
        {
            audioSource.clip = die;
            audioSource.Play();
            dieMenu.SetActive(true);
            ClearSkill();
            Time.timeScale = 0f;
        } 
        else if (collision.name == "Drop(Clone)" && shield == 1 && dontDie == false || collision.name == "BigDrop(Clone)" && shield == 1 && dontDie == false)
        {
            audioSource.clip = die;
            audioSource.Play();
            shield -= 1;
            playerShield.SetActive(false);
        }
        
        if (collision.name == "coin(Clone)")
        {
            Land.Instance.HandleCoin(coinAdd);
            audioSource.clip = snap;
                audioSource.Play();
        }
    }

    private void UseSkill()
    {
        if (skillused == false && skillData[0].skillName == "Á¡¸ê")
        {
            if (isLeft == true)
            {
                transform.position = new Vector2(transform.position.x - teleportRange, transform.position.y);
            }
            if (isLeft == false)
            {
                transform.position = new Vector2(transform.position.x + teleportRange, transform.position.y);
            }
            skillImage.fillAmount = 0;
            skillused = true;
            audioSource.clip = flash;
                audioSource.Play();
        }
        if (skillused == false && skillData[0].skillName == "¾óÀ½~¶¯!")
        {
            Debug.Log("¾óÀ½¶¯!");
            dontDie = true;
            playerMove = false;
            player.GetComponent<SpriteRenderer>().color = Color.blue;
            StartCoroutine(WaitForIt());
            skillImage.fillAmount = 0;
            skillused = true;
            audioSource.clip = ice;
                audioSource.Play();
        }   
        if (skillused == false && skillData[0].skillName == "ÇÎ°Å½º³À")
        {
            GameObject[] forDestroy = GameObject.FindGameObjectsWithTag("ddong");
            {
                for (int i = 0; i < forDestroy.Length; i++)
                {
                    if (forDestroy[i].transform.localPosition.y <= 1.4f) // ¶Ë »èÁ¦ ¹üÀ§
                    {
                        GameObject.Destroy(forDestroy[i]);
                    }
                }
            }
            audioSource.clip = thanos;
            audioSource.Play();
            skillImage.fillAmount = 0;
            skillused = true;
        }
    }
    public void ClearSkill()
    {
        skillData.Clear();
    }
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
        player.GetComponent<SpriteRenderer>().color = Color.white;
        dontDie = false;
        playerMove = true;
    }
}
