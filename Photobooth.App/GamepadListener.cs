using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.HumanInterfaceDevice;
using Windows.Gaming.Input;
using Windows.UI.Core;

namespace Photobooth.App
{
    public class GamepadListener
    {
        public delegate void ButtonPressedEventHandler(object sender, ButtonEventArgs e);
        public static event ButtonPressedEventHandler ButtonPressed;

        private Gamepad currentDevice = null;
        private MainPage currentMainPage = null;
        private CoreDispatcher coreDispatcher = null;

        public GamepadListener(MainPage mainPage, CoreDispatcher coreDispatcher)
        {
            this.currentMainPage = mainPage;
            this.coreDispatcher = coreDispatcher;

            Gamepad.GamepadAdded += Gamepad_GamepadAdded;
            Gamepad.GamepadRemoved += Gamepad_GamepadRemoved;

            Listen();
        }

        private async void Gamepad_GamepadAdded(object sender, Gamepad e)
        {
            currentDevice = e;
            await coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                currentMainPage.changeGamepadStatus(true);
            });
        }

        private async void Gamepad_GamepadRemoved(object sender, Gamepad e)
        {
            currentDevice = null;
            await coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                currentMainPage.changeGamepadStatus(false);
            });
        }

        private async void Listen()
        {
            while (true)
            {
                await coreDispatcher.RunAsync(
                    CoreDispatcherPriority.Normal, () =>
                    {
                        if (currentDevice == null)
                        {
                            return;
                        }

                        // Get the current state
                        var reading = currentDevice.GetCurrentReading();

                        if ((reading.Buttons & GamepadButtons.A) == GamepadButtons.A) ButtonPressed(this, new ButtonEventArgs("A"));
                        if ((reading.Buttons & GamepadButtons.B) == GamepadButtons.B) ButtonPressed(this, new ButtonEventArgs("B"));
                        if ((reading.Buttons & GamepadButtons.X) == GamepadButtons.X) ButtonPressed(this, new ButtonEventArgs("X"));
                        if ((reading.Buttons & GamepadButtons.Y) == GamepadButtons.Y) ButtonPressed(this, new ButtonEventArgs("Y"));
                    });
                await Task.Delay(TimeSpan.FromMilliseconds(5));
            }
        }
    }
}