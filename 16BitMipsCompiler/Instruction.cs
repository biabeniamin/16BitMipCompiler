using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16BitMipsCompiler
{
    public interface Instruction
    {
        UInt16 InstructionCode
        {
            get;
        }

        bool HasDestinationRegister
        {
            get;
        }

        bool HasSource1Register
        {
            get;
        }

        bool HasSource2Register
        {
            get;
        }

        Register Source1
        {
            get;set;
        }

        Register Source2
        {
            get;set;
        }

        Register Destination
        {
            get;set;
        }

        InstructionType Type
        {
            get;
            set;
        }
    }
}
