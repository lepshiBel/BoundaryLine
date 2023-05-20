using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private const string FADER_PATH = "Fader";

    [SerializeField] private Animator animator;

    private static Fader instance;

    public static Fader Instance 
    { 
        get 
        { 
            if (instance == null)
            {
                var prefab = Resources.Load<Fader>(FADER_PATH);
                instance = Instantiate(prefab);
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        } 
    }

    public bool IsFading { get; private set; }

    private Action fadedInCallback;
    private Action fadedOutCallback;

    public void FadeIn(Action fadedInCallback)
    {
        if (IsFading) 
        {
            return;
        }

        IsFading = true;
        this.fadedInCallback = fadedInCallback;
        animator.SetBool("faded", true);
    }

    public void FadeOut(Action fadedOutCallback)
    {
        if (IsFading)
        {
            return;
        }

        IsFading = true;
        this.fadedOutCallback = fadedOutCallback;
        animator.SetBool("faded", false);
    }

    private void Handle_FadeInAnimationOver()
    {
        fadedInCallback?.Invoke();
        fadedInCallback = null;
        IsFading = false;
    }

    private void Handle_FadeOutAnimationOver()
    {
        fadedOutCallback?.Invoke();
        fadedOutCallback = null;
        IsFading = false;
    }
}
