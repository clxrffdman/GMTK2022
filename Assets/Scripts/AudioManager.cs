using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public GameObject SFXInstance;
    public List<AudioClip> protagVoiceLines;
    public List<AudioClip> enemyVoiceLines;
    public List<AudioClip> generalSFX;
    public List<AudioClip> boardSFX;
    public List<AudioClip> uiSFX;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayProtagLine(int input)
    {
        var sound = Instantiate(SFXInstance, transform.position, Quaternion.identity);
        sound.transform.parent = GameManager.Instance.soundParent;
        sound.GetComponent<SoundSample>().SpawnSound(protagVoiceLines[input], 0, 1);
    }
    public void PlayEnemyLine(int input)
    {
        var sound = Instantiate(SFXInstance, transform.position, Quaternion.identity);
        sound.transform.parent = GameManager.Instance.soundParent;
        sound.GetComponent<SoundSample>().SpawnSound(enemyVoiceLines[input], 0, 1);
    }
    public void PlayGeneralSFX(int input)
    {
        var sound = Instantiate(SFXInstance, transform.position, Quaternion.identity);
        sound.transform.parent = GameManager.Instance.soundParent;
        sound.GetComponent<SoundSample>().SpawnSound(generalSFX[input], 0, 1);
    }
    public void PlayBoardSFX(int input)
    {
        var sound = Instantiate(SFXInstance, transform.position, Quaternion.identity);
        sound.transform.parent = GameManager.Instance.soundParent;
        sound.GetComponent<SoundSample>().SpawnSound(boardSFX[input], 0, 1);
    }
    public void PlayUISFX(int input)
    {
        var sound = Instantiate(SFXInstance, transform.position, Quaternion.identity);
        sound.transform.parent = GameManager.Instance.soundParent;
        sound.GetComponent<SoundSample>().SpawnSound(uiSFX[input], 0, 1);
    }

}
