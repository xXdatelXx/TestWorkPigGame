using System.Collections.Generic;
using System.Linq;

namespace TestWork.Engine.UI
{
    public sealed class ButtonsSet : IButton
    {
        private readonly IButton[] _buttons;

        public ButtonsSet(params IButton[] buttons) =>
            _buttons = buttons;

        public ButtonsSet(IEnumerable<IButton> buttons) : this(buttons.ToArray())
        { }

        public void Press()
        {
            foreach (var b in _buttons)
                b.Press();
        }
    }
}