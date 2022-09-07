using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    [SerializeField] GameObject GlideVoice;
    [SerializeField] GameObject ClickVoice;


    public void playAudio1()
    {
       GameObject audio= Instantiate(GlideVoice, transform.position, Quaternion.identity);
        Destroy(audio, 1f);
    }
      
    
    public void playAudio2()
    {
        GameObject audio = Instantiate(ClickVoice, transform.position, Quaternion.identity);
        Destroy(audio, 1f);
    }
}
