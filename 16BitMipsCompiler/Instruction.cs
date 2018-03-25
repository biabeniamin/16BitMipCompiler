using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16BitMipsCompiler
{
    public interface Instruction
    {
        InstructionType Type
        {
            get;
        }
        int InstructionCode
        {
            get;
        }
        String InstuctionCodeSepareted
        {
            get;
        }
        AssemblyInstruction AssemblyInstruction
        {
            get;
        }
    }
}
