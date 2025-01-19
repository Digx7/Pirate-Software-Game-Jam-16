using UnityEngine;

public class BucketCharacter : PlayerCharacter
{
    // Called in the process of being spawned by the GameMode
    public override void Setup(int newID = 0)
    {
        base.Setup(newID);
    }

    // Called as soon as the player is loaded into the scene
    protected override void Start()
    {
        base.Start();
    }

    // Called once per frame
    public void Update()
    {

    }
}
