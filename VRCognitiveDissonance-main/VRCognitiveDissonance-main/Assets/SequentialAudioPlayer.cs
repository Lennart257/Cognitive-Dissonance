using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro; // For TextMeshPro

[RequireComponent(typeof(AudioSource))]
public class SequentialAudioPlayer : MonoBehaviour
{
    public List<AudioClip> audioClips;      // Assign your audio clips in the Inspector
    public GameObject textQuad1;            // Assign Quad 1 in the Inspector
    public GameObject textQuad2;            // Assign Quad 2 in the Inspector
    public PlayableDirector timeline1;      // Assign Timeline 1 in the Inspector
    public PlayableDirector timeline2;      // Assign Timeline 2 in the Inspector

    public string text1 = "Option 1";        // Text label for Quad 1
    public string text2 = "Option 2";        // Text label for Quad 2

    private AudioSource audioSource;
    private Queue<AudioClip> clipQueue;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clipQueue = new Queue<AudioClip>(audioClips);

        // Hide clickable quads initially
        textQuad1.SetActive(false);
        textQuad2.SetActive(false);

        // Add TextMeshPro text to the quads
        AddTextToQuad(textQuad1, text1);
        AddTextToQuad(textQuad2, text2);

        StartCoroutine(PlayAudioQueue());
    }

    IEnumerator PlayAudioQueue()
    {
        while (clipQueue.Count > 0)
        {
            AudioClip currentClip = clipQueue.Dequeue();
            audioSource.clip = currentClip;
            audioSource.Play();

            yield return new WaitForSeconds(currentClip.length);
        }

        ShowTextOptions();
    }

    void ShowTextOptions()
    {
        textQuad1.SetActive(true);
        textQuad2.SetActive(true);
    }

    public void OnText1Clicked()
    {
        timeline1.Play();
    }

    public void OnText2Clicked()
    {
        timeline2.Play();
    }

    void AddTextToQuad(GameObject quad, string content)
    {
        GameObject textGO = new GameObject("QuadText");
        textGO.transform.SetParent(quad.transform);
        textGO.transform.localPosition = Vector3.zero;
        textGO.transform.localRotation = Quaternion.identity;
        textGO.transform.localScale = Vector3.one * 0.1f; // Adjust as needed

        TextMeshPro tmp = textGO.AddComponent<TextMeshPro>();
        tmp.text = content;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.fontSize = 10;
        tmp.color = Color.black;

       
    }
}
