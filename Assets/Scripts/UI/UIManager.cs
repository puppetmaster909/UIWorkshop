using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [System.Serializable]
    public struct Screen
    {
        public string name;
        public GameObject screen;
        public Animator screenAnimator;
    }

    public List<Screen> screens = new List<Screen>();
    public int curScreen;

    public void ShowScreen(string name)
    {
        for (int i = 0; i < screens.Count; i++)
        {
            if (screens[i].name.Equals(name))
            {
                StartCoroutine(ShowScreenCoroutine(i));
            }
        }
    }

    public IEnumerator ShowScreenCoroutine(int index)
    {
        // Found screen, disable old one, enable new one, keep new reference
        if (screens[curScreen].screenAnimator != null)
        {
            screens[curScreen].screenAnimator.SetTrigger("Close");
            yield return new WaitForSeconds(1.0f);
        }
        screens[curScreen].screen.SetActive(false);
        screens[index].screen.SetActive(true);
        curScreen = index;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            GameObject.Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
}
