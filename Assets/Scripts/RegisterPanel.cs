using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public delegate void OnRegistratedDelegate();
public class RegisterPanel:AbstractPanel{

    [SerializeField]private Button RegisterButton;
    [SerializeField]private TMP_InputField usernameInputField;
    [SerializeField]private TMP_InputField passwordInputField;
    [SerializeField]private LoginPanel loginPanel;

    public event OnRegistratedDelegate OnRegistrated;

     private void OnEnable()
        {
            RegisterButton.onClick.AddListener(OnRegisterButtonClick);
        }

        private void OnDisable()
        {
            RegisterButton.onClick.AddListener(OnRegisterButtonClick);
        }

        private void OnRegisterButtonClick(){
            UserData userdata = new UserData(usernameInputField.text,passwordInputField.text);
            usernameInputField.text = "";
            passwordInputField.text = "";
            DataStore.AddUser(userdata);
            Session.SetUserData(userdata    );
            OnRegistrated?.Invoke();
        }
}