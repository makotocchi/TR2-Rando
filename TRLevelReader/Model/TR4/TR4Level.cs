﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TRLevelReader.Serialization;

namespace TRLevelReader.Model
{
    public class TR4Level : ISerializableCompact
    {
        public uint Version { get; set; }

        public ushort NumRoomTextiles { get; set; }

        public ushort NumObjTextiles { get; set; }

        public ushort NumBumpTextiles { get; set; }

        public TR4Texture32Chunk Texture32Chunk { get; set; }

        public TR4Texture16Chunk Texture16Chunk { get; set; }

        public TR4SkyAndFont32Chunk SkyAndFont32Chunk { get; set; }

        public TR4LevelDataChunk LevelDataChunk { get; set; }

        public uint NumSamples { get; set; }

        public TR4Sample[] Samples { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(Version);
                    writer.Write(NumRoomTextiles);
                    writer.Write(NumObjTextiles);
                    writer.Write(NumBumpTextiles);

                    byte[] chunk = Texture32Chunk.Serialize();
                    writer.Write(Texture32Chunk.UncompressedSize);
                    writer.Write(Texture32Chunk.CompressedSize);
                    writer.Write(chunk);

                    chunk = Texture16Chunk.Serialize();
                    writer.Write(Texture16Chunk.UncompressedSize);
                    writer.Write(Texture16Chunk.CompressedSize);
                    writer.Write(chunk);

                    chunk = SkyAndFont32Chunk.Serialize();
                    writer.Write(SkyAndFont32Chunk.UncompressedSize);
                    writer.Write(SkyAndFont32Chunk.CompressedSize);
                    writer.Write(chunk);

                    chunk = LevelDataChunk.Serialize();
                    writer.Write(LevelDataChunk.UncompressedSize);
                    writer.Write(LevelDataChunk.CompressedSize);
                    writer.Write(chunk);

                    writer.Write(NumSamples);

                    foreach (TR4Sample sample in Samples)
                    {
                        chunk = sample.Serialize();
                        writer.Write(sample.UncompSize);
                        writer.Write(sample.CompSize);
                        writer.Write(chunk);
                    }
                }

                return stream.ToArray();
            }
        }
    }
}
