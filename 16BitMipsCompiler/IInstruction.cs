using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16BitMipsCompiler
{
    public class IInstruction : Instruction
    {
        private Register _destination;
        private Register _source1;
        private Register _source2;
        private AssemblyInstruction _assemblyInstruction;
        private ushort _immediate;

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
        public InstructionType Type => InstructionType.I;

        public int InstructionCode
        {
            get
            {
                //opcode
                int value = (_assemblyInstruction.InstructionCode << 13);

                //add source1
                value |= ((int)_source1 << 10);
                //add source2
                value |= ((int)_source2 << 7);
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
                command = command.Insert(7, "_");
                command = command.Insert(11, "_");

                return command;
            }
        }

        public IInstruction(AssemblyInstruction assemblyInstruction, Register source1, Register source2, ushort immediate)
        {
            _assemblyInstruction = assemblyInstruction;
            _source1 = source1;
            _source2 = source2;
            _immediate = immediate;
        }
    }
}
