using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRoidSDK.Examples.Core.Localize;
using VRoidSDK.Examples.CharacterModelExample.View;
using VRoidSDK.Examples.CharacterModelExample.Controller;

namespace VRoidSDK.Examples.CharacterModelExample
{
    public class MainSystem : CharacterModelExampleEventHandler
    {
        [SerializeField] private Text _selectModelText;
        [SerializeField] private Text _licenseCheckText;
        [SerializeField] private Text _modelPropertyText;

        public override void OnModelLoaded(string modelId, GameObject go)
        {
            DeleteAllChildren();
            go.transform.parent = transform;
        }

        public override void OnLangChanged(Translator.Locales locale)
        {
            switch (locale)
            {
                case Translator.Locales.JA:
                    _selectModelText.text = "モデル選択";
                    _licenseCheckText.text = "ライセンス";
                    _modelPropertyText.text = "モデル情報";
                    break;
                case Translator.Locales.EN:
                    _selectModelText.text = "Select Model";
                    _licenseCheckText.text = "License";
                    _modelPropertyText.text = "Model Property";
                    break;
                default:
                    break;
            }
        }

        private void DeleteAllChildren()
        {
            var transformList = new List<Transform>();
            foreach (Transform child in this.gameObject.transform)
            {
                transformList.Add(child);
            }
            this.gameObject.transform.DetachChildren();
            foreach (Transform child in transformList)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
