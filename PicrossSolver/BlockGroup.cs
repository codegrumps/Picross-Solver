using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicrossSolver
{
    class BlockGroup
    {
        public BlockGroup(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("size",
                    "Size must be greater than 0.");
            }

            Size = size;
            BlocksMarked = 0;
            IsSolved = false;
        }

        public int Size { get; }
        public int BlocksMarked { get; }
        public bool IsSolved { get; }
    }
}
