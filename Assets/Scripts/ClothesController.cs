using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesController : MonoBehaviour {
    [SerializeField]
    private string className;   
    [SerializeField]
    private string clothesType;    
    [SerializeField]
    private bool isClothesNameRequired;    
    [SerializeField]
    private string clothesName;    

    private string _path = "";

    private SpriteRenderer _spriteRenderer;

    private const string FolderInit = "Character";
    
    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateClothesPath();
    }


    private void LateUpdate() {
        UpdateClothesPath();
        
        var spritesList = Resources.LoadAll<Sprite>(_path);
        var foundSprite = false;

        if ((!isClothesNameRequired) || ((isClothesNameRequired) && (clothesName.Trim() != ""))) {
            foreach (var sprite in spritesList) {
                if (_spriteRenderer.sprite.name == sprite.name) {
                    _spriteRenderer.sprite = sprite;
                    foundSprite = true;
                    break;
                }
            }
        }

        _spriteRenderer.enabled = foundSprite;
    }

    private void UpdateClothesPath() {
        _path = FolderInit + "/" + className + "/" + clothesType;

        if (isClothesNameRequired) {
            _path += "/" + clothesName;
        }
    }
}
