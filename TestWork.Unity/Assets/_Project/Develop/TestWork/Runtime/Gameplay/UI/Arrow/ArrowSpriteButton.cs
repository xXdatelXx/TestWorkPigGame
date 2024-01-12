using TestWork.Engine.UI;
using UnityEngine;

namespace TestWork.Gameplay
{
    public sealed class ArrowSpriteButton : IButton
    {
        private readonly Sprite _sprite;
        private readonly ArrowConfig _config;

        public ArrowSpriteButton(Sprite sprite, ArrowConfig config)
        {
            _sprite = sprite;
            _config = config;
        }

        public void Press() =>
            _config.Sprite = _sprite;
    }
}