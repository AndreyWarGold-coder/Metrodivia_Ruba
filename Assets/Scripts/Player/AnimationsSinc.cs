using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsSinc : MonoBehaviour
{
    [SerializeField] private Animator[] _animators;
    [SerializeField] private string[] _prefixs;
    [SerializeField] private string _defoultPrefix = "";

    private void Start()
    {
        for (int i = 0; i < _prefixs.Length; i++)
        {
            _prefixs[i] = _defoultPrefix;
        }
    }

    public string GetState()
    {
        return _animators[0].GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }

    public void SetAnimation(string nameAnimation)
    {
        for (int i = 0; i < _animators.Length; i++)
        {
            _animators[i].Play(_prefixs[i] + nameAnimation);
        }
    }
}
