﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRFDControl.FDEntryTypes
{
    public class FDSlantEntry : FDEntry
    {
        public FDSlantEntryType Type { get; set; }

        public ushort SlantValue { get; set; }

        public sbyte XSlant
        {
            get
            {
                return (sbyte)(SlantValue & 0x00ff);
            }
            set
            {
                SetSlants(value, ZSlant);
            }
        }

        public sbyte ZSlant
        {
            get
            {
                return (sbyte)(SlantValue >> 8);
            }
            set
            {
                SetSlants(XSlant, value);
            }
        }

        private void SetSlants(sbyte xSlant, sbyte zSlant)
        {
            int value = (xSlant & 0xff) + (zSlant << 8);
            if (value < 0)
            {
                value = ushort.MaxValue + 1 + value;
            }
            SlantValue = (ushort)value;
        }

        public override ushort[] Flatten()
        {
            return new ushort[]
            {
                Setup.Value,
                SlantValue
            };
        }
    }
}
