using UnityEngine;

// INHERITANCE
public class DogPicture : Picture
{
    // POLYMORPHISM
    protected override void MakeSound()
    {
        Debug.Log("Dog sound");
        base.MakeSound();
    }
}
