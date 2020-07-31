using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    public static GameAssets i;

    private void Awake()
    {
        i = this;
    }

    public Sprite rangeSprite;
    public Sprite checkSprite;
    public Sprite dustCloud;

    public static GameObject SpriteToGameObject(Sprite sprite)
    {
        GameObject newGameObject = new GameObject();
        newGameObject.AddComponent<SpriteRenderer>().sprite = sprite;
        return newGameObject;
    }

    public SoundAudioClip[] soundAudioClipArray;

    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}