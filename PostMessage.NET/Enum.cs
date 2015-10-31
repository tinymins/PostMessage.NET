using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PostMessage.NET {
partial class Program {
    [DllImport("user32.dll", EntryPoint = "PostMessage", CallingConvention = CallingConvention.Winapi)]
    public static extern bool PostMessage(IntPtr hwnd, uint msg, uint wParam, uint lParam);
    const uint WM_ACTIVATEAPP = 0x001C;
    const uint WM_KEYDOWN = 0x0100;
    const uint WM_KEYUP = 0x0101;
    enum VK : int {
        ///<summary>
        ///Left mouse button
        ///</summary>
        LBUTTON = 0x01,
        ///<summary>
        ///Right mouse button
        ///</summary>
        RBUTTON = 0x02,
        ///<summary>
        ///Control-break processing
        ///</summary>
        CANCEL = 0x03,
        ///<summary>
        ///Middle mouse button (three-button mouse)
        ///</summary>
        MBUTTON = 0x04,
        ///<summary>
        ///Windows 2000/XP: X1 mouse button
        ///</summary>
        XBUTTON1 = 0x05,
        ///<summary>
        ///Windows 2000/XP: X2 mouse button
        ///</summary>
        XBUTTON2 = 0x06,
        ///<summary>
        ///BACKSPACE key
        ///</summary>
        BACK = 0x08,
        ///<summary>
        ///TAB key
        ///</summary>
        TAB = 0x09,
        ///<summary>
        ///CLEAR key
        ///</summary>
        CLEAR = 0x0C,
        ///<summary>
        ///ENTER key
        ///</summary>
        RETURN = 0x0D,
        ///<summary>
        ///SHIFT key
        ///</summary>
        SHIFT = 0x10,
        ///<summary>
        ///CTRL key
        ///</summary>
        CONTROL = 0x11,
        ///<summary>
        ///ALT key
        ///</summary>
        MENU = 0x12,
        ///<summary>
        ///PAUSE key
        ///</summary>
        PAUSE = 0x13,
        ///<summary>
        ///CAPS LOCK key
        ///</summary>
        CAPITAL = 0x14,
        ///<summary>
        ///Input Method Editor (IME) Kana mode
        ///</summary>
        KANA = 0x15,
        ///<summary>
        ///IME Hangul mode
        ///</summary>
        HANGUL = 0x15,
        ///<summary>
        ///IME Junja mode
        ///</summary>
        JUNJA = 0x17,
        ///<summary>
        ///IME final mode
        ///</summary>
        FINAL = 0x18,
        ///<summary>
        ///IME Hanja mode
        ///</summary>
        HANJA = 0x19,
        ///<summary>
        ///IME Kanji mode
        ///</summary>
        KANJI = 0x19,
        ///<summary>
        ///ESC key
        ///</summary>
        ESCAPE = 0x1B,
        ///<summary>
        ///IME convert
        ///</summary>
        CONVERT = 0x1C,
        ///<summary>
        ///IME nonconvert
        ///</summary>
        NONCONVERT = 0x1D,
        ///<summary>
        ///IME accept
        ///</summary>
        ACCEPT = 0x1E,
        ///<summary>
        ///IME mode change request
        ///</summary>
        MODECHANGE = 0x1F,
        ///<summary>
        ///SPACEBAR
        ///</summary>
        SPACE = 0x20,
        ///<summary>
        ///PAGE UP key
        ///</summary>
        PRIOR = 0x21,
        ///<summary>
        ///PAGE DOWN key
        ///</summary>
        NEXT = 0x22,
        ///<summary>
        ///END key
        ///</summary>
        END = 0x23,
        ///<summary>
        ///HOME key
        ///</summary>
        HOME = 0x24,
        ///<summary>
        ///LEFT ARROW key
        ///</summary>
        LEFT = 0x25,
        ///<summary>
        ///UP ARROW key
        ///</summary>
        UP = 0x26,
        ///<summary>
        ///RIGHT ARROW key
        ///</summary>
        RIGHT = 0x27,
        ///<summary>
        ///DOWN ARROW key
        ///</summary>
        DOWN = 0x28,
        ///<summary>
        ///SELECT key
        ///</summary>
        SELECT = 0x29,
        ///<summary>
        ///PRINT key
        ///</summary>
        PRINT = 0x2A,
        ///<summary>
        ///EXECUTE key
        ///</summary>
        EXECUTE = 0x2B,
        ///<summary>
        ///PRINT SCREEN key
        ///</summary>
        SNAPSHOT = 0x2C,
        ///<summary>
        ///INS key
        ///</summary>
        INSERT = 0x2D,
        ///<summary>
        ///DEL key
        ///</summary>
        DELETE = 0x2E,
        ///<summary>
        ///HELP key
        ///</summary>
        HELP = 0x2F,
        ///<summary>
        ///0 key
        ///</summary>
        KEY_0 = 0x30,
        ///<summary>
        ///1 key
        ///</summary>
        KEY_1 = 0x31,
        ///<summary>
        ///2 key
        ///</summary>
        KEY_2 = 0x32,
        ///<summary>
        ///3 key
        ///</summary>
        KEY_3 = 0x33,
        ///<summary>
        ///4 key
        ///</summary>
        KEY_4 = 0x34,
        ///<summary>
        ///5 key
        ///</summary>
        KEY_5 = 0x35,
        ///<summary>
        ///6 key
        ///</summary>
        KEY_6 = 0x36,
        ///<summary>
        ///7 key
        ///</summary>
        KEY_7 = 0x37,
        ///<summary>
        ///8 key
        ///</summary>
        KEY_8 = 0x38,
        ///<summary>
        ///9 key
        ///</summary>
        KEY_9 = 0x39,
        ///<summary>
        ///A key
        ///</summary>
        KEY_A = 0x41,
        ///<summary>
        ///B key
        ///</summary>
        KEY_B = 0x42,
        ///<summary>
        ///C key
        ///</summary>
        KEY_C = 0x43,
        ///<summary>
        ///D key
        ///</summary>
        KEY_D = 0x44,
        ///<summary>
        ///E key
        ///</summary>
        KEY_E = 0x45,
        ///<summary>
        ///F key
        ///</summary>
        KEY_F = 0x46,
        ///<summary>
        ///G key
        ///</summary>
        KEY_G = 0x47,
        ///<summary>
        ///H key
        ///</summary>
        KEY_H = 0x48,
        ///<summary>
        ///I key
        ///</summary>
        KEY_I = 0x49,
        ///<summary>
        ///J key
        ///</summary>
        KEY_J = 0x4A,
        ///<summary>
        ///K key
        ///</summary>
        KEY_K = 0x4B,
        ///<summary>
        ///L key
        ///</summary>
        KEY_L = 0x4C,
        ///<summary>
        ///M key
        ///</summary>
        KEY_M = 0x4D,
        ///<summary>
        ///N key
        ///</summary>
        KEY_N = 0x4E,
        ///<summary>
        ///O key
        ///</summary>
        KEY_O = 0x4F,
        ///<summary>
        ///P key
        ///</summary>
        KEY_P = 0x50,
        ///<summary>
        ///Q key
        ///</summary>
        KEY_Q = 0x51,
        ///<summary>
        ///R key
        ///</summary>
        KEY_R = 0x52,
        ///<summary>
        ///S key
        ///</summary>
        KEY_S = 0x53,
        ///<summary>
        ///T key
        ///</summary>
        KEY_T = 0x54,
        ///<summary>
        ///U key
        ///</summary>
        KEY_U = 0x55,
        ///<summary>
        ///V key
        ///</summary>
        KEY_V = 0x56,
        ///<summary>
        ///W key
        ///</summary>
        KEY_W = 0x57,
        ///<summary>
        ///X key
        ///</summary>
        KEY_X = 0x58,
        ///<summary>
        ///Y key
        ///</summary>
        KEY_Y = 0x59,
        ///<summary>
        ///Z key
        ///</summary>
        KEY_Z = 0x5A,
        ///<summary>
        ///Left Windows key (Microsoft Natural keyboard)
        ///</summary>
        LWIN = 0x5B,
        ///<summary>
        ///Right Windows key (Natural keyboard)
        ///</summary>
        RWIN = 0x5C,
        ///<summary>
        ///Applications key (Natural keyboard)
        ///</summary>
        APPS = 0x5D,
        ///<summary>
        ///Computer Sleep key
        ///</summary>
        SLEEP = 0x5F,
        ///<summary>
        ///Numeric keypad 0 key
        ///</summary>
        NUMPAD0 = 0x60,
        ///<summary>
        ///Numeric keypad 1 key
        ///</summary>
        NUMPAD1 = 0x61,
        ///<summary>
        ///Numeric keypad 2 key
        ///</summary>
        NUMPAD2 = 0x62,
        ///<summary>
        ///Numeric keypad 3 key
        ///</summary>
        NUMPAD3 = 0x63,
        ///<summary>
        ///Numeric keypad 4 key
        ///</summary>
        NUMPAD4 = 0x64,
        ///<summary>
        ///Numeric keypad 5 key
        ///</summary>
        NUMPAD5 = 0x65,
        ///<summary>
        ///Numeric keypad 6 key
        ///</summary>
        NUMPAD6 = 0x66,
        ///<summary>
        ///Numeric keypad 7 key
        ///</summary>
        NUMPAD7 = 0x67,
        ///<summary>
        ///Numeric keypad 8 key
        ///</summary>
        NUMPAD8 = 0x68,
        ///<summary>
        ///Numeric keypad 9 key
        ///</summary>
        NUMPAD9 = 0x69,
        ///<summary>
        ///Multiply key
        ///</summary>
        MULTIPLY = 0x6A,
        ///<summary>
        ///Add key
        ///</summary>
        ADD = 0x6B,
        ///<summary>
        ///Separator key
        ///</summary>
        SEPARATOR = 0x6C,
        ///<summary>
        ///Subtract key
        ///</summary>
        SUBTRACT = 0x6D,
        ///<summary>
        ///Decimal key
        ///</summary>
        DECIMAL = 0x6E,
        ///<summary>
        ///Divide key
        ///</summary>
        DIVIDE = 0x6F,
        ///<summary>
        ///F1 key
        ///</summary>
        F1 = 0x70,
        ///<summary>
        ///F2 key
        ///</summary>
        F2 = 0x71,
        ///<summary>
        ///F3 key
        ///</summary>
        F3 = 0x72,
        ///<summary>
        ///F4 key
        ///</summary>
        F4 = 0x73,
        ///<summary>
        ///F5 key
        ///</summary>
        F5 = 0x74,
        ///<summary>
        ///F6 key
        ///</summary>
        F6 = 0x75,
        ///<summary>
        ///F7 key
        ///</summary>
        F7 = 0x76,
        ///<summary>
        ///F8 key
        ///</summary>
        F8 = 0x77,
        ///<summary>
        ///F9 key
        ///</summary>
        F9 = 0x78,
        ///<summary>
        ///F10 key
        ///</summary>
        F10 = 0x79,
        ///<summary>
        ///F11 key
        ///</summary>
        F11 = 0x7A,
        ///<summary>
        ///F12 key
        ///</summary>
        F12 = 0x7B,
        ///<summary>
        ///F13 key
        ///</summary>
        F13 = 0x7C,
        ///<summary>
        ///F14 key
        ///</summary>
        F14 = 0x7D,
        ///<summary>
        ///F15 key
        ///</summary>
        F15 = 0x7E,
        ///<summary>
        ///F16 key
        ///</summary>
        F16 = 0x7F,
        ///<summary>
        ///F17 key
        ///</summary>
        F17 = 0x80,
        ///<summary>
        ///F18 key
        ///</summary>
        F18 = 0x81,
        ///<summary>
        ///F19 key
        ///</summary>
        F19 = 0x82,
        ///<summary>
        ///F20 key
        ///</summary>
        F20 = 0x83,
        ///<summary>
        ///F21 key
        ///</summary>
        F21 = 0x84,
        ///<summary>
        ///F22 key, (PPC only) Key used to lock device.
        ///</summary>
        F22 = 0x85,
        ///<summary>
        ///F23 key
        ///</summary>
        F23 = 0x86,
        ///<summary>
        ///F24 key
        ///</summary>
        F24 = 0x87,
        ///<summary>
        ///NUM LOCK key
        ///</summary>
        NUMLOCK = 0x90,
        ///<summary>
        ///SCROLL LOCK key
        ///</summary>
        SCROLL = 0x91,
        ///<summary>
        ///Left SHIFT key
        ///</summary>
        LSHIFT = 0xA0,
        ///<summary>
        ///Right SHIFT key
        ///</summary>
        RSHIFT = 0xA1,
        ///<summary>
        ///Left CONTROL key
        ///</summary>
        LCONTROL = 0xA2,
        ///<summary>
        ///Right CONTROL key
        ///</summary>
        RCONTROL = 0xA3,
        ///<summary>
        ///Left MENU key
        ///</summary>
        LMENU = 0xA4,
        ///<summary>
        ///Right MENU key
        ///</summary>
        RMENU = 0xA5,
        ///<summary>
        ///Windows 2000/XP: Browser Back key
        ///</summary>
        BROWSER_BACK = 0xA6,
        ///<summary>
        ///Windows 2000/XP: Browser Forward key
        ///</summary>
        BROWSER_FORWARD = 0xA7,
        ///<summary>
        ///Windows 2000/XP: Browser Refresh key
        ///</summary>
        BROWSER_REFRESH = 0xA8,
        ///<summary>
        ///Windows 2000/XP: Browser Stop key
        ///</summary>
        BROWSER_STOP = 0xA9,
        ///<summary>
        ///Windows 2000/XP: Browser Search key
        ///</summary>
        BROWSER_SEARCH = 0xAA,
        ///<summary>
        ///Windows 2000/XP: Browser Favorites key
        ///</summary>
        BROWSER_FAVORITES = 0xAB,
        ///<summary>
        ///Windows 2000/XP: Browser Start and Home key
        ///</summary>
        BROWSER_HOME = 0xAC,
        ///<summary>
        ///Windows 2000/XP: Volume Mute key
        ///</summary>
        VOLUME_MUTE = 0xAD,
        ///<summary>
        ///Windows 2000/XP: Volume Down key
        ///</summary>
        VOLUME_DOWN = 0xAE,
        ///<summary>
        ///Windows 2000/XP: Volume Up key
        ///</summary>
        VOLUME_UP = 0xAF,
        ///<summary>
        ///Windows 2000/XP: Next Track key
        ///</summary>
        MEDIA_NEXT_TRACK = 0xB0,
        ///<summary>
        ///Windows 2000/XP: Previous Track key
        ///</summary>
        MEDIA_PREV_TRACK = 0xB1,
        ///<summary>
        ///Windows 2000/XP: Stop Media key
        ///</summary>
        MEDIA_STOP = 0xB2,
        ///<summary>
        ///Windows 2000/XP: Play/Pause Media key
        ///</summary>
        MEDIA_PLAY_PAUSE = 0xB3,
        ///<summary>
        ///Windows 2000/XP: Start Mail key
        ///</summary>
        LAUNCH_MAIL = 0xB4,
        ///<summary>
        ///Windows 2000/XP: Select Media key
        ///</summary>
        LAUNCH_MEDIA_SELECT = 0xB5,
        ///<summary>
        ///Windows 2000/XP: Start Application 1 key
        ///</summary>
        LAUNCH_APP1 = 0xB6,
        ///<summary>
        ///Windows 2000/XP: Start Application 2 key
        ///</summary>
        LAUNCH_APP2 = 0xB7,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_1 = 0xBA,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '+' key
        ///</summary>
        OEM_PLUS = 0xBB,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the ',' key
        ///</summary>
        OEM_COMMA = 0xBC,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '-' key
        ///</summary>
        OEM_MINUS = 0xBD,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '.' key
        ///</summary>
        OEM_PERIOD = 0xBE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_2 = 0xBF,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_3 = 0xC0,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_4 = 0xDB,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_5 = 0xDC,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_6 = 0xDD,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_7 = 0xDE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_8 = 0xDF,
        ///<summary>
        ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
        ///</summary>
        OEM_102 = 0xE2,
        ///<summary>
        ///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
        ///</summary>
        PROCESSKEY = 0xE5,
        ///<summary>
        ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        ///</summary>
        PACKET = 0xE7,
        ///<summary>
        ///Attn key
        ///</summary>
        ATTN = 0xF6,
        ///<summary>
        ///CrSel key
        ///</summary>
        CRSEL = 0xF7,
        ///<summary>
        ///ExSel key
        ///</summary>
        EXSEL = 0xF8,
        ///<summary>
        ///Erase EOF key
        ///</summary>
        EREOF = 0xF9,
        ///<summary>
        ///Play key
        ///</summary>
        PLAY = 0xFA,
        ///<summary>
        ///Zoom key
        ///</summary>
        ZOOM = 0xFB,
        ///<summary>
        ///Reserved
        ///</summary>
        NONAME = 0xFC,
        ///<summary>
        ///PA1 key
        ///</summary>
        PA1 = 0xFD,
        ///<summary>
        ///Clear key
        ///</summary>
        OEM_CLEAR = 0xFE
    }
    /// <summary>
    /// 设置的钩子类型
    /// </summary>
    public enum HookType : int
    {
        /// <summary>
        /// WH_MSGFILTER 和 WH_SYSMSGFILTER Hooks使我们可以监视菜单，滚动 
        ///条，消息框，对话框消息并且发现用户使用ALT+TAB or ALT+ESC 组合键切换窗口。 
        ///WH_MSGFILTER Hook只能监视传递到菜单，滚动条，消息框的消息，以及传递到通 
        ///过安装了Hook子过程的应用程序建立的对话框的消息。WH_SYSMSGFILTER Hook 
        ///监视所有应用程序消息。 
        /// 
        ///WH_MSGFILTER 和 WH_SYSMSGFILTER Hooks使我们可以在模式循环期间 
        ///过滤消息，这等价于在主消息循环中过滤消息。 
        ///    
        ///通过调用CallMsgFilter function可以直接的调用WH_MSGFILTER Hook。通过使用这 
        ///个函数，应用程序能够在模式循环期间使用相同的代码去过滤消息，如同在主消息循 
        ///环里一样
        /// </summary>
        WH_MSGFILTER = -1,
        /// <summary>
        /// WH_JOURNALRECORD Hook用来监视和记录输入事件。典型的，可以使用这 
        ///个Hook记录连续的鼠标和键盘事件，然后通过使用WH_JOURNALPLAYBACK Hook 
        ///来回放。WH_JOURNALRECORD Hook是全局Hook，它不能象线程特定Hook一样 
        ///使用。WH_JOURNALRECORD是system-wide local hooks，它们不会被注射到任何行 
        ///程地址空间
        /// </summary>
        WH_JOURNALRECORD = 0,
        /// <summary>
        /// WH_JOURNALPLAYBACK Hook使应用程序可以插入消息到系统消息队列。可 
        ///以使用这个Hook回放通过使用WH_JOURNALRECORD Hook记录下来的连续的鼠 
        ///标和键盘事件。只要WH_JOURNALPLAYBACK Hook已经安装，正常的鼠标和键盘 
        ///事件就是无效的。WH_JOURNALPLAYBACK Hook是全局Hook，它不能象线程特定 
        ///Hook一样使用。WH_JOURNALPLAYBACK Hook返回超时值，这个值告诉系统在处 
        ///理来自回放Hook当前消息之前需要等待多长时间（毫秒）。这就使Hook可以控制实 
        ///时事件的回放。WH_JOURNALPLAYBACK是system-wide local hooks，它们不会被 
        ///注射到任何行程地址空间
        /// </summary>
        WH_JOURNALPLAYBACK = 1,
        /// <summary>
        /// 在应用程序中，WH_KEYBOARD Hook用来监视WM_KEYDOWN and  
        ///WM_KEYUP消息，这些消息通过GetMessage or PeekMessage function返回。可以使 
        ///用这个Hook来监视输入到消息队列中的键盘消息
        /// </summary>
        WH_KEYBOARD = 2,
        /// <summary>
        /// 应用程序使用WH_GETMESSAGE Hook来监视从GetMessage or PeekMessage函 
        ///数返回的消息。你可以使用WH_GETMESSAGE Hook去监视鼠标和键盘输入，以及 
        ///其它发送到消息队列中的消息
        /// </summary>
        WH_GETMESSAGE = 3,
        /// <summary>
        /// 监视发送到窗口过程的消息，系统在消息发送到接收窗口过程之前调用
        /// </summary>
        WH_CALLWNDPROC = 4,
        /// <summary>
        /// 在以下事件之前，系统都会调用WH_CBT Hook子过程，这些事件包括： 
        ///1. 激活，建立，销毁，最小化，最大化，移动，改变尺寸等窗口事件； 
        ///2. 完成系统指令； 
        ///3. 来自系统消息队列中的移动鼠标，键盘事件； 
        ///4. 设置输入焦点事件； 
        ///5. 同步系统消息队列事件。
        ///Hook子过程的返回值确定系统是否允许或者防止这些操作中的一个
        /// </summary>
        WH_CBT = 5,
        /// <summary>
        /// WH_MSGFILTER 和 WH_SYSMSGFILTER Hooks使我们可以监视菜单，滚动 
        ///条，消息框，对话框消息并且发现用户使用ALT+TAB or ALT+ESC 组合键切换窗口。 
        ///WH_MSGFILTER Hook只能监视传递到菜单，滚动条，消息框的消息，以及传递到通 
        ///过安装了Hook子过程的应用程序建立的对话框的消息。WH_SYSMSGFILTER Hook 
        ///监视所有应用程序消息。 
        /// 
        ///WH_MSGFILTER 和 WH_SYSMSGFILTER Hooks使我们可以在模式循环期间 
        ///过滤消息，这等价于在主消息循环中过滤消息。 
        ///    
        ///通过调用CallMsgFilter function可以直接的调用WH_MSGFILTER Hook。通过使用这 
        ///个函数，应用程序能够在模式循环期间使用相同的代码去过滤消息，如同在主消息循 
        ///环里一样
        /// </summary>
        WH_SYSMSGFILTER = 6,
        /// <summary>
        /// WH_MOUSE Hook监视从GetMessage 或者 PeekMessage 函数返回的鼠标消息。 
        ///使用这个Hook监视输入到消息队列中的鼠标消息
        /// </summary>
        WH_MOUSE = 7,
        /// <summary>
        /// 当调用GetMessage 或 PeekMessage 来从消息队列种查询非鼠标、键盘消息时
        /// </summary>
        WH_HARDWARE = 8,
        /// <summary>
        /// 在系统调用系统中与其它Hook关联的Hook子过程之前，系统会调用 
        ///WH_DEBUG Hook子过程。你可以使用这个Hook来决定是否允许系统调用与其它 
        ///Hook关联的Hook子过程
        /// </summary>
        WH_DEBUG = 9,
        /// <summary>
        /// 外壳应用程序可以使用WH_SHELL Hook去接收重要的通知。当外壳应用程序是 
        ///激活的并且当顶层窗口建立或者销毁时，系统调用WH_SHELL Hook子过程。 
        ///WH_SHELL 共有５钟情况： 
        ///1. 只要有个top-level、unowned 窗口被产生、起作用、或是被摧毁； 
        ///2. 当Taskbar需要重画某个按钮； 
        ///3. 当系统需要显示关于Taskbar的一个程序的最小化形式； 
        ///4. 当目前的键盘布局状态改变； 
        ///5. 当使用者按Ctrl+Esc去执行Task Manager（或相同级别的程序）。 
        ///
        ///按照惯例，外壳应用程序都不接收WH_SHELL消息。所以，在应用程序能够接 
        ///收WH_SHELL消息之前，应用程序必须调用SystemParametersInfo function注册它自 
        ///己
        /// </summary>
        WH_SHELL = 10,
        /// <summary>
        /// 当应用程序的前台线程处于空闲状态时，可以使用WH_FOREGROUNDIDLE  
        ///Hook执行低优先级的任务。当应用程序的前台线程大概要变成空闲状态时，系统就 
        ///会调用WH_FOREGROUNDIDLE Hook子过程
        /// </summary>
        WH_FOREGROUNDIDLE = 11,
        /// <summary>
        /// 监视发送到窗口过程的消息，系统在消息发送到接收窗口过程之后调用
        /// </summary>
        WH_CALLWNDPROCRET = 12,
        /// <summary>
        /// 监视输入到线程消息队列中的键盘消息
        /// </summary>
        WH_KEYBOARD_LL = 13,
        /// <summary>
        /// 监视输入到线程消息队列中的鼠标消息
        /// </summary>
        WH_MOUSE_LL = 14
    }
}
}