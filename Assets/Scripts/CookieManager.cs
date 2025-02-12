using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CookieManager : MonoBehaviour
{
    private int cookies = 0;
    [SerializeField] private TMP_Text textfield;
    [SerializeField] ARCameraManager cmrAR;
    [SerializeField] ARTrackedImageManager m_TrackedImageManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void OnEnable() => m_TrackedImageManager.trackablesChanged.AddListener(OnChanged);
    void OnDisable() => m_TrackedImageManager.trackablesChanged.RemoveListener(OnChanged);
    void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            // Handle added event , added (that is, first detected)
            AddCookie();
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // Handle updated event
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
        }
    }

    public void AddCookie()
    {
        cookies++;
        UpdateCookies();
        return;
    }

    public void EatCookie()
    {
        if (cookies >= 1)
        {
            cookies--;
        }
        UpdateCookies();
        return ;
    }

    public int GetCookies() { return cookies; }

    private void UpdateCookies()
    {
        //Debug.Log(cookies + "updating");
        textfield.text = cookies + " cookies";
    }

    public void SwitchCamera()
    {

        //TODO: swithing broke when image tracking was added
        m_TrackedImageManager.enabled = false;
        Debug.Log("Switching camera. Currently facing: " + cmrAR.currentFacingDirection.ToString());
        if (cmrAR.currentFacingDirection == CameraFacingDirection.World)
        {
            cmrAR.requestedFacingDirection = CameraFacingDirection.User;
        }
        else if (cmrAR.currentFacingDirection == CameraFacingDirection.User)
        {
            cmrAR.requestedFacingDirection = CameraFacingDirection.World;
        }
        m_TrackedImageManager.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
