using UnityEngine;

// INHERITANCE
public class CowPicture : Picture
{
    // POLYMORPHISM
    protected override void MakeSound()
    {
        Debug.Log("Cow sound");
        base.MakeSound();
    }
}
