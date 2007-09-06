using System;
using System.Collections.Generic;
using System.Text;

namespace IEBus_Studio
{
    static class HexStringConverter
    {

        public static byte[] ToByteArray(string HexString, bool hyphenated)
        {
            if(hyphenated)
            {
                int NumberChars = HexString.Length;
                byte[] bytes = new byte[(NumberChars+1) / 3];
                for (int i = 0; i < NumberChars; i += 3)
                {
                    bytes[i / 3] = Convert.ToByte(HexString.Substring(i, 2), 16);
                }
                return bytes;
            }

            int NumBytes = HexString.Length / 2;
            byte[] bytes2 = new byte[NumBytes];
            for (int i = 0; i < NumBytes; i++)
            {
                bytes2[i] = Convert.ToByte(HexString.Substring(i*2, 2), 16);
            }
            return bytes2;
        }

        public static string ToHyphenatedHexString(string hexString, int numBytes)
        {
            // if the hexstring is smaller than the number of bytes, pad with a zero
            while (hexString.Length < (numBytes*2)) { hexString = "0" + hexString; }

            string newHexString = "";

            for (int i = 0; i < hexString.Length; i++)
            {
                // if this is the next byte in the hex string, add a -
                if (i != 0 && i % 2 == 0)
                    newHexString += "-";
                
                // add the next character to the new hex string
                newHexString += hexString[i];
            }

            return newHexString;
        }
    }

    static class Validator
    {
        public static bool validate_address(string address)
        {
            if (address == null) return false;

            // Convert to all uppercase
            address = address.ToUpper();

            if (address.Length != 6) return false;

            for (int i = 0; i < address.Length; i++)
            {
                if (!isHexChar(address[i]))
                    return false;
            }

            return true;
        }

        public static bool validate_control(string control)
        {
            // Convert to all uppercase
            control = control.ToUpper();

            if (control.Length != 1) return false;

            if (isHexChar(control[0]))
                return true;

            return false;
        }

        public static bool validate_datasize(string datasize)
        {
            if (datasize.Length > 5) return false;

            for (int i = 0; i < datasize.Length; i++)
            {
               if (!isNumber(datasize[i]))
                    return false;
            }

            return true;
        }

        public static bool validate_data(string address)
        {
            // Convert to all uppercase
            address = address.ToUpper();

            if (address.Length != 47) return false;

            for (int i = 0; i < address.Length; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    if (address[i] != '-')
                        return false;
                }
                else if (!isHexChar(address[i]))
                    return false;
            }

            return true;
        }

        public static bool isHexChar(char ch)
        {
            if (isNumber(ch))
                return true;

            switch(ch)
            {
                case 'A': return true;
                case 'B': return true;
                case 'C': return true;
                case 'D': return true;
                case 'E': return true;
                case 'F': return true;
                default: return false;
            }
        }

        public static bool isNumber(char ch)
        {
            switch (ch)
            {
                case '0': return true;
                case '1': return true;
                case '2': return true;
                case '3': return true;
                case '4': return true;
                case '5': return true;
                case '6': return true;
                case '7': return true;
                case '8': return true;
                case '9': return true;
                default: return false;
            }
        }
    }
}
