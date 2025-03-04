﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TRLevelReader.Serialization;

namespace TRLevelReader.Model
{
    public class TR4MeshFace3 : ISerializableCompact
    {
        public ushort[] Vertices { get; set; }

        public ushort Texture { get; set; }

        public ushort Effects { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    foreach (ushort vert in Vertices) { writer.Write(vert); }
                    writer.Write(Texture);
                    writer.Write(Effects);
                }

                return stream.ToArray();
            }
        }
    }
}
