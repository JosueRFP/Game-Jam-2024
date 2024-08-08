using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject creditsPainel;
    public Transform normalCamTransform;
    public Transform newCamTransform;

    public void SetCamPos(bool newPos) 
    {
        var cam = Camera.main;
        if (newPos) 
        {
            cam.transform.position = new Vector3(newCamTransform.position.x,newCamTransform.position.y, newCamTransform.position.z);
            cam.transform.rotation = new Quaternion (newCamTransform.rotation.x,newCamTransform.rotation.y, newCamTransform.rotation.z, 0);

            cam.GetComponent<CamerMove>().enabled = false;
        }
        else 
        { 
            cam.transform.position = new Vector3(normalCamTransform.position.x, normalCamTransform.position.y, normalCamTransform.position.z);

            cam.transform.rotation = new Quaternion (normalCamTransform.rotation.x, normalCamTransform.rotation.y,normalCamTransform.rotation.z,normalCamTransform.rotation.w);

            cam.GetComponent<CamerMove>().enabled = true;
        }
    }
    
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
