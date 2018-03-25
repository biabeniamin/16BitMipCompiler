using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16BitMipsCompiler
{
    public class RInstruction : Instruction
    {
        private ushort _instructionCode;
        private Register _destination;
        private Register _source1;
        private Register _source2;
        private AssemblyInstruction _assemblyInstruction;
        public int InstructionCode
        {
            get
            {
                //opcode 0
                int value = 0;

                //add source1
                value |= ((int)_source1 << 10);
                //add source2
                value |= ((int)_source2 << 7);
                //add destination
                value |= ((int)_destination << 4);
                //add function
                value |= _assemblyInstruction.InstructionCode;

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
                command = command.Insert(7, "_");
                command = command.Insert(11, "_");
                command = command.Insert(15, "_");
                command = command.Insert(17, "_");

                return command;
            }
        }

        public AssemblyInstruction AssemblyInstruction
        {
            get { return _assemblyInstruction; }
            set { _assemblyInstruction = value; }
        }


        public Register Source1
        {
            get => _source1;
            set => _source1 = value;
        }
        public Register Source2
        {
            get => _source2;
            set => _source2 = value;
        }
        public Register Destination
        {
            get => _destination;
            set => _destination = value;
        }

        public InstructionType Type => InstructionType.R;


        public RInstruction(AssemblyInstruction assemblyInstruction, Register destination, Register source1, Register source2)
        {
            _assemblyInstruction = assemblyInstruction;
            _source1 = source1;
            _source2 = source2;
            _destination = destination;
        }

    }
}
