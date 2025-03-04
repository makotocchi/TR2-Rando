﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRLevelReader.Model;

namespace TRLevelReader
{
    public class TR4LevelWriter
    {
        public TR4LevelWriter()
        {

        }

        public void WriteLevelToFile(TR4Level lvl, string filepath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(filepath)))
            {
                writer.Write(lvl.Serialize());
            }
        }
    }
}
