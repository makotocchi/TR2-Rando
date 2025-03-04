﻿using System.Collections.Generic;

namespace TRRandomizerCore.Globalisation
{
    public class LevelStrings
    {
        public string[] Names { get; set; }
        public Dictionary<int, string[]> Keys { get; set; }
        public Dictionary<int, string[]> Pickups { get; set; }
        public Dictionary<int, string[]> Puzzles { get; set; }
    }
}