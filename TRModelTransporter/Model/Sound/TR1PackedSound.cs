﻿using System.Collections.Generic;
using TRLevelReader.Model;

namespace TRModelTransporter.Model.Sound
{
    public class TR1PackedSound
    {
        public Dictionary<ushort, uint[]> SampleIndices { get; set; }
        public Dictionary<int, TRSoundDetails> SoundDetails { get; set; }
        public Dictionary<int, short> SoundMapIndices { get; set; }
        public Dictionary<uint, byte[]> Samples { get; set; }

        public TR1PackedSound()
        {
            SampleIndices = new Dictionary<ushort, uint[]>();
            SoundDetails = new Dictionary<int, TRSoundDetails>();
            SoundMapIndices = new Dictionary<int, short>();
            Samples = new Dictionary<uint, byte[]>();
        }
    }
}