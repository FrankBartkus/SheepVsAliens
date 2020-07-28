using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{

    public enum Sound
    {
        AlienBeam,
        AlienTalk,
        AttackBee,
        AttackChicken,
        AttackGoat,
        ButtonClick,
        ButtonOver,
        CashPickup,
        DoorClose,
        DoorOpen,
        Error,
        LevelTheme,
        LifeLost,
        Pause,
        PumpkinExplosion,
        TowerPlace,
        TowerPurchase,
        TowerUpgrade,
        Unpause,
    }

    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        soundGameObject.AddComponent<DestroySoundOnStop>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }
    public static void LoopSound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Loop");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = GetAudioClip(sound);
        audioSource.Play();
    }
    public static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
            if (soundAudioClip.sound == sound)
                return soundAudioClip.audioClip;
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
