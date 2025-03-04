using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float _startingPos;
    private float _lengthOfSprite;
    public float amountOfParallax;
    public GameObject MainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        _startingPos = transform.position.x;
        _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = MainCamera.transform.position;
        float temp = pos.x * (1-amountOfParallax);
        float dist = pos.x * amountOfParallax;
        
        Vector3 newPos = new Vector3(_startingPos+dist,transform.position.y,transform.position.z);
        
        transform.position = newPos;

        if (temp > _startingPos + (_lengthOfSprite / 2))
        {
            _startingPos += _lengthOfSprite;
        }else if (temp < _startingPos - (_lengthOfSprite / 2))
        {
            _startingPos -= _lengthOfSprite;
        }
    }
}
