﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HoverImageColorAnimation : HoverEventAnimation
{
    public Color hoveredColor       = Color.white;
    private Color m_Color           = Color.white;
    private Color m_DefaultColor    = Color.white;

    [SerializeField]
    private Image m_Image = null;

    protected override IEnumerator EHoverBegin()
    {
        float _time = 0f;
        m_Color = m_Image.color;
        do
        {
            _time = Mathf.Clamp(_time + (Time.deltaTime * m_Multiplier), 0f, m_AnimationTime);
            m_Image.color = Color.Lerp(m_Color, hoveredColor, _time);
            yield return null;
        } while (_time != m_AnimationTime);
    }

    protected override IEnumerator EHoverEnd()
    {
        float _time = 0f;
        m_Color = m_Image.color;
        do
        {
            _time = Mathf.Clamp(_time + (Time.deltaTime * m_Multiplier), 0f, m_AnimationTime);
            m_Image.color = Color.Lerp(m_Color, m_DefaultColor, _time);
            yield return null;
        } while (_time != m_AnimationTime);
    }

    protected override bool Initialize()
    {
        if(null == m_Image)
        {
            m_Image = GetComponentInChildren<Image>();

            if(null == m_Image)
            {
                return false;
            }
        }

        m_DefaultColor = m_Image.color;
        return true;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        m_Image.color = m_DefaultColor;
    }
}
