using UnityEngine;

// INHERITANCE
public class KogutPicture : Picture
{
    // POLYMORPHISM
    protected override void MakeSound()
    {
        Debug.Log("Kogut sound");
        base.MakeSound();
    }
}
