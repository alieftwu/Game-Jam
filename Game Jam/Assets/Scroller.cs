using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _speed = 1.0f; // Adjust the scrolling speed here
    [SerializeField] private bool _scrollHorizontally = true; // Toggle horizontal scrolling

    void Update()
    {
        float x = _scrollHorizontally ? _speed : 0.0f;
        float y = _scrollHorizontally ? 0.0f : _speed;

        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(x, y) * Time.deltaTime, _img.uvRect.size);
    }
}
