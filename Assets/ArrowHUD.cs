using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ArrowHUD : MonoBehaviour
{
    [SerializeField]
    private List<Sprite>arrowTex = new List<Sprite>(); 
    
    [SerializeField]
    private List<GameObject> arrows = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateImage(int index, int arrowIndex)
    {
        arrows[index].GetComponent<Image>().sprite =arrowTex[arrowIndex];
    }
}
