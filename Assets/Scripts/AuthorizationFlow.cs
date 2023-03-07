using UnityEngine;
using UnityEngine.UI;
public class AuthorizationFlow:MonoBehaviour{
    [SerializeField]private LoginPanel loginPanel;
    [SerializeField]private AccountPanel accountPanel;
    [SerializeField]private RegisterPanel registerPanel;
    private AbstractPanel _current;


    void Start(){Run();}    
    void OnEnable(){
        loginPanel.OnLoginComplete+=OnLoginComplete;
        accountPanel.OnLogOut+=OnAccountLogOut;
        loginPanel.OnRegisterClick += ShowRegisterPanel;
        registerPanel.OnRegistrated+=ShowAccountPanel;
    }
    void Ondisable(){
        loginPanel.OnLoginComplete-=OnLoginComplete;
        accountPanel.OnLogOut-=OnAccountLogOut;
        loginPanel.OnRegisterClick -= ShowRegisterPanel;
        registerPanel.OnRegistrated-=ShowAccountPanel;
    }
    
    private void HidePrevious(){
        if(_current == null){
            return;
        }
        _current.Hide();
    }
    private void SetCurrent(AbstractPanel panel){
        _current = panel;
    }

    private void Run(){

        if(Session.HasProfile()){
            Session.GetProfile();
            ShowAccountPanel();
            return;
        }
        ShowLoginPanel();
    }
    private void ShowLoginPanel(){
        HidePrevious();
        loginPanel.Show();
        SetCurrent(loginPanel);
    }
     private void ShowAccountPanel()
        {
            HidePrevious();
            accountPanel.Setup(Session.UserData);
            accountPanel.Show();
            SetCurrent(accountPanel);
        }
    private void OnLoginComplete(bool success){
        if(success){
            Session.SaveProfile();
            ShowAccountPanel();
            return;
        }
        Debug.LogError("Error");
    }
    private void OnAccountLogOut(){
        Session.SetUserData(null);
        Session.ClearProfile();
        ShowLoginPanel();
    }
    private void ShowRegisterPanel(){
        HidePrevious();
        registerPanel.Show();
        SetCurrent(registerPanel);
    }
    private void SaveProfile(string username,string password){
        
    }
}