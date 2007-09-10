using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IEBus_Studio
{
    class IEBFile
    {
        private EventManager eManager;
        private DeviceManager dManager;
        public void Load(string Filename)
        {
            FileStream fStream = new FileStream(Filename, FileMode.Open );
            BinaryReader bReader = new BinaryReader(fStream);

            int eLen = bReader.ReadInt32();
            int dLen = bReader.ReadInt32();

            eManager = EventManager.Load(bReader.ReadBytes(eLen));
            dManager = DeviceManager.Load(bReader.ReadBytes(dLen));

            bReader.Close();
            bReader = null;
        }
        public void Save(string Filename, EventManager EventManager, DeviceManager DeviceManager)
        {
            Stream eStream = EventManager.Save();
            BinaryReader  eReader = new BinaryReader(eStream);
            Stream dStream = DeviceManager.Save();
            BinaryReader dReader = new BinaryReader(dStream);

            FileStream fStream = new FileStream(Filename, FileMode.Create);
            BinaryWriter bWriter = new BinaryWriter(fStream);
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
