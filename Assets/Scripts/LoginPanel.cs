using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public delegate void LoginCompleteDelegate(bool success);

public class LoginPanel : AbstractPanel
{
    [SerializeField]private TMP_InputField usernameInputField;
    [SerializeField]private TMP_InputField passwordInputField;
    [SerializeField]private Button loginButton;
    [SerializeField]private Button registerButton;

    public event LoginCompleteDelegate OnLoginComplete;
    public event Action OnRegisterClick;

    void OnEnable(){
        loginButton.onClick.AddListener(OnLoginButtonClick);
        registerButton.onClick.AddListener(OnRegisterButtonClick);
    }
    void Ondisable(){
        loginButton.onClick.RemoveListener(OnLoginButtonClick);
        registerButton.onClick.RemoveListener(OnRegisterButtonClick);
    }

    private void OnLoginButtonClick(){
        string username = usernameInputField.text;
        string password = passwordInputField.text;


        if(DataStore.TryFind(username,password,out UserData userData)){
            Session.SetUserData(userData);
            OnLoginComplete?.Invoke(true);
        }else{
            OnLoginComplete?.Invoke(false);
        }


    }
    private void OnRegisterButtonClick(){
        OnRegisterClick?.Invoke();
    }
}
