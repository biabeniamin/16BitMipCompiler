using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16BitMipsCompiler
{
    public class AssemblyInstruction
    {
        private String _mnemonic;
        private ushort _instructionCode;
        private InstructionType _type;
        private List<String> _parameters;

        public List<String> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }


        public InstructionType Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public ushort InstructionCode
        {
            get { return _instructionCode; }
            set { _instructionCode = value; }
        }

        public String Mnemonic
        {
            get { return _mnemonic; }
            set { _mnemonic = value; }
        }

        public AssemblyInstruction(String mnemonic, ushort instructionCode, InstructionType type)
        {
            _mnemonic = mnemonic;
            _instructionCode = instructionCode;
            _type = type;
        }


    }
}
