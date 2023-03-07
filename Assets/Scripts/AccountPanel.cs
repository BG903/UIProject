using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public delegate void LogOutDelegate();
public class AccountPanel : AbstractPanel
    {
        [SerializeField] private TMP_InputField userNameInputField;
        [SerializeField] private Button logOutButton;
        public event LogOutDelegate OnLogOut;

        public void Setup(UserData userData)
        {
            if(userData != null)
            userNameInputField.text = userData.UserName;
        }

        private void OnEnable()
        {
            logOutButton.onClick.AddListener(OnLogOutButtonClicked);
        }

        private void OnDisable()
        {
            logOutButton.onClick.RemoveListener(OnLogOutButtonClicked);
        }

        private void OnLogOutButtonClicked()
        {
            OnLogOut?.Invoke();
        }
    }
