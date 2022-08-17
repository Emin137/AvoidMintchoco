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

    public List<SkillData> skillData;
    private void Start()
    {
        skillData = SkillManager.GetResultSkill();
        Debug.Log(skillData[0].skillName);
        Debug.Log(skillData[1].skillName);
        Debug.Log(skillData[2].skillName);
        Debug.Log(skillData[0].skillSprite);
        skillImage.sprite = skillData[0].skillSprite;
    }
    private void Update()
    {
        speed = 5.0f;
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
        if (collision.name == "ddong(Clone)")
        {
            dieMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
