//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class BackgroundManager : MonoBehaviour
{
    Image _bgImg;
    // Start is called before the first frame update
    void Start()
    {
        Addressables.LoadAssetAsync<Sprite>( "Assets/Images/bguo.jpg" ).Completed += sprite =>
        {
            _bgImg = GetComponent<Image>();
            _bgImg.type = Image.Type.Simple;
            _bgImg.sprite = Instantiate( sprite.Result );
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}