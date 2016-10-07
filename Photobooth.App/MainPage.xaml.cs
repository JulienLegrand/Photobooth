using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Photobooth.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GamepadListener gpListener = new GamepadListener(this, Dispatcher);
            GamepadListener.ButtonPressed += GamepadListener_ButtonPressed;
        }

        private void GamepadListener_ButtonPressed(object sender, ButtonEventArgs e)
        {
            tbGamepadButton.Text = $"Bouton {e.ButtonName}";
        }

        public void changeGamepadStatus(bool isGamepadOn)
        {
            if (isGamepadOn)
            {
                tbGamepadOn.Visibility = Visibility.Visible;
                tbGamepadOff.Visibility = Visibility.Collapsed;
            }
            else
            {
                tbGamepadOn.Visibility = Visibility.Collapsed;
                tbGamepadOff.Visibility = Visibility.Visible;
            }
        }
    }
}
