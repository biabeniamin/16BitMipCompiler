﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16BitMipsCompiler
{
    public interface Instruction
    {
        int InstructionCode
        {
            get;
        }
    }
}
