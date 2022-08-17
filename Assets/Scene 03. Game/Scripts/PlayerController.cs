using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Button skillButton;
    [SerializeField] Image skillImage;
    public float speed;
    private float edge = 2.5f;
    public GameObject dieMenu;
    private int shield, coinAdd;

    public List<SkillData> skillData;
    private void Start()
    {
        speed = 5.0f;
        coinAdd = 1;
        shield = 0;
        skillData = SkillManager.GetResultSkill();
        if (skillData[0].skillName == "점멸")
        {
            Debug.Log(skillData[0].skillName);
        }
        if (skillData[0].skillName == "얼음땡!")
        {
            Debug.Log(skillData[0].skillName);
        }
        if (skillData[0].skillName == "핑거스냅")
        {
            Debug.Log(skillData[0].skillName);
        }
        if (skillData[1].skillName == "원코")
        {
            shield += 1;
            Debug.Log(skillData[1].skillName);
        }
        if (skillData[1].skillName == "이동속도 증가")
        {
            speed *= 2;
            Debug.Log(skillData[1].skillName);
        }
        if (skillData[1].skillName == "묻고 더블로 가")
        {
            coinAdd *= 2;
            Debug.Log(skillData[1].skillName);
        }
        if (skillData[2].skillName == "무수한 똥")
        {
            Debug.Log(skillData[2].skillName);
        }
        if (skillData[2].skillName == "거대한 똥")
        {
            Debug.Log(skillData[2].skillName);
        }
        if (skillData[2].skillName == "나는 부자다")
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "ddong(Clone)" && shield == 0)
        {
            dieMenu.SetActive(true);
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
}
