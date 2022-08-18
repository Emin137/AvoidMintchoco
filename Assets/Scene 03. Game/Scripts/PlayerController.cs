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
    public GameObject dieMenu;
    public GameObject player;
    private int shield, coinAdd;
    public List<SkillData> skillData;
    private bool skillused = false;
    private bool isLeft = false;
    private float cooltime;
    private float teleportRange = 1.7f;
    

    private void Awake()
    {
        skillButton.onClick.AddListener(UseSkill);
    }
    private void Start()
    {
        speed = 3.0f;
        coinAdd = 1;
        shield = 0;
        skillData = SkillManager.GetResultSkill();
        if (skillData[0].skillName == "Á¡¸ê")
        {
            Debug.Log(skillData[0].skillName);
            cooltime = 5.0f;
        }
        if (skillData[0].skillName == "¾óÀ½¶¯!")
        {
            Debug.Log(skillData[0].skillName);
            cooltime = 5.0f;
        }
        if (skillData[0].skillName == "ÇÎ°Å½º³À")
        {
            Debug.Log(skillData[0].skillName);
            cooltime = 5.0f;
        }
        if (skillData[1].skillName == "¿øÄÚ")
        {
            shield += 1;
            Debug.Log(skillData[1].skillName);
        }
        if (skillData[1].skillName == "ÀÌµ¿¼Óµµ Áõ°¡")
        {
            speed *= 2;
            Debug.Log(skillData[1].skillName);
        }
        if (skillData[1].skillName == "¹¯°í ´õºí·Î °¡")
        {
            coinAdd *= 2;
            Debug.Log(skillData[1].skillName);
        }
        if (skillData[2].skillName == "¹«¼öÇÑ ¶Ë")
        {
            DDongGenerator.Instance.ddongCreatTime = 0.15f;
            Debug.Log(skillData[2].skillName);
        }
        if (skillData[2].skillName == "°Å´ëÇÑ ¶Ë")
        {
            Debug.Log(skillData[2].skillName);
        }
        if (skillData[2].skillName == "³ª´Â ºÎÀÚ´Ù")
        {
            CoinGenerator.Instance.coinCreateTime = 0.60f;
            Debug.Log(skillData[2].skillName);
        }
        skillImage.sprite = skillData[0].skillSprite;
        skillImageBG.sprite = skillData[0].skillSprite;
        passiveSkillImage.sprite = skillData[1].skillSprite;
        debuffSkillImage.sprite = skillData[2].skillSprite;
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            isLeft = true;
        }
        if (horizontal > 0)
        {
            isLeft = false;
        }
        transform.Translate(horizontal * Time.deltaTime * speed, 0f, 0f);

        if (transform.position.x <= -edge)
        {
            transform.position = new Vector2(-edge, transform.position.y);
        }
        else if (transform.position.x >= edge)
        {
            transform.position = new Vector2(edge, transform.position.y);
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
            skillButton.image.fillAmount += Time.deltaTime / cooltime;
            if (skillButton.image.fillAmount >= 1)
            {
                skillused = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "ddong(Clone)" && shield == 0)
        {
            dieMenu.SetActive(true);
            ClearSkill();
            Time.timeScale = 0f;
        } 
        else if (collision.name == "ddong(Clone)" && shield == 1)
        {
            shield -= 1;
        }
        
        if (collision.name == "coin(Clone)")
        {
            Land.Instance.HandleCoin(coinAdd);
        }
    }

    private void UseSkill()
    {
        if (skillused == false && skillData[0].skillName == "Á¡¸ê")
        {
            Debug.Log("Á¡¸ê!!");
            if (isLeft == true)
            {
                transform.position = new Vector2(transform.position.x - teleportRange, transform.position.y);
            }
            if (isLeft == false)
            {
                transform.position = new Vector2(transform.position.x + teleportRange, transform.position.y);
            }
            skillButton.image.fillAmount = 0;
            skillused = true;
        }
        if (skillused == false && skillData[0].skillName == "¾óÀ½¶¯!")
        {
            Debug.Log("¾óÀ½¶¯!");
            skillButton.image.fillAmount = 0;
            skillused = true;
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
            skillButton.image.fillAmount = 0;
            skillused = true;
        }
    }
    public void ClearSkill()
    {
        skillData.Clear();
    }
}
