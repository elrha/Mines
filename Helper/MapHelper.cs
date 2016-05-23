using Mines.Manager.ConfigManager;
using PlayerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mines.Helper
{
    class MapHelper
    {
        public static MineType[] CreateFields()
        {
            return Enumerable.Repeat<MineType>(MineType.NONE, ConfigManager.Instance.MineWidthCount * ConfigManager.Instance.MineWidthCount).ToArray();
        }

        public static MineType[] SetMines(MineType[] mineFields)
        {
            var fieldCount = mineFields.Count();
            var maxMine = ConfigManager.Instance.MaxMine;
            var currentMine = 0;
            var rand = new Random();

            while (currentMine < maxMine)
            {
                var index = rand.Next(fieldCount);

                if (mineFields[index] != MineType.RESERVED_0)
                {
                    mineFields[index] = MineType.RESERVED_0;
                    currentMine++;
                }
            }

            return mineFields;
        }

        public static MineType[] SetNumbers(MineType[] mineFields)
        {
            var fieldVCount = ConfigManager.Instance.MineWidthCount;

            // note : inner
            for (int h = 1; h < fieldVCount - 1; h++)
            {
                for (int w = 1; w < fieldVCount - 1; w++)
                {
                    var index = (fieldVCount * h) + w;

                    if (mineFields[index] != MineType.RESERVED_0)
                    {
                        mineFields[index] = MineType.NUMBER_0;
                        if (mineFields[(index - fieldVCount) - 1] == MineType.RESERVED_0) mineFields[index]++;
                        if (mineFields[index - fieldVCount] == MineType.RESERVED_0) mineFields[index]++;
                        if (mineFields[(index - fieldVCount) + 1] == MineType.RESERVED_0) mineFields[index]++;
                        if (mineFields[index - 1] == MineType.RESERVED_0) mineFields[index]++;
                        if (mineFields[index + 1] == MineType.RESERVED_0) mineFields[index]++;
                        if (mineFields[(index + fieldVCount) - 1] == MineType.RESERVED_0) mineFields[index]++;
                        if (mineFields[index + fieldVCount] == MineType.RESERVED_0) mineFields[index]++;
                        if (mineFields[(index + fieldVCount) + 1] == MineType.RESERVED_0) mineFields[index]++;
                    }
                }
            }

            var bottomStart = (fieldVCount - 1) * fieldVCount;
            for (int w = 1; w < fieldVCount - 1; w++)
            {
                // note : top
                if (mineFields[w] != MineType.RESERVED_0)
                {
                    mineFields[w] = MineType.NUMBER_0;
                    if (mineFields[w - 1] == MineType.RESERVED_0) mineFields[w]++;
                    if (mineFields[w + 1] == MineType.RESERVED_0) mineFields[w]++;
                    if (mineFields[(w + fieldVCount) - 1] == MineType.RESERVED_0) mineFields[w]++;
                    if (mineFields[w + fieldVCount] == MineType.RESERVED_0) mineFields[w]++;
                    if (mineFields[(w + fieldVCount) + 1] == MineType.RESERVED_0) mineFields[w]++;
                }

                // note : bottom
                var bottomIndex = bottomStart + w;
                if (mineFields[bottomIndex] != MineType.RESERVED_0)
                {
                    mineFields[bottomIndex] = MineType.NUMBER_0;
                    if (mineFields[(bottomIndex - fieldVCount) - 1] == MineType.RESERVED_0) mineFields[bottomIndex]++;
                    if (mineFields[bottomIndex - fieldVCount] == MineType.RESERVED_0) mineFields[bottomIndex]++;
                    if (mineFields[(bottomIndex - fieldVCount) + 1] == MineType.RESERVED_0) mineFields[bottomIndex]++;
                    if (mineFields[bottomIndex - 1] == MineType.RESERVED_0) mineFields[bottomIndex]++;
                    if (mineFields[bottomIndex + 1] == MineType.RESERVED_0) mineFields[bottomIndex]++;
                }
            }

            for (int h = 1; h < fieldVCount - 1; h++)
            {
                // note : left
                var leftIndex = fieldVCount * h;
                if (mineFields[leftIndex] != MineType.RESERVED_0)
                {
                    mineFields[leftIndex] = MineType.NUMBER_0;

                    if (mineFields[leftIndex - fieldVCount] == MineType.RESERVED_0) mineFields[leftIndex]++;
                    if (mineFields[(leftIndex - fieldVCount) + 1] == MineType.RESERVED_0) mineFields[leftIndex]++;
                    if (mineFields[leftIndex + 1] == MineType.RESERVED_0) mineFields[leftIndex]++;
                    if (mineFields[leftIndex + fieldVCount] == MineType.RESERVED_0) mineFields[leftIndex]++;
                    if (mineFields[(leftIndex + fieldVCount) + 1] == MineType.RESERVED_0) mineFields[leftIndex]++;
                }

                // note : right
                var rightIndex = leftIndex + (fieldVCount - 1);
                if (mineFields[rightIndex] != MineType.RESERVED_0)
                {
                    mineFields[rightIndex] = MineType.NUMBER_0;
                    if (mineFields[(rightIndex - fieldVCount) - 1] == MineType.RESERVED_0) mineFields[rightIndex]++;
                    if (mineFields[rightIndex - fieldVCount] == MineType.RESERVED_0) mineFields[rightIndex]++;
                    if (mineFields[rightIndex - 1] == MineType.RESERVED_0) mineFields[rightIndex]++;
                    if (mineFields[(rightIndex + fieldVCount) - 1] == MineType.RESERVED_0) mineFields[rightIndex]++;
                    if (mineFields[rightIndex + fieldVCount] == MineType.RESERVED_0) mineFields[rightIndex]++;
                }
            }

            // note : left top
            if (mineFields[0] != MineType.RESERVED_0)
            {
                mineFields[0] = MineType.NUMBER_0;
                if (mineFields[1] == MineType.RESERVED_0) mineFields[0]++;
                if (mineFields[fieldVCount] == MineType.RESERVED_0) mineFields[0]++;
                if (mineFields[fieldVCount + 1] == MineType.RESERVED_0) mineFields[0]++;
            }

            // note : right top
            var rightTopIndex = fieldVCount - 1;
            if (mineFields[rightTopIndex] != MineType.RESERVED_0)
            {
                mineFields[rightTopIndex] = MineType.NUMBER_0;
                if (mineFields[rightTopIndex - 1] == MineType.RESERVED_0) mineFields[rightTopIndex]++;
                if (mineFields[rightTopIndex + (fieldVCount - 1)] == MineType.RESERVED_0) mineFields[rightTopIndex]++;
                if (mineFields[rightTopIndex + fieldVCount] == MineType.RESERVED_0) mineFields[rightTopIndex]++;
            }

            // note : left bottom
            var leftBottomIndex = (fieldVCount - 1) * fieldVCount;
            if (mineFields[leftBottomIndex] != MineType.RESERVED_0)
            {
                mineFields[leftBottomIndex] = MineType.NUMBER_0;
                if (mineFields[leftBottomIndex - fieldVCount] == MineType.RESERVED_0) mineFields[leftBottomIndex]++;
                if (mineFields[leftBottomIndex - fieldVCount + 1] == MineType.RESERVED_0) mineFields[leftBottomIndex]++;
                if (mineFields[leftBottomIndex + 1] == MineType.RESERVED_0) mineFields[leftBottomIndex]++;
            }

            // note : right bottom
            var rightBottomIndex = (fieldVCount * fieldVCount - 1);
            if (mineFields[rightBottomIndex] != MineType.RESERVED_0)
            {
                mineFields[rightBottomIndex] = MineType.NUMBER_0;
                if (mineFields[rightBottomIndex - fieldVCount - 1] == MineType.RESERVED_0) mineFields[rightBottomIndex]++;
                if (mineFields[rightBottomIndex - fieldVCount] == MineType.RESERVED_0) mineFields[rightBottomIndex]++;
                if (mineFields[rightBottomIndex - 1] == MineType.RESERVED_0) mineFields[rightBottomIndex]++;
            }

            return mineFields;
        }
    }
}
