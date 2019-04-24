using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace ReClassNET.Util
{
    public class KeyBoardManager
    {
        // Event
        public delegate void KeyDelgate(VirtualKeyCode KeyCode);
        public event KeyDelgate KeyPressed;
        public event KeyDelgate KeyDown;

        public List<VirtualKeyCode> KeysCodesToHandle { get; set; }
        public bool IsKeyThreadRunning { get; set; } = false;

        public InputSimulator input = new InputSimulator();

        public KeyBoardManager()
        {
            KeysCodesToHandle = new List<VirtualKeyCode>();
        }

        public KeyBoardManager(List<VirtualKeyCode> KeysCodesToHandle)
        {
            this.KeysCodesToHandle = KeysCodesToHandle;
        }

        private bool IsKeyPressed(IInputDeviceStateAdaptor Adaptor, VirtualKeyCode keyCode)
        {
            if (Adaptor.IsKeyDown(keyCode))
            {
                while (!Adaptor.IsKeyUp(keyCode))
                    Thread.Sleep(1);

                return true;
            }
            return false;
        }

        public void StartDetector()
        {
            if (!IsKeyThreadRunning)
            {
                IsKeyThreadRunning = true;
                new Thread(() =>
                {
                    while (true)
                    {
                        for (int i = 0; i < KeysCodesToHandle.Count; i++)
                        {
                            VirtualKeyCode key = KeysCodesToHandle[i];
                            if (input.InputDeviceState.IsKeyDown(key))
                                Task.Run(() => KeyDown?.Invoke(key));

                            if (IsKeyPressed(input.InputDeviceState, key))
                                Task.Run(() => KeyPressed?.Invoke(key));
                        }

                        Thread.Sleep(8);
                    }
                }).Start();
            }
        }
    }
}
