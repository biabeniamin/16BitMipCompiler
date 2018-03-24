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
        private Function _function;
        public int InstructionCode
        {
            get
            {
                //opcode 0
                int value = 0;

                //add source1
                value |= ((int)_source1 << 11);
                //add source2
                value |= ((int)_source2 << 8);
                //add destination
                value |= ((int)_destination << 5);
                //add function
                value |= (int)_function;

                return value;
            }
        }

        

        public Function Function
        {
            get { return _function; }
            set { _function = value; }
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

        public RInstruction(Function function, Register destination, Register source1, Register source2)
        {
            _function = function;
            _source1 = source1;
            _source2 = source2;
            _destination = destination;
        }

    }
}
