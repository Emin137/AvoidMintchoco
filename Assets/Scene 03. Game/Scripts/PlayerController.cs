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
    public float speed;
    private float edge = 2.5f;
    public GameObject dieMenu;
    public GameObject player;
    private int shield, coinAdd;
    public List<SkillData> skillData;
    private bool skillused = false;
    private float cooltime;

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
        if (skillData[0].skillName == "����")
        {
            Debug.Log(skillData[0].skillName);
            cooltime = 5.0f;
        }
        if (skillData[0].skillName == "������!")
        {
            Debug.Log(skillData[0].skillName);
            cooltime = 5.0f;
        }
        if (skillData[0].skillName == "�ΰŽ���")
        {
            Debug.Log(skillData[0].skillName);
            cooltime = 5.0f;
        }
        if (skillData[1].skillName == "����")
        {
            shield += 1;
            Debug.Log(skillData[1].skillName);
        }
        if (skillData[1].skillName == "�̵��ӵ� ����")
        {
            speed *= 2;
            Debug.Log(skillData[1].skillName);
        }
        if (skillData[1].skillName == "���� ������ ��")
        {
            coinAdd *= 2;
            Debug.Log(skillData[1].skillName);
        }
        if (skillData[2].skillName == "������ ��")
        {
            Debug.Log(skillData[2].skillName);
        }
        if (skillData[2].skillName == "�Ŵ��� ��")
        {
            Debug.Log(skillData[2].skillName);
        }
        if (skillData[2].skillName == "���� ���ڴ�")
        {
            Debug.Log(skillData[2].skillName);
        }
        skillImage.sprite = skillData[0].skillSprite;
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

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
        if (skillused)
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
        Debug.Log(collision.name);
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
        if (skillused == false && skillData[0].skillName == "����")
        {
            Debug.Log("����!!");
            skillButton.image.fillAmount = 0;
            skillused = true;
        }
        if (skillused == false && skillData[0].skillName == "������!")
        {
            Debug.Log("������!");
            skillButton.image.fillAmount = 0;
            skillused = true;
        }
        if (skillused == false && skillData[0].skillName == "�ΰŽ���")
        {
            GameObject[] forDestroy = GameObject.FindGameObjectsWithTag("ddong");
            {
                for (int i = 0; i < forDestroy.Length; i++)
                {
                    if (forDestroy[i].transform.localPosition.y <= 1.4f)
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
