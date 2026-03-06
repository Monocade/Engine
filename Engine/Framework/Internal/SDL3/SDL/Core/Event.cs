using System.Runtime.InteropServices;
using System;

namespace Engine
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Event
        {
            [FieldOffset(0)]
            public SDL.EventType type;
		
            [FieldOffset(0)]
            public SDL.KeyboardDeviceEvent keyboardDevice;
		
            [FieldOffset(0)]
            public SDL.KeyboardButtonEvent keyboardButton;
		
            [FieldOffset(0)]
            public SDL.TextEditingEvent textEditing;
		
            [FieldOffset(0)]
            public SDL.TextInputEvent textInput;
		
            [FieldOffset(0)]
            public SDL.MouseDeviceEvent mouseDevice;
		
            [FieldOffset(0)]
            public SDL.MouseMotionEvent mouseMotion;
		
            [FieldOffset(0)]
            public SDL.MouseButtonEvent mouseButton;
		
            [FieldOffset(0)]
            public SDL.MouseWheelEvent mouseWheel;
		
            [FieldOffset(0)]
            public SDL.GamepadDeviceEvent gamepadDevice;
		
            [FieldOffset(0)]
            public SDL.GamepadAxisEvent gamepadAxis;
		
            [FieldOffset(0)]
            public SDL.GamepadButtonEvent gamepadButton;
		
            [FieldOffset(0)]
            public SDL.TouchFingerEvent touchFinger;
		
            [FieldOffset(0)]
            public fixed byte padding[128];
        }
    }
}