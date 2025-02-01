using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : Character
{
    [SerializeField] private IntChannel OnPlayerCharacterFinishedSetup;
    [SerializeField] private BooleanChannel UpdateIfIsInMenuChannel;
    [SerializeField] private CameraManager cameraManager;
    
    public UnityEvent OnStartCharge;
    public UnityEvent OnEndCharge;
    public UnityEvent OnUseAbility1;
    public UnityEvent OnUseAbility2;
    public UnityEvent OnUseAbility3;
    public BooleanEvent OnIsInMenu;

    private Vector2 desiredMoveDirection;
    private bool isInMenu = false;

    // CAMERA FUNCTIONS ===========================================

    public bool ConnectCameraManager(CameraManager newCameraManager)
    {
        if(!IsCameraManagerValid(newCameraManager)) return false;

        if(newCameraManager == cameraManager) return true;
        
        if(cameraManager != null)
        {
            Debug.LogWarning("The CameraManager: " + newCameraManager + " tried to connect to the PlayerCharacter " + this + " but it is already connected to the CameraManager: " + cameraManager + ".  If this was intentional use ForceConnectCameraManager instead");
            return false;
        }

        cameraManager = newCameraManager;
        return true;
    }

    public void ForceConnectCameraManager(CameraManager newCameraManager)
    {
        if(!IsCameraManagerValid(newCameraManager)) return;
        if(newCameraManager == cameraManager) return;
        
        cameraManager = newCameraManager;
    }

    private bool IsCameraManagerValid(CameraManager newCameraManager)
    {
        if(newCameraManager == null) return false;
        else return true;
    }

    // SETUP FUNCTIONS =============================================

    protected override void OnEnable()
    {
        UpdateIfIsInMenuChannel.channelEvent.AddListener(SetIsInMenu);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        UpdateIfIsInMenuChannel.channelEvent.RemoveListener(SetIsInMenu);
    }
    
    public override void Setup(int newID = 0)
    {
        base.Setup(newID);

        OnPlayerCharacterFinishedSetup.Raise(ID);
    }

    protected override void Start()
    {
        desiredMoveDirection = new Vector2();
    }

    public void SetIsInMenu(bool value)
    {
        isInMenu = value;
        OnIsInMenu.Invoke(isInMenu);
    }

    // PLAYER ACTIONS ===============================================

    public void UpdateDesiredMoveDirection(Vector2 newDesiredDirection)
    {
        desiredMoveDirection = newDesiredDirection;
    }

    public void Jump()
    {

    }

    public void Fire1()
    {

    }

    public void Fire2()
    {

    }

    public void StartCharge()
    {
        OnStartCharge.Invoke();
    }

    public void EndCharge()
    {
        OnEndCharge.Invoke();
    }

    public void UseAbility1()
    {
        if(isInMenu)return;

        OnUseAbility1.Invoke();
    }

    public void UseAbility2()
    {
        if(isInMenu)return;
        
        OnUseAbility2.Invoke();
    }

    public void UseAbility3()
    {
        if(isInMenu)return;
        
        OnUseAbility3.Invoke();
    }

}