using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16BitMipsCompiler
{
    public class JInstruction : Instruction
    {
        private AssemblyInstruction _assemblyInstruction;
        private ushort _immediate;
        private String _assemblyInstructionText;

        public String AssemblyInstructionText
        {
            get { return _assemblyInstructionText; }
            set { _assemblyInstructionText = value; }
        }

        public ushort Immediate
        {
            get { return _immediate; }
            set { _immediate = value; }
        }


        public AssemblyInstruction AssemblyInstruction
        {
            get { return _assemblyInstruction; }
            set { _assemblyInstruction = value; }
        }

        public bool HasDestinationRegister => false;

        public bool HasSource1Register => true;

        public bool HasSource2Register => true;

        public InstructionType Type => InstructionType.J;

        public int InstructionCode
        {
            get
            {
                //opcode
                int value = (_assemblyInstruction.InstructionCode << 13);

                //add immediate
                value |= _immediate;

                return value;
            }
        }

        public string InstuctionCodeSepareted
        {
            get
            {
                StringBuilder builder = new StringBuilder();

                int code = InstructionCode;
                for (int i = 0; i < 16; i++)
                {
                    builder.Append((code >> (15 - i)) & 1);
                }

                String command = builder.ToString();

                command = command.Insert(3, "_");

                return command;
            }
        }

        public JInstruction(AssemblyInstruction assemblyInstruction, ushort immediate)
        {
            _assemblyInstruction = assemblyInstruction;
            _immediate = immediate;
        }

        public JInstruction(AssemblyInstruction assemblyInstruction, String assemblyInstructionText, ushort immediate)
        {
            _assemblyInstruction = assemblyInstruction;
            _assemblyInstructionText = assemblyInstructionText;
            _immediate = immediate;
        }
    }
}
