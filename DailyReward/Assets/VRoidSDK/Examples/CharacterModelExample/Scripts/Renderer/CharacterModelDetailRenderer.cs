using System.Collections.Generic;
using VRoidSDK;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.Core.View;
using VRoidSDK.Examples.CharacterModelExample.Model;
using VRoidSDK.Examples.CharacterModelExample.View;
using VRoidSDK.Examples.Core.Localize;
using VRoidSDK.Localize;
using VRoidSDK.Decorator;

namespace VRoidSDK.Examples.CharacterModelExample.Renderer
{
    public class CharacterModelDetailRenderer : IRenderer
    {
        private bool _isActive;
        private string _characterName;
        private string _characterModelName;
        private string _characterPublisherName;
        private CharacterLicense _license;
        private WebImage _portraitImage;
        private bool _licenseAccepted;
        private bool _isLoaded;

        public CharacterModelDetailRenderer(CharacterModelDetailModel model)
        {
            if (model.CharacterModel == null)
            {
                return;
            }

            _license = model.CharacterModel.Value.license;
            _characterName = model.CharacterModel.Value.character.name;
            _characterModelName = model.CharacterModel.Value.name;
            _characterPublisherName = model.CharacterModel.Value.character.user.name;
            _portraitImage = model.CharacterModel.Value.portrait_image.sq150;

            _isActive = model.Active;
            _licenseAccepted = model.IsLicenseAccepted;
        }

        public CharacterModelDetailRenderer(LoadedCharacterModelModel model)
        {
            if (model.CharacterModel == null)
            {
                return;
            }

            _license = model.CharacterModel.Value.license;
            _characterName = model.CharacterModel.Value.character.name;
            _characterModelName = model.CharacterModel.Value.name;
            _characterPublisherName = model.CharacterModel.Value.character.user.name;
            _portraitImage = model.CharacterModel.Value.portrait_image.sq150;

            _isActive = model.Active;
            _isLoaded = true;
        }

        public void Rendering(RootView root)
        {
            var characterModelRoot = (CharacterModelRootView)root;
            var detailView = characterModelRoot.characterModelDetailView;
            characterModelRoot.overlay.Active = _isActive;
            detailView.Active = _isActive;

            if (_isActive == false) return;

            detailView.characterModelIcon.Load(_portraitImage);
            detailView.characterName.Text = _characterName;
            detailView.characterModelName.Text = _characterModelName;
            detailView.characterModelPublisherName.Text = _characterPublisherName;
            detailView.modelUseConditions.Text = Translator.Lang.Get(Key.LicenseTextTitle);
            detailView.canUseAvatar.Text = Translator.Lang.Get(Key.LicenseTextCanUseAvatar) + "：" + LicenseTypeText(_license.WhatCanUseAvatar());
            detailView.canUseViolence.Text = Translator.Lang.Get(Key.LicenseTextCanUseViolence) + "：" + LicenseTypeText(_license.WhatCanUseViolence());
            detailView.canUseSexuality.Text = Translator.Lang.Get(Key.LicenseTextCanUseSexuality) + "：" + LicenseTypeText(_license.WhatCanUseSexuality());
            detailView.canUseCorporateCommercial.Text = Translator.Lang.Get(Key.LicenseTextCanUseCorporateCommercial) + "：" + LicenseTypeText(_license.WhatCanUseCorporateCommercial());
            detailView.canUsePersonalCommercial.Text = Translator.Lang.Get(Key.LicenseTextCanUsePersonalCommercial) + "：" + LicenseTypeText(_license.WhatCanUsePersonalCommercial());
            detailView.canModify.Text = Translator.Lang.Get(Key.LicenseTextCanModify) + "：" + LicenseTypeText(_license.WhatModification());
            detailView.canRedistribute.Text = Translator.Lang.Get(Key.LicenseTextCanRedistribute) + "：" + LicenseTypeText(_license.WhatRedistribution());
            detailView.showCredit.Text = Translator.Lang.Get(Key.LicenseTextShowCredit) + "：" + LicenseTypeText(_license.WhatShowCredit());

            if (!_isLoaded)
            {
                detailView.acceptButton.Active = true;
                detailView.acceptButton.Enable = _licenseAccepted;
                detailView.acceptButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewCharacterModelDetailModelUse);
                detailView.isAccepted.Active = true;
                detailView.isAccepted.Checked = _licenseAccepted;
                detailView.isAccepted.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewCharacterModelDetailAcceptLicense);
                detailView.cancelButton.Active = true;
                detailView.cancelButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewCharacterModelDetailModelUseCancel);
            }
            else
            {
                detailView.acceptButton.Active = false;
                detailView.isAccepted.Active = false;
                detailView.cancelButton.Active = true;
                detailView.cancelButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewCharacterModelDetailModelUseCancel);
            }
        }

        private string LicenseTypeText(EnumLicense enumLicense)
        {
            switch (enumLicense)
            {
                case EnumLicense.ok:
                    {
                        var decorator = new TextDecorator(Translator.Lang.Get(Key.LicenseTypeOk));
                        return decorator.Color("#B1CC29").Bold().Text;
                    }
                case EnumLicense.ng:
                    {
                        var decorator = new TextDecorator(Translator.Lang.Get(Key.LicenseTypeNg));
                        return decorator.Color("#ADADAD").Bold().Text;
                    }
                case EnumLicense.need:
                    {
                        var decorator = new TextDecorator(Translator.Lang.Get(Key.LicenseTypeNeed));
                        return decorator.Color("#FF2B00").Bold().Text;
                    }
                case EnumLicense.noneed:
                    {
                        var decorator = new TextDecorator(Translator.Lang.Get(Key.LicenseTypeNoNeed));
                        return decorator.Color("#5C5C5C").Bold().Text;
                    }
                case EnumLicense.profit:
                    {
                        var decorator = new TextDecorator(Translator.Lang.Get(Key.LicenseTypeProfit));
                        return decorator.Color("#B1CC29").Bold().Text;
                    }
                case EnumLicense.nonprofit:
                    {
                        var decorator = new TextDecorator(Translator.Lang.Get(Key.LicenseTypeNonProfit));
                        return decorator.Color("#B1CC29").Bold().Text;
                    }
                case EnumLicense.notset:
                    {
                        var decorator = new TextDecorator(Translator.Lang.Get(Key.LicenseTypeNotSet));
                        return decorator.Color("#ADADAD").Bold().Text;
                    }
                default:
                    return "";
            }
        }
    }
}
