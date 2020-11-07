using System.Text;
using VRoidSDK.Examples.Core.View.Parts;
using VRoidSDK;
using VRoidSDK.Decorator;
using UnityEngine;

namespace VRoidSDK.Examples.CharacterModelExample.View
{
    public class GltfMaterialItem : VerticalScrollItem<GltfMaterial>
    {
        [SerializeField] private Message _message;

        public override void Init(GltfMaterial baseData)
        {
            var decorator = new TextDecorator(baseData.name);
            var stringBuilder = new StringBuilder(decorator.Color("#B1CC29").Bold().Text);

            if (baseData.extensions != null)
            {
                stringBuilder.Append("\n");
                foreach (var x in baseData.extensions)
                {
                    stringBuilder.AppendLine("\t" + x.Key + "：" + x.Value);
                }
            }

            _message.Text = stringBuilder.ToString();
        }
    }
}
