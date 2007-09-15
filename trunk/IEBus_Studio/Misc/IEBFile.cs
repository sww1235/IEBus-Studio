using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;

namespace IEBus_Studio
{
    class IEBFile
    {
        private EventManager eManager;
        private DeviceManager dManager;
        public void Load(string Filename)
        {
            FileStream fStream = new FileStream(Filename, FileMode.Open );
            DeflateStream zipStream = new DeflateStream(fStream, CompressionMode.Decompress);
            BinaryReader bReader = new BinaryReader(zipStream);

            int eLen = bReader.ReadInt32();
            int dLen = bReader.ReadInt32();

            eManager = (EventManager)Deserialize(bReader.ReadBytes(eLen),typeof(EventManager));
            dManager = (DeviceManager)Deserialize(bReader.ReadBytes(dLen), typeof(DeviceManager));

            bReader.Close();
            bReader = null;
            
        }
        public void Save(string Filename, EventManager EventManager, DeviceManager DeviceManager)
        {
            Stream eStream = Serialize(EventManager);
            BinaryReader  eReader = new BinaryReader(eStream);
            Stream dStream = Serialize(DeviceManager);
            BinaryReader dReader = new BinaryReader(dStream);

            FileStream fStream = new FileStream(Filename, FileMode.Create);
            DeflateStream zipStream = new DeflateStream(fStream, CompressionMode.Compress);
            BinaryWriter bWriter = new BinaryWriter(zipStream);
            bWriter.Write((int)eStream.Length);
            bWriter.Write((int)dStream.Length);
            bWriter.Write(eReader.ReadBytes((int)eReader.BaseStream.Length));
            bWriter.Write(dReader.ReadBytes((int)dReader.BaseStream.Length));
            bWriter.Flush();

            bWriter.Close();
            eReader.Close();
            dReader.Close();
            
            bWriter = null;
            eReader = null;
            dReader = null;
        }
        public static Stream Serialize(Object obj)
        {
            Stream stream = new MemoryStream(); ;
            BinaryFormatter binFormatter = new BinaryFormatter();
            binFormatter.Serialize(stream , obj);
            stream.Position = 0;
            return stream;
        }
        public static Object Deserialize(byte[] bArray, Type type)
        {
            Stream stream = new MemoryStream(bArray);
            BinaryFormatter binFormatter = new BinaryFormatter();
            stream.Position = 0;
            return binFormatter.Deserialize(stream);
        }
        public EventManager EventManager
        {
            get { return eManager; }
            set { eManager = value; }
        }
        public DeviceManager DeviceManager
        {
            get { return dManager; }
            set { dManager = value; }
        }
    }
}
