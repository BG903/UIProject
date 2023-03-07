using UnityEngine;

public abstract class AbstractPanel:MonoBehaviour{
    public void Show(){
        gameObject.SetActive(true);
    }
    public void Hide(){
        gameObject.SetActive(false);
    }
}
