using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicrossSolver
{
    public class PicrossSegment
    {
        //static readonly char UnassociatedBlock = '?';
        static readonly char UnmarkedBlock = ' ';

        List<BlockGroup> blockGroups;
        char[] blocks;

        /// <summary>
        /// Creates a PicrossSegment which represents a row or column in a
        /// PicrossTable.
        /// </summary>
        /// <param name="length">Amount of blocks.</param>
        /// <param name="blockGroupSizes">Size of each group of blocks
        /// required to be marked within the PicrossSegment.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown if length is less than or equal to 0, if length is
        /// too small to contain the BlockGroups, or if any of 
        /// blockGroupSizes is less than or equal to 0.
        /// </exception>
        public PicrossSegment(int length, params int[] blockGroupSizes)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("length", "Length of" +
                    " PicrossSegment must be greater than 0.");
            }

            if (blockGroupSizes == null)
            {
                blockGroupSizes = new int[1] { 0 };
            }

            Length = length;

            InitializeBlockGroups(blockGroupSizes);
            InitializeBlocks();            
        }

        /// <summary>
        /// Initializes List of BlockGroup objects. 
        /// </summary>
        /// <param name="blockGroupSizes">Size of each BlockGroup.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown if any of blockGroupSizes is less than or equal to 0.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if blockGroupSizes is null.
        /// </exception>
        /// <remarks>This should only be called in constructor. After call,
        /// blockGroups will contain 'n' BlockGroups where n is the amount
        /// of parameters passed in. The size of each BlockGroup will be equal
        /// to the respective integer value. </remarks>
        void InitializeBlockGroups(int[] blockGroupSizes)
        {
            if (blockGroupSizes == null)
            {
                throw new ArgumentNullException("blockGroupSizes", "Cannot" +
                    " initialize using null data.");
            }

            int requiredBlocks = 0;
            blockGroups = new List<BlockGroup>();
            foreach (int i in blockGroupSizes)
            {
                BlockGroup bg = new BlockGroup(i);
                this.blockGroups.Add(bg);
                requiredBlocks += bg.Size;
            }
            requiredBlocks += this.blockGroups.Count() - 1;

            if (requiredBlocks > Length)
            {
                blockGroups = null;
                throw new ArgumentOutOfRangeException("PicrossSegment not" +
                    " large enough to contain supplied BlockGroups.");
            }
        }

        /// <summary>
        /// Initializes array of blocks to default value.
        /// </summary>
        /// <remarks>This should only be called in constructor.</remarks>
        void InitializeBlocks()
        {
            blocks = new char[Length];
            for (int i = 0; i < Length; i++)
            {
                blocks[i] = UnmarkedBlock;
            }
        }

        /// <summary>
        /// Returns a string containing the values of blocks formatted in the
        /// style of a picross puzzle.
        /// </summary>
        /// <example>[ ][ ][ ][X][1]</example>
        public string GetFormattedBlocks()
        {
            StringBuilder formattedBlocks = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                formattedBlocks.Append($"[{blocks[i]}]");
            }

            return formattedBlocks.ToString();
        }

        /// <summary>
        /// Returns a copy of the values of the blocks.
        /// </summary>
        public char[] GetBlocks()
        {
            char[] copyOfBlocks = new char[Length];
            blocks.CopyTo(copyOfBlocks, 0);

            return copyOfBlocks;
        }

        public int Length { get; }
        public int SolvedGroups { get; }
        public bool IsSolved { get; }
    }
}
