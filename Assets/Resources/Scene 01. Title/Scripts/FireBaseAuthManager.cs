using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class FireBaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth; //�α��� / ȸ������ � ���
    private FirebaseUser user; //������ �Ϸ�� ���� ����

    public InputField email;
    public InputField password;

    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void Create()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).
            ContinueWith(task =>
            {
                if(task.IsCanceled)
                {
                    Debug.Log("ȸ������ ���");
                    return;
                }
                if(task.IsFaulted)
                {
                    Debug.Log("ȸ������ ����");
                    return;
                }
                FirebaseUser newUser = task.Result;
                Debug.Log("ȸ������ �Ϸ�");
            });
    }
    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).
            ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.Log("�α��� ���");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.Log("�α��� ����");
                    return;
                }
                FirebaseUser newUser = task.Result;
                Debug.Log("�α��� �Ϸ�");
            });
    }
}
