using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace MonoGame2026;

public class AudioManager
{
    private static ResourcesManager<Song> _songManager;
    private static ResourcesManager<SoundEffect> _soundEffectManager;
    
    private static List<SoundEffectInstance> _soundEffectsInstances = new();

    private static float prevSongVolume = 1;
    private static float prevSFXVolume = 1;

    public static void AddSong(string name, string fileName)
    {
        ResourcesManager<Song>.LoadResource(name, fileName);
    }
    
    public static void AddSoundEffect(string name, string fileName)
    {
        ResourcesManager<SoundEffect>.LoadResource(name, fileName);
    }

    public static Song GetSong(string name)
    {
        return ResourcesManager<Song>.GetResource(name);
    }

    public static SoundEffectInstance PlaySongEffect(string name, bool isLooping = false, float volume = 1, float pitch = 0 )
    {
        SoundEffect soundEffect = ResourcesManager<SoundEffect>.GetResource(name);
        SoundEffectInstance instance = soundEffect?.CreateInstance();
        if (instance != null)
        {
            _soundEffectsInstances.Add(instance);
            instance.Volume = volume;
            instance.Pitch = pitch;
            instance.IsLooped = isLooping;
            
            instance.Play();
        }


        return instance;
    }

    public static void PlaySong(string sondToPlay, float volume = 1)
    {
        Song song = GetSong(sondToPlay);
        if (song == null) return;
        
        MediaPlayer.Volume = volume;
        MediaPlayer.IsRepeating = true;
        
        if (MediaPlayer.State == MediaState.Playing)
            MediaPlayer.Stop();
        
        MediaPlayer.Play(song);
    }

    public static bool IsPaused
    {
        get
        {
            return MediaPlayer.State == MediaState.Paused;
        }
        set
        {
            if (value)
            {
                MediaPlayer.Pause();
                _soundEffectsInstances.ForEach((effect) => effect.Pause());
            }
            else
            {
                MediaPlayer.Resume();
                _soundEffectsInstances.ForEach((effect) => effect.Resume());
            }
        }
    }

    public static bool IsMuted
    {
        get
        {
            return MediaPlayer.IsMuted;
        }
        set
        {
            if (value)
            {
                // mute the song
                prevSongVolume = MediaPlayer.Volume;
                MediaPlayer.IsMuted = value;

                foreach (var effect in _soundEffectsInstances)
                {
                    prevSFXVolume = effect.Volume;
                    effect.Volume = 0;
                }
            }
            else
            {
                // umute the song
                MediaPlayer.Volume = prevSongVolume;
                MediaPlayer.IsMuted = value;

                foreach (var effect in _soundEffectsInstances)
                {
                    effect.Volume = prevSFXVolume;
                }
            }
        }
    }
}