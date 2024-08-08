using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject creditsPainel;

    
    public void Teleport(string tp)
    {
        SceneManager.LoadScene(tp);
    }
    
    public void OpenCreditsBTN()
    {
        creditsPainel.SetActive(true);
    }
    
    public void CloseCreditsBTN()
    {
        creditsPainel.SetActive(false);
    }

    public void QuitBTN()
    {
        Application.Quit();
        Debug.Log("Quitou");
    }
}
