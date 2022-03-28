using UnityEngine;
using UnityEngine.SceneManagement;

class MenuUI : MonoBehaviour
{
    public void EnableMenu()
    {
        gameObject.SetActive(true);
    }
    public void OffMenu()
    {
        gameObject.SetActive(false);
    }
    public void Continue()
    {
        gameObject.SetActive(false);
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}