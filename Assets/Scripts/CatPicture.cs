using UnityEngine;

// INHERITANCE
public class CatPicture : Picture
{
    // POLYMORPHISM
    protected override void MakeSound()
    {
        Debug.Log("Cat sound");
        base.MakeSound();
    }
}
