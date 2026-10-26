using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace MonoGameSummer2026;

public class AudioManager
{
    static ContentManager _content;
    static Dictionary<string, Song> songs = new();
    static Dictionary<string, SoundEffect> soundEffects = new();
    static List<SoundEffectInstance> soundEffectInstances = new();

    static float previousSoundEffectVolume;
    static float previousSongVolume;
    public static bool IsMuted { get; private set; }
    
    public static float SongVolume
    {
        get
        {
            if(IsMuted)
            {
                return 0.0f;
            }

            return MediaPlayer.Volume;
        }
        set
        {
            if(IsMuted)
            {
                return;
            }

            MediaPlayer.Volume = Math.Clamp(value, 0.0f, 1.0f);
        }
    }
    
    public static float SoundEffectVolume
    {
        get
        {
            if(IsMuted)
            {
                return 0.0f;
            }

            return SoundEffect.MasterVolume;
        }
        set
        {
            if(IsMuted)
            {
                return;
            }

            SoundEffect.MasterVolume = Math.Clamp(value, 0.0f, 1.0f);
        }
    }  
    
    public static void PauseAudio()
    {
        // Pause any active songs playing.
        MediaPlayer.Pause();

        // Pause any active sound effects.
        foreach (SoundEffectInstance soundEffectInstance in soundEffectInstances)
        {
            soundEffectInstance.Pause();
        }
    }
    
    public static void ResumeAudio()
    {
        // Resume paused music
        MediaPlayer.Resume();

        // Resume any active sound effects.
        foreach (SoundEffectInstance soundEffectInstance in soundEffectInstances)
        {
            soundEffectInstance.Resume();
        }
    }
    
    public static void MuteAudio()
    {
        // Store the volume so they can be restored during ResumeAudio
        previousSongVolume = MediaPlayer.Volume;
        previousSoundEffectVolume = SoundEffect.MasterVolume;

        // Set all volumes to 0
        MediaPlayer.Volume = 0.0f;
        SoundEffect.MasterVolume = 0.0f;

        IsMuted = true;
    }

    /// <summary>
    /// Unmutes all audio to the volume level prior to muting.
    /// </summary>
    public static void UnmuteAudio()
    {
        // Restore the previous volume values.
        MediaPlayer.Volume = previousSongVolume;
        SoundEffect.MasterVolume = previousSoundEffectVolume;

        IsMuted = false;
    }
    public AudioManager(ContentManager contentManager)
    {
        _content = contentManager;
    }
    public static void AddSong(string songName, string fileName)
    {
        if (!songs.ContainsKey(songName))
            songs[songName] = _content.Load<Song>(fileName);
    }

    private static Song GetSong(string songName)
    {
        if (songs == null) return null;
        
        return songs.GetValueOrDefault(songName);
    }

    public static void PlaySong(string songName, bool isRepeating = true, float volume = 1)
    {
        var song = GetSong(songName);
        if (song == null) return;
     
        if (MediaPlayer.State == MediaState.Playing)
            MediaPlayer.Stop();
        
        MediaPlayer.Volume = volume;
        MediaPlayer.Play(song);
        MediaPlayer.IsRepeating = isRepeating;
    }

    public static void AddSoundEffect(string soundEffectName, string fileName)
    {
        if (soundEffects == null) return;
        
        if (!soundEffects.ContainsKey(soundEffectName))
            soundEffects[soundEffectName] = _content.Load<SoundEffect>(fileName);
    }
    
    private static SoundEffectInstance GetSoundEffectInstance(string soundEffectName)
    {
        SoundEffectInstance instance = soundEffects.GetValueOrDefault(soundEffectName)?.CreateInstance();
        soundEffectInstances.Add(instance);
        return instance;
    }

    public static void PlaySoundEffect(string soundEffectName, bool isRepeating = false, float volume = 1)
    {
        SoundEffectInstance instance = GetSoundEffectInstance(soundEffectName);
        if (instance == null) return;
        
        instance.Volume = volume;  
        instance.IsLooped = isRepeating;
        instance.Play();
        
    }
}