﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRFDControl
{
    public class FDSetup
    {
        public ushort Value { get; set; }

        public FDSetup() { }

        public FDSetup(FDFunctions function)
        {
            Value = (byte)function;
        }

        public byte Function
        {
            get
            {
                return (byte)(Value & 0x001F);
            }
        }

        public byte ExtendedFunction
        {
            get
            {
                return (byte)(Value & 0x00FF);
            }
        }

        public byte ExtendedFunctionOnly
        {
            get
            {
                return (byte)(Value & 0x00E0);
            }
        }

        public byte SubFunction
        {
            get
            {
                return (byte)((Value & 0x7F00) >> 8);
            }
        }

        public bool EndData
        {
            get
            {
                return (Value & 0x8000) > 0;
            }
            internal set
            {
                if (value)
                {
                    Value |= 0x8000;
                }
                else
                {
                    Value = (ushort)(Value & ~0x8000);
                }
            }
        }

        #region Triangulation
        public sbyte H1
        {
            get
            {
                return (sbyte)(Value & 0x03E0);
            }
        }

        public sbyte H2
        {
            get
            {
                return (sbyte)(Value & 0x7C00);
            }
        }
        #endregion
    }
}
