using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class FireBaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth; //로그인 / 회원가입 등에 사용
    private FirebaseUser user; //인증이 완료된 유저 정보

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
                    Debug.Log("회원가입 취소");
                    return;
                }
                if(task.IsFaulted)
                {
                    Debug.Log("회원가입 실패");
                    return;
                }
                FirebaseUser newUser = task.Result;
                Debug.Log("회원가입 완료");
            });
    }
    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).
            ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.Log("로그인 취소");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.Log("로그인 실패");
                    return;
                }
                FirebaseUser newUser = task.Result;
                Debug.Log("로그인 완료");
            });
    }
}
