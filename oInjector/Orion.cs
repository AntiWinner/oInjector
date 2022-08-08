using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Orion
{
    public enum OrionError
    {
        OrionError_Success = 0,
        OrionError_TargetWindow = 1,
        OrionError_WindowCreation = 2,
        OrionError_D3D = 3,
        OrionError_No = 4,
        OrionError_InvalidHandle = 5,
        OrionError_InvalidFile = 6,
        OrionError_Unknown = 7
    }

    public static class Memory
    {
        private static IntPtr ProcessHandleCache;

        private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            var Handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(Handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                Handle.Free();
            }
        }

        private static byte[] StructureToByteArray(object obj)
        {
            int Length = Marshal.SizeOf(obj);
            byte[] Array = new byte[Length];
            IntPtr Ptr = Marshal.AllocHGlobal(Length);

            Marshal.StructureToPtr(obj, Ptr, true);
            Marshal.Copy(Ptr, Array, 0, Length);
            Marshal.FreeHGlobal(Ptr);

            return Array;
        }

        public static bool IsValidAddress(IntPtr Address, int TypeSize = 8)
        {
            if (Address.ToInt64() < 0x400000)
                return false;
            if ((Address.ToInt64() + TypeSize) > 0x00007FFFFFFF0000)
                return false;

            return true;
        }

        public static bool IsValidAddress<T>(IntPtr Address) where T : struct
        {
            return IsValidAddress(Address, Marshal.SizeOf(typeof(T)));
        }

        public static T Read<T>(IntPtr Address) where T : struct
        {
            if (!IsValidAddress<T>(Address))
                return default;

            int ByteSize = Marshal.SizeOf(typeof(T));
            byte[] Buffer = new byte[ByteSize];

            Memory_ReadProcessMemory(ProcessHandleCache, Address, Buffer, Buffer.Length);

            return ByteArrayToStructure<T>(Buffer);
        }

        public static T Read<T>(IntPtr Address, int[] Chain) where T : struct
        {
            if (!IsValidAddress<T>(Address))
                return default;

            IntPtr Current = Address;

            foreach (var Entry in Chain)
            {
                if (Entry == Chain.Last())
                    continue;

                Current = Read<IntPtr>(Current + Entry);
            }

            return Read<T>(Current + Chain.Last());
        }

        public static void Read(IntPtr Address, ref byte[] Buffer, int Size)
        {
            if (!IsValidAddress(Address, Size))
                return;

            Memory_ReadProcessMemory(ProcessHandleCache, Address, Buffer, Size);
        }

        public static void Write<T>(IntPtr Address, T Value) where T : struct
        {
            if (!IsValidAddress<T>(Address))
                return;

            byte[] Buffer = StructureToByteArray(Value);
            Memory_WriteProcessMemory(ProcessHandleCache, Address, Buffer, Buffer.Length);
        }

        public static UIntPtr GetModuleBase(IntPtr hProcess, string ModuleName)
        {
            return Memory_GetModuleBase(hProcess, ModuleName);
        }

        public static IntPtr OpenProcess(string ProcessName)
        {
            ProcessHandleCache = Memory_OpenProcess(ProcessName);
            return ProcessHandleCache;
        }

        public static void CloseHandle(IntPtr hProcess)
        {
            Memory_CloseHandle(hProcess);
            ProcessHandleCache = IntPtr.Zero;
        }

        public static OrionError InjectFromFile(IntPtr hProcess, string FilePath)
        {
            return Memory_InjectFromFile(hProcess, FilePath);
        }

        [DllImport("Orion.dll")]
        private static extern IntPtr Memory_OpenProcess(string ProcessName);
        [DllImport("Orion.dll")]
        private static extern void Memory_CloseHandle(IntPtr hProcess);
        [DllImport("Orion.dll")]
        private static extern UIntPtr Memory_GetModuleBase(IntPtr hProcess, string ModuleName);
        [DllImport("Orion.dll")]
        private static extern bool Memory_ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize);
        [DllImport("Orion.dll")]
        private static extern bool Memory_WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize);
        [DllImport("Orion.dll")]
        private static extern OrionError Memory_InjectFromFile(IntPtr hProcess, string FIlePath);
    }

    public static class Rendering
    {
        public static OrionError Setup(IntPtr TargetWindow, int RandomSeed = -1)
        {
            return Render_Setup(TargetWindow, RandomSeed);
        }

        public static bool BeginFrame()
        {
            return Render_BeginFrame();
        }

        public static void EndFrame()
        {
            Render_EndFrame();
        }

        public static void SetMouseLock(bool Enabled)
        {
            Render_SetMouseLock(Enabled);
        }

        public static void FillRect(Point Pos, Size Sz, Color Col, float Rounding = 0)
        {
            Render_FillRect(Pos.X, Pos.Y, Sz.Width, Sz.Height, Col.R, Col.G, Col.B, Col.A, Rounding);
        }

        public static void Rect(Point Pos, Size Sz, Color Col, float Rounding = 0)
        {
            Render_Rect(Pos.X, Pos.Y, Sz.Width, Sz.Height, Col.R, Col.G, Col.B, Col.A, Rounding);
        }

        public static void FillCircle(Point Pos, float Sz, Color Col, int Segments = 0)
        {
            Render_FillCircle(Pos.X, Pos.Y, Sz, Col.R, Col.G, Col.B, Col.A, Segments);
        }

        public static void Circle(Point Pos, float Sz, Color Col, int Segments = 0)
        {
            Render_Circle(Pos.X, Pos.Y, Sz, Col.R, Col.G, Col.B, Col.A, Segments);
        }

        public static void Text(string Str, Point Pos, Color Col, bool Outline = false, float Sz = 24)
        {
            Render_Text(Str, Pos.X, Pos.Y, Col.R, Col.G, Col.B, Col.A, Outline, Sz);
        }

        public static Size TextSize(string Str, float Sz = 24)
        {
            var Data = Render_TextSize(Str, Sz);
            return new Size((int)Data.X, (int)Data.Y);
        }

        [DllImport("Orion.dll")]
        private static extern OrionError Render_Setup(IntPtr TargetWindow, int RandomSeed);
        [DllImport("Orion.dll")]
        private static extern bool Render_BeginFrame();
        [DllImport("Orion.dll")]
        private static extern void Render_EndFrame();
        [DllImport("Orion.dll")]
        private static extern void Render_SetMouseLock(bool Enabled);
        [DllImport("Orion.dll")]
        private static extern bool Render_FillRect(float X, float Y, float W, float H, int ColR, int ColG, int ColB, int ColA, float Rounding);
        [DllImport("Orion.dll")]
        private static extern bool Render_Rect(float X, float Y, float W, float H, int ColR, int ColG, int ColB, int ColA, float Rounding);
        [DllImport("Orion.dll")]
        private static extern bool Render_FillCircle(float X, float Y, float Sz, int ColR, int ColG, int ColB, int ColA, int Segments);
        [DllImport("Orion.dll")]
        private static extern bool Render_Circle(float X, float Y, float Sz, int ColR, int ColG, int ColB, int ColA, int Segments);
        [DllImport("Orion.dll")]
        private static extern bool Render_Text(string Str, float X, float Y, int ColR, int ColG, int ColB, int ColA, bool Outline, float Sz);
        [DllImport("Orion.dll")]
        private static extern PointF Render_TextSize(string Str, float Sz);
    }
}