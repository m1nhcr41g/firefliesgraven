using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int current_reCallpoint;
    [SerializeField] private int pointThreshold = 1;
    [SerializeField] private GameObject portal;
    [SerializeField] private Spawner[] spawners;
    private bool portalCalled = false;
    [SerializeField] private Image pointBar;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (portal != null)
        {
            portal.SetActive(false);
        }
        current_reCallpoint = 0;
        UpdatePointBar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addRecallPoint()
    {
        if (portalCalled)
        {
            return;
        }
        current_reCallpoint += 1;
        UpdatePointBar();
        if (current_reCallpoint == pointThreshold)
        {
            callPortal();
        }
    }

    private void callPortal()
    {
        portalCalled = true;
        if (portal != null)
        {
            portal.SetActive(true);
        }
        foreach (Spawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
      
    }
    private void UpdatePointBar()
    {

        if (pointBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)current_reCallpoint / (float)pointThreshold);
            pointBar.fillAmount = fillAmount;
        }
    }

    
}
